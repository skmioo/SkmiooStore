// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/12_Transparent_AlphaAndBlend_2"
{	
	properties
	{
	
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
				return fixed4(0,0,1,0.5);
			}

			ENDCG
		}
	}
}
