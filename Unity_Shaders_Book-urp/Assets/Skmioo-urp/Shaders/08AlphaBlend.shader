Shader "URPTest/08_AlphaBlend"
{
	properties
	{
  	   _MainTex ("Texture", 2D) = "white" {}
        _MaskTex("_MaskTex",2D) = "white" {}
        _BaseColor("_BaseColor",Color) = (1,1,1,1)
        _U ("U", Float ) = -1
        _V ("V", Float ) = 0 
	}

	SubShader
	{
		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent"  "Queue" = "Transparent" "IgnoreProjector" = " True"  }    //我们不希望任何投影类型材质或者贴图，影响我们的物体或者着色器
        LOD 100

		Pass
		{
		    Tags{ "LightMode"="UniversalForward" }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off

			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag
  #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            CBUFFER_START(UnityPerMaterial)
                float4 _MainTex_ST,_MaskTex_ST;
                float4 _BaseColor;
                half _U,_V;
            CBUFFER_END 


            struct appdata
            {
                float4 positionOS : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 vertexColor : COLOR;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 vertexColor : COLOR;
            };

            TEXTURE2D (_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D (_MaskTex);
            SAMPLER(sampler_MaskTex); 

		 	  v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.positionOS.xyz);
                o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.uv.zw = TRANSFORM_TEX(v.texcoord, _MaskTex);
                o.vertexColor = v.vertexColor;
                return o;
            }
            //定义一个UV速度函数
            inline half2 UVSpeed(half speedU,half speedV)
            {
                half2 uvSpeed = _Time.y * (half2(speedU,speedV));
                return uvSpeed;
			}

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = UVSpeed(_U,_V) + i.uv.xy;

                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex,uv) * _BaseColor * i.vertexColor;
                float Mask = SAMPLE_TEXTURE2D(_MaskTex,sampler_MaskTex,i.uv.zw).r;

                float alpha = Mask *  i.vertexColor.a * _BaseColor.a;

                return real4(col.xyz,alpha);
            }
            ENDHLSL 
		}
	}
}
