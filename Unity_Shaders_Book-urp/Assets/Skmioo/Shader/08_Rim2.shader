// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/08_Rim2"
{	
	properties
	{
		_MainColor("Main Color", color) = (1,1,1,1)
		_Scale("scale",range(1,8)) = 4.5
		_Outer("Outer", range(0,1)) = 0.2
	}

	SubShader
	{
		tags{"queue" = "transparent" }

			Pass
		{
			blend srcalpha oneminussrcalpha
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"


			struct v2f
			{
				float4 pos : POSITION;
				float3 normal : TEXCOORD0;
				float4 vertex : TEXCOORD1;
			};
			float4 _MainColor;
			float _Scale;
			float _Outer;
			v2f vert(appdata_base v)
			{
				//顶点的位置沿着法线的方向
				v.vertex.xyz += v.normal * _Outer;
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.vertex = v.vertex;
				o.normal = v.normal;
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				//法向量
				float3 N = UnityObjectToWorldNormal(IN.normal);
				//视向量
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));
				//亮度
				float bright = saturate(dot(N, V));
				bright = pow(bright, _Scale);
				_MainColor.a *= bright;
				return _MainColor ;
			}

			ENDCG
		}
		//=========================================

		Pass
		{
			//从上面渲染的目标中减去中间的
			blendop revsub
			blend dstalpha one
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"


			struct v2f
			{
				float4 pos : POSITION;
			};
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				return fixed4(1,1,1,1);
			}

			ENDCG
		}
		//==========================================
		Pass
		{
			//禁用该通道
			//blend zero one
			blend srcalpha oneminussrcalpha
			zwrite off
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"


			struct v2f
			{
				float4 pos : POSITION;
				float3 normal : TEXCOORD0;
				float4 vertex : TEXCOORD1;
			};
			float4 _MainColor;
			float _Scale;
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.vertex = v.vertex;
				o.normal = v.normal;
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				//法向量
				float3 N = UnityObjectToWorldNormal(IN.normal);
				//视向量
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));
				//亮度
				float bright = 1.0 - saturate(dot(N, V));
				bright = pow(bright, _Scale);
				return _MainColor * bright;
			}

			ENDCG
		}
	}
}
