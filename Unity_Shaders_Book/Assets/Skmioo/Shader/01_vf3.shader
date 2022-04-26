Shader "Skmioo/vf3"
{
	properties{
	_MainColor("Main Color",color) = (1,1,1,1)
	}
		SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"
			float4 _MainColor;
	
			uniform float4 _SecondColor;
		
			struct v2f
			{
				float4 pos : POSITION;
				float2 objPos : TEXCOORD0;
				fixed4 col : COLOR;
			};

			//顶点数据 UnityCG 中存在appdata_base
			struct appdata_base2
			{
				float2 pos: POSITION;
				float4 col : COLOR;
			};

			//模型的位置是(-0.5,-0.5) ~ (0.5, 0.5) 屏幕空间是(-1.0, -1.0) ~(1.0,1.0)
			v2f vert(appdata_base2 v)
			{
				v2f o;
				o.pos = float4(v.pos, 0, 1);
				o.objPos = float2(1,0);
				o.col = v.col;
				return o;
			}
			
			fixed4 frag(in v2f IN) : COLOR
			{
				//col.y = 1;
				//return IN.col;
				//return _MainColor * _SecondColor;
				//颜色融合
				return _MainColor * 0.5f + _SecondColor * 0.5f;
			}
         
            ENDCG
        }
    }
}
