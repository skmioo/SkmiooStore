Shader "URPTest/04_Phong"
{
	properties
	{
		_MainTex("Texture", 2d) = "white"{}
		_gloss("_gloss",Float) = 0.2
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline"}
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

			CBUFFER_START(UnityPerMaterial)
				float4 _MainTex_ST;
				float _gloss;
			CBUFFER_END

			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);

			struct appdata
			{
				float4 posOS : POSITION;
				float4 normalOS : NORMAL;
				float2 uv: TEXCOORD0;
			};
			struct v2f
			{
				float2 uv: TEXCOORD0;
				float4 vertex : SV_POSITION;
				float3 normalWS : TEXTCOORD1;	
				float3 viewDirWS : TEXCOORD2;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = TransformObjectToHClip(v.posOS.xyz);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normalWS = TransformObjectToWorldNormal(v.normalOS.xyz);
				o.viewDirWS = normalize(_WorldSpaceCameraPos.xyz - TransformObjectToWorld(v.posOS.xyz));
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{			
				half4 tex = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, i.uv);
				Light light = GetMainLight();
				real4 lightColor = real4(light.color, 1);

				real3 viewDir = i.viewDirWS;
				real3 normalDir = i.normalWS;
				real3 lightDir = normalize(light.direction);
				real3 reflectDir = normalize(reflect(-lightDir,normalDir));
				float LdotN = dot(lightDir, i.normalWS) * 0.5 + 0.5;
				
				//Phong
				//half4 specularValue = pow(max(0, dot(reflectDir, viewDir)), _gloss)* lightColor; 

				// Blinn-Phong
				real3 halfDir = normalize(viewDir + lightDir);
				half4 specularValue = pow(max(0,dot(normalDir,halfDir)),_gloss) * lightColor;  

				half4 diffuseCol = tex * LdotN * lightColor;
  				half4 col =  specularValue + diffuseCol;
				return col;
			}
 
			ENDHLSL
		}
	}
}
