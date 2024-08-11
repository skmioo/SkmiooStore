Shader "URPTest/01_color"
{
	properties
	{
		_MainColor("Main Color", color) = (1,1,1,1)
	}

	SubShader
	{
		Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalRenderPipeline"}
		Pass
		{
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"    
			CBUFFER_START(UnityPerMaterial)
				half4 _MainColor;
			CBUFFER_END
			
			struct appdata
			{
				float4 pos : POSITION;
			};
			struct v2f
			{
				float4 pos : POSITION;
			};


			v2f vert(appdata v)
			{
				v2f o;
				o.pos = TransformObjectToHClip(v.pos.xyz);
				return o;
			}

			half4 frag(v2f i) : SV_Target
			{
				return _MainColor;
			}

			ENDHLSL
		}
	}
}
