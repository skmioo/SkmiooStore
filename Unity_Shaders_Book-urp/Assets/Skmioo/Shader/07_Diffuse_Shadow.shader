
Shader "Skmioo/07_Diffuse_Shadow"
{

	SubShader
	{
		//https://www.bilibili.com/video/BV1M3411k784?p=50&spm_id_from=pageDriver
		Pass
		{
			//阴影投射
			Tags { "LightMode" = "ShadowCaster" }
		}

		Pass
		{
			Tags { "LightMode" = "ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"
			#include "AutoLight.cginc"
			//https://www.bilibili.com/video/BV1M3411k784?p=51&spm_id_from=333.880.my_history.page.click
			//#ifdef POINT
			//#   define DECLARE_LIGHT_COORDS(idx) unityShadowCoord3 _LightCoord : TEXCOORD##idx;
			//#   define COMPUTE_LIGHT_COORDS(a) a._LightCoord = mul(unity_WorldToLight, mul(unity_ObjectToWorld, v.vertex)).xyz;
			//#   define LIGHT_ATTENUATION(a)    (tex2D(_LightTexture0, dot(a._LightCoord,a._LightCoord).rr).r * SHADOW_ATTENUATION(a))
			//#endif
			//
			//#ifdef SPOT
			//#   define DECLARE_LIGHT_COORDS(idx) unityShadowCoord4 _LightCoord : TEXCOORD##idx;
			//#   define COMPUTE_LIGHT_COORDS(a) a._LightCoord = mul(unity_WorldToLight, mul(unity_ObjectToWorld, v.vertex));
			//#   define LIGHT_ATTENUATION(a)    ( (a._LightCoord.z > 0) * UnitySpotCookie(a._LightCoord) * UnitySpotAttenuate(a._LightCoord.xyz) * SHADOW_ATTENUATION(a) )
			//#endif
			//
			//#ifdef DIRECTIONAL
			//#   define DECLARE_LIGHT_COORDS(idx)
			//#   define COMPUTE_LIGHT_COORDS(a)
			//#   define LIGHT_ATTENUATION(a) SHADOW_ATTENUATION(a)
			//#endif
			//
			//#ifdef POINT_COOKIE
			//#   define DECLARE_LIGHT_COORDS(idx) unityShadowCoord3 _LightCoord : TEXCOORD##idx;
			//#   define COMPUTE_LIGHT_COORDS(a) a._LightCoord = mul(unity_WorldToLight, mul(unity_ObjectToWorld, v.vertex)).xyz;
			//#   define LIGHT_ATTENUATION(a)    (tex2D(_LightTextureB0, dot(a._LightCoord,a._LightCoord).rr).r * texCUBE(_LightTexture0, a._LightCoord).w * SHADOW_ATTENUATION(a))
			//#endif
			//
			//#ifdef DIRECTIONAL_COOKIE
			//#   define DECLARE_LIGHT_COORDS(idx) unityShadowCoord2 _LightCoord : TEXCOORD##idx;
			//#   define COMPUTE_LIGHT_COORDS(a) a._LightCoord = mul(unity_WorldToLight, mul(unity_ObjectToWorld, v.vertex)).xy;
			//#   define LIGHT_ATTENUATION(a)    (tex2D(_LightTexture0, a._LightCoord).w * SHADOW_ATTENUATION(a))
			//#endif
			//他们都定义了DECLARE_LIGHT_COORDS COMPUTE_LIGHT_COORDS LIGHT_ATTENUATION 系统旋转哪个呢?采用多版本定义的方式
			//file:///E:/Unity/Editor/Data/Documentation/en/Manual/SL-MultipleProgramVariants.html
			//multi_compile_fwdbase adds this set of keywords: 
			//DIRECTIONAL LIGHTMAP_ON 
			//DIRLIGHTMAP_COMBINED 
			//DYNAMICLIGHTMAP_ON 
			//SHADOWS_SCREEN 
			//SHADOWS_SHADOWMASK 
			//LIGHTMAP_SHADOW_MIXING 
			//LIGHTPROBE_SH. These variants are needed by PassType.ForwardBase.
			//multi_compile_fwdadd_fullshadows比multi_compile_fwdbase多了实时阴影
			//#pragma multi_compile_fwdbase
			#pragma multi_compile_fwdadd_fullshadows
			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
				//AutoLight.cginc 接收影子
				// unityShadowCoord3 _LightCoord : TEXCOORD0;
				// unityShadowCoord3 _ShadowCoord : TEXCOORD1;
				LIGHTING_COORDS(0,1)
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
				o.color = _LightColor0 * ndotl;
				//环境光
				o.color += UNITY_LIGHTMODEL_AMBIENT;

				float3 wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
				//ForwardBase下4个点光源 Shade4PointLights
				o.color.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
												unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
												unity_4LightAtten0, wpos, N);

				//AutoLight.cginc 接收影子
				TRANSFER_VERTEX_TO_FRAGMENT(o);
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				//AutoLight.cginc 接收影子
				float atten = LIGHT_ATTENUATION(IN);
				IN.color.rgb *= atten;
				return IN.color ;
			}

			ENDCG
		}
			Pass
			{
				Tags { "LightMode" = "ForwardAdd" }
				
				blend one one

				CGPROGRAM
				#pragma vertex vert
				#pragma fragment frag
				#include "unitycg.cginc"
				#include "UnityLightingCommon.cginc"
				#include "AutoLight.cginc"
				#pragma multi_compile_fwdadd_
				struct v2f
				{
					float4 pos : POSITION;
					fixed4 color : COLOR;
					//AutoLight.cginc 接收影子
					// unityShadowCoord3 _LightCoord : TEXCOORD0;
					// unityShadowCoord3 _ShadowCoord : TEXCOORD1;
					LIGHTING_COORDS(0,1)
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
					o.color = _LightColor0 * ndotl;
					//环境光
					//o.color += UNITY_LIGHTMODEL_AMBIENT;

					float3 wpos = mul(unity_ObjectToWorld, v.vertex).xyz;
					//ForwardBase下4个点光源 Shade4PointLights
					o.color.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
													unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
													unity_4LightAtten0, wpos, N);

					//AutoLight.cginc 接收影子
					TRANSFER_VERTEX_TO_FRAGMENT(o);
					return o;
				}

				fixed4 frag(in v2f IN) : COLOR
				{
					//AutoLight.cginc 接收影子
					float atten = LIGHT_ATTENUATION(IN);
					IN.color.rgb *= atten;
					return IN.color;
				}

				ENDCG
			}
    }

}
