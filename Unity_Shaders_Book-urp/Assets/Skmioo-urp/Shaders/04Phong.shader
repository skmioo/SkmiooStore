Shader "URPTest/04_Phong"
{
	properties
	{
		_MainTex("Texture", 2d) = "white"{}
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
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = TransformObjectToHClip(v.posOS.xyz);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.normalWS = TransformObjectToWorldNormal(v.normalOS.xyz);
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{
				Light light = GetMainLight();
				real4 lightColor = real4(light.color, 1);
				float3 lightDir = normalize(light.direction);
				//float LdotN = dot(lightDir, i.normalWS);
				float LdotN = dot(lightDir, i.normalWS) * 0.5 + 0.5;
				half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex,i.uv);
				return col * LdotN * lightColor; 
			}

			ENDHLSL
		}
	}
}
