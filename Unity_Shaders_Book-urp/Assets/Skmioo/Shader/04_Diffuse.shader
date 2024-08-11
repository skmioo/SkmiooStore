// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/04_Diffuse"
{
	SubShader
	{

		Pass
		{
		 Tags { "LightMode" = "ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"
			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};


			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//俩种方式等价
				//float3 N = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
				float3 N = normalize(mul(v.normal, (float3x3)unity_WorldToObject));
				float3 Ldir = normalize(_WorldSpaceLightPos0).xyz;
				//限制结果在0~1
				float ndotl = saturate(dot(N, Ldir));
				//_LightColor0 直射光
				o.color =  _LightColor0 * ndotl;

				float3 wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//ForwardBase下4个点光源 Shade4PointLights
				o.color.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
												unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
												unity_4LightAtten0, wpos, N);
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				//UNITY_LIGHTMODEL_AMBIENT 环境光，不然黑色部分会很黑
				//Window -> Rendering-> Lighting setting  默认(SkyBox) 也可以修改为颜色
				return IN.color + UNITY_LIGHTMODEL_AMBIENT;
			}

			ENDCG
		}
	}
}
