// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/12_Transparent_ReplacementShader"
{	
	properties
	{
	
	}

	SubShader
	{
		tags{ "rendertype" = "transparent" }
		Pass
		{
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"

			struct v2f
			{
				float4 pos : POSITION;
				float2 depth : TEXCOORD0;
			};


			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.depth = o.pos.zw;
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				//计算深度值
				float depth = Linear01Depth(IN.depth.x / IN.depth.y);
				return fixed4(depth,0,0,1);
			}

			ENDCG
		}
	}
}
