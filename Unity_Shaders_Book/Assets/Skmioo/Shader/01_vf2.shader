Shader "Skmioo/vf2"
{
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			//模型的位置是(-0.5,-0.5) ~ (0.5, 0.5) 屏幕空间是(-1.0, -1.0) ~(1.0,1.0)
			void vert(in float2 objPos:POSITION, out float4  pos:POSITION, out float4  col : COLOR) 
			{
				pos = float4(objPos, 0, 1);
				col = pos;
			}
			
			void frag(inout float4 col:COLOR)
			{
				col.y = 1;
			}
         
            ENDCG
        }
    }
}
