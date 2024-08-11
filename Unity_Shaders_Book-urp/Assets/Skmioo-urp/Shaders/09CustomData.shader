Shader "URPTest/09_CustomData"
{
	  Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _AlphaTex("_AlphaTex",2D) = "white" {}
        _BaseColor("_BaseColor",Color) = (1,1,1,1)

    }
    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent"  "Queue" = "Transparent" "IgnoreProjector" = " True"}    //我们不希望任何投影类型材质或者贴图，影响我们的物体或者着色器
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
                float4 _MainTex_ST,_AlphaTex_ST;
                float4 _BaseColor;
            CBUFFER_END


            struct appdata
            {
                float4 positionOS : POSITION;
                float2 texcoord : TEXCOORD0;
                float4 texcoord1: TEXCOORD1;
            };

            struct v2f
            {
                float4 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                float4 uv2 : TEXCOORD1;
            };

            TEXTURE2D (_MainTex);
            SAMPLER(sampler_MainTex);
            TEXTURE2D (_AlphaTex);
            SAMPLER(sampler_AlphaTex);

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = TransformObjectToHClip(v.positionOS.xyz);
                o.uv.xy = TRANSFORM_TEX(v.texcoord, _MainTex) ;
                o.uv.zw = TRANSFORM_TEX(v.texcoord, _AlphaTex);
                o.uv2 = v.texcoord1;
                return o;
            }

            half4 frag (v2f i) : SV_Target
            {
                float2 uv = i.uv.xy * i.uv2.xy + i.uv2.zw;
                half4 col = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex,uv) * _BaseColor;
                float alpha = SAMPLE_TEXTURE2D(_AlphaTex,sampler_AlphaTex,i.uv.zw).x;

                return real4(col.xyz,alpha);
            }
            ENDHLSL
        } 
    }
}
