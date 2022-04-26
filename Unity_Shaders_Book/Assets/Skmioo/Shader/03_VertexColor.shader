// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/03_VertexColor"
{
	SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"

			float4x4 mvp;
			float4x4 rm;
			float4x4 sm;

			struct v2f 
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};
			

			//模型的位置是(-0.5,-0.5) ~ (0.5, 0.5) 屏幕空间是(-1.0, -1.0) ~(1.0,1.0)
			v2f vert(appdata_base v)
			{
				v2f o;
				mvp = UNITY_MATRIX_MVP;
				float4x4 m = mul(mvp,sm);
				m = mul(m, rm);
				o.pos = mul(m, v.vertex);
				if(v.vertex.x < 0)
					o.color = fixed4(_SinTime.w / 2 + 0.5, _CosTime.w /2 + 0.5, _SinTime.y / 2 + 0.5, 1);
				else
					o.color = float4(0, 1, 0, 1);


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
