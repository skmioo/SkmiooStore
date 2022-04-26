// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/12_Transparent_Hero"
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
			//当透明物体遮挡时，因为透明的物体zwrite off,没有深度值，所以该pass通道比较失败，没有输出
			zwrite on
			ztest Greater
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
				return fixed4(1,1,0,0.5);
			}

			ENDCG
		}
		Pass
		{
			//blend srcalpha oneminussrcalpha
			zwrite on
			//此处的ztest会跟上一次的本身作比较，因为上一次的ztest Greater
			ztest Less
			
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
				return fixed4(1,0,0,1);
			}

			ENDCG
		}
	}
}
