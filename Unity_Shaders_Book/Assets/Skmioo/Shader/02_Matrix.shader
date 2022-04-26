// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/02_Matrix"
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
			};
			

			//模型的位置是(-0.5,-0.5) ~ (0.5, 0.5) 屏幕空间是(-1.0, -1.0) ~(1.0,1.0)
			v2f vert(appdata_base v)
			{
				v2f o;
				mvp = UNITY_MATRIX_MVP;
				//unity里从右往左的矩阵乘法
				//Matrix4x4 mvp = Camera.main.projectionMatrix * Camera.main.worldToCameraMatrix * transform.localToWorldMatrix
				//mul(UNITY_MATRIX_MVP ,v.vertex) 被自动转换为 UnityObjectToClipPos(v.vertex)
				//o.pos = UnityObjectToClipPos( v.vertex) ;
				float4x4 m = mul(mvp,sm);
				m = mul(m, rm);
				o.pos = mul(m, v.vertex);
				return o;
			}
			
			fixed4 frag(in v2f IN) : COLOR
			{
				return IN.pos;
			}
         
            ENDCG
        }
    }
}
