Shader "URPTest/02_tex"
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
			CBUFFER_START(UnityPerMaterial)
				float4 _MainTex_ST;
			CBUFFER_END

			TEXTURE2D(_MainTex);
			SAMPLER(sampler_MainTex);

			struct appdata
			{
				float4 pos : POSITION;
				float2 uv: TEXCOORD0;
			};
			struct v2f
			{
				float2 uv: TEXCOORD0;
				float fogCoord : TEXCOORD1; 
				float4 pos : SV_POSITION;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.pos = TransformObjectToHClip(v.pos.xyz);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.fogCoord = ComputeFogFactor(o.pos.z);
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{
				half4 col = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex,i.uv);
				col.rgb = MixFog(col.rgb, i.fogCoord);
				return col;
			}

			ENDHLSL
		}
	}
}
