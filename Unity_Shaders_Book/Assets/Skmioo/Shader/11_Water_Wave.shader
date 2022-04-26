
Shader "Skmioo/11_Water_Wave"
{	
	properties
	{
		_UVOffset("UVOffset",range(0.01,0.05)) = 0.025
		_MainTex("MainTex",2D) = ""
	}

		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"

			sampler2D _MainTex;
			sampler2D _WaveTex;
			float4 _MainTex_ST;
			float _UVOffset;
			struct v2f
			{
				float4 pos : POSITION;
				float2 uv : TEXCOORD0;
			};


			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//uv进行ST操作
				//o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				//直接获取uv数据，不进行ST操作
				o.uv = v.texcoord.xy;
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{ 
				float2 uv = tex2D(_WaveTex, IN.uv).xy;
				//把范围从(0~1)恢复到(-1~1)
				uv= (uv - 0.5) * 2;
				//uv采样(-1~1)太大,采样范围
				uv *= _UVOffset;
				IN.uv += uv;
				fixed4 color = tex2D(_MainTex, IN.uv);
				return color;
			}

			ENDCG
		}
	}
}
