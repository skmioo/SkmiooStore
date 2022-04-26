// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/03_VertexMove"
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
				float2 xy = v.vertex.xz;
				//旋转cg自带函数Length 到0的距离
				//float d = sqrt((xy.x - center.x) * (xy.x - center.x) + (xy.y - center.y) * (xy.y - center.y));
				float d = 1 - length(xy);
				float4 ve = v.vertex;
				ve.y = d;
				if (ve.y < 0)
				{
					ve.y = 0;
					o.color = fixed4(0, 1, 1, 1);
				}
				else {
					o.color = fixed4(1, 0, 0, 1);
				}
				o.pos = UnityObjectToClipPos(ve);
				
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
