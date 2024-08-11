Shader "URPTest/06_Ramp"
{
	properties
	{
		_BaseColor("_DiffuseColor",Color) = (1,1,1,1)        
		_RampTex ("RampTex", 2D) = "white" {} 
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline"}
		Pass
		{
			  Tags{ "LightMode"="UniversalForward" }

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile_fog

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"

			struct appdata
            {
                float4 positionOS : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 normalOS : NORMAL;            
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;                                             //float4类型的UV数据，
                float4 positionCS : SV_POSITION;
                float3 normalWS : TEXCOORD1;                                       //输出世界空间下法线信息
			};

            CBUFFER_START(UnityPerMaterial)
                float4 _RampTex_ST;
                float4 _BaseColor;
            CBUFFER_END


            TEXTURE2D (_RampTex);
            SAMPLER(sampler_RampTex); 

			v2f vert(appdata v)
			{
				v2f o;
				o.positionCS = TransformObjectToHClip(v.positionOS.xyz);
                // o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
				o.uv = TRANSFORM_TEX(v.texcoord, _RampTex);
                o.normalWS = TransformObjectToWorldNormal(v.normalOS); 
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{			
			    real4 LightColor = real4(GetMainLight().color,1);                     //获取主光源的颜色
                real3 NormalDir = normalize(i.normalWS);                       //归一化法线方向
                float3 LightDir = normalize(GetMainLight().direction);                //获取光照方向

                float LdotN = dot(LightDir,NormalDir) * 0.5 + 0.5;                        //LdotN
				//此处的0.5表示y值随便取
				//LdotN表示光照颜色
                half4 col = SAMPLE_TEXTURE2D(_RampTex,sampler_RampTex,float2(LdotN,0.2)) * _BaseColor;     //贴图采样变成3个变量
                return col * LightColor;
			}
 
			ENDHLSL
		}
	}
}
