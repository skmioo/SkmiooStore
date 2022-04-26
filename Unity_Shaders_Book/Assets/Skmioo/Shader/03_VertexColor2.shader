// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/03_VertexColor2"
{
	SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"

			struct v2f 
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};
			

			//模型的位置是(-0.5,-0.5) ~ (0.5, 0.5) 屏幕空间是(-1.0, -1.0) ~(1.0,1.0)
			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//裁剪空间到屏幕空间x,y
				float x = o.pos.x / o.pos.w;
				float y = o.pos.y / o.pos.w;
				if (x < 0)
				{
					if (x < -0.8f)
					{
						o.color = fixed4(1,0,0,1);
					}
					else
					{
						o.color = fixed4(1, 1, 0, 1);
					}
				}
				else
				{
					if(x > 0.8f)
					{
						o.color = fixed4(0, 1, 0, 1);
					}
					else
					{
						o.color = fixed4(0, 1, 1, 1);
					}
				}
				return o;
			}
			
			fixed4 frag(in v2f IN) : COLOR
			{
				return IN.color;
			}
         
            ENDCG
        }
    }
}
