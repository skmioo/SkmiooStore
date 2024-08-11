// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/09_Model_Color2"
{	
	properties
	{
		_MainColor("Main Color", color) = (1,1,1,1)
		_SecColor("Sec Color", color) = (1,1,1,1)
		_Center("Center",range(-0.51,0.51)) = 0
		_R("R",range(0, 0.5)) = 0.2
	}

	SubShader
	{

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"

			float4 _MainColor;
			float4 _SecColor;
			float _Center;
			float _R;
			struct v2f
			{
				float4 pos : POSITION;
				float y : TEXCOORD0;
			};


			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.y = v.vertex.y;
				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{ 
				float d = IN.y - _Center;
				float s = abs(d);
				d = d / s;
				float f = s / _R;
				f = saturate(f);
				d *= f;
				d = d / 2 + 0.5;
				return lerp(_MainColor, _SecColor, d);
				/*	float d = IN.y - _Center;
				d = d / abs(d) ;
				d = d / 2 + 0.5;
				return lerp(_MainColor, _SecColor, d);*/
			}

			ENDCG
		}
	}
}
