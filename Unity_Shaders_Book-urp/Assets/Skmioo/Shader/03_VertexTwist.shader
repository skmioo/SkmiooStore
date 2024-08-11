// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/03_VertexTwist"
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
			

			v2f vert(appdata_base v)
			{
				float speed = 0.5;
				float4 angle = length(v.vertex) * sin(_Time.w)  * speed;
				float f1 = cos(angle);
				float f2 = sin(angle);

				float4x4 m = {
							float4(f1, 0, f2, 0),
							float4(0, 1, 0, 0),
							float4(-f2, 0, f1, 0),
							float4(0, 0, 0, 1)
				};
				v.vertex = mul(m, v.vertex);
				float4x4 mvp = UNITY_MATRIX_MVP;
				v2f o;
				o.pos = mul(mvp, v.vertex);
				o.color = fixed4(1, 1, 1, 1);
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
