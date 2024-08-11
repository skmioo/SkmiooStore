// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/12_Transparent_AlphaAndBlend_1"
{	
	properties
	{
	
	}

	SubShader
	{
		//有了透明标签，透明的物体跟透明的物体之间进行颜色融合
		tags{"queue" = "transparent" "rendertype" = "transparent"}
		
		Pass
		{
			//透明的与之前的数据融合
			blend srcalpha oneminussrcalpha
			//如果透明需要关闭zwrite
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
				return fixed4(1,0,0,0.5);
			}

			ENDCG
		}
	}
}
