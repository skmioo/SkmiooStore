// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/03_VertexWave"
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
				//正弦函数 Asin(ωx+φ)+h		Asin(ωx+t)+h	此处x表示那个方向
				//φ（初相位）：决定波形与X轴位置关系或横向移动距离（左加右减）
				//ω：决定周期（最小正周期T = 2π/|ω | ）
				//A：决定峰值（即纵向拉伸压缩的倍数）
				//h：表示波形在Y轴的位置关系或纵向移动距离（上加下减）
				float4x4 mvp = UNITY_MATRIX_MVP;
				v2f o;
				//x方向波浪
				//v.vertex.y = sin(v.vertex.x + _Time.w);
				//z方向波浪
				//v.vertex.y += sin(v.vertex.z+ _Time.w) / 4 * 0.5;
				//xz方向波浪
				//v.vertex.y += sin(v.vertex.z+ v.vertex.x + _Time.w) / 4 * 0.5;
				//波浪方式1
				//v.vertex.y += sin(v.vertex.z * v.vertex.x + _Time.w) / 4 * 0.3;
				////圆形波
				//float dir = 1.0;
				//v.vertex.y += sin(length(v.vertex.xz) - dir * _Time.w) / 4 * 0.8;

				//波浪方式2
				v.vertex.y += sin((v.vertex.z + v.vertex.x)+ _Time.w) / 4 * 0.3;
				v.vertex.y += sin((v.vertex.z - v.vertex.x) + _Time.w) / 4 * 0.3;

				if (v.vertex.y > 0)
				{
					o.color = fixed4(1, 0, 0, 1);
				}
				else
				{
					o.color = fixed4(1, 1, 0, 1);
				}

				o.pos = mul(mvp, v.vertex);
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
