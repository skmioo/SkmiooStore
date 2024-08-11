Shader "URPTest/07_Particle"
{
	properties
	{
  		[HDR]_BaseColor("BaseColor",Color)=(1,1,1,1)
        _TintColorAlpha ("Tint Color Alpha", Range(0,1)) = 1
		_MainTex("MainTex",2D)="White"{}
		[Toggle(Channel)] Channel("R or A", float) = 0
        _glow("_glow",Range(1.0,10)) = 1.0
		[Enum(UnityEngine.Rendering.BlendMode)] _SrcBlend("Src Blend Mode", Float) = 5
		[Enum(UnityEngine.Rendering.BlendMode)] _DstBlend("Dst Blend Mode", Float) = 1
 
	}

	SubShader
	{
		Tags{  "RenderPipeline"="UniversalRenderPipeline" "RenderType"="Transparent" "Queue"="Transparent" }
        Blend[_SrcBlend][_DstBlend]
      	Cull Off
        ZWrite Off 

		HLSLINCLUDE
		#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
		#pragma multi_compile __ Channel
		 CBUFFER_START(UnityPerMaterial)
        float4 _MainTex_ST;
        half4 _BaseColor;
        half _glow,_TintColorAlpha;
        CBUFFER_END


        TEXTURE2D (_MainTex);
        SAMPLER(sampler_MainTex);

        struct a2v
        {
             float4 positionOS:POSITION;
             float2 texcoord:TEXCOORD;
             float4 vertexColor : COLOR;

        };

        struct v2f
        {
             float4 positionCS:SV_POSITION;
             float2 texcoord:TEXCOORD;
             float4 vertexColor : COLOR;
        };
		ENDHLSL

		Pass
		{
		
			HLSLPROGRAM
			#pragma vertex vert
			#pragma fragment frag

		 	v2f vert(a2v i)
            {
                v2f o;
                o.positionCS=TransformObjectToHClip(i.positionOS.xyz);
                o.texcoord=TRANSFORM_TEX(i.texcoord,_MainTex);
                o.vertexColor = i.vertexColor;
                return o;
            }
            half4 frag(v2f i):SV_TARGET
            {
                float4 tex = SAMPLE_TEXTURE2D(_MainTex,sampler_MainTex,i.texcoord);
                float a = i.vertexColor.a * _BaseColor.a * _TintColorAlpha;

				#if Channel
					half4 col = (tex *_BaseColor * _glow) * a;
				#else
					half4 col = (tex.r * _BaseColor * _glow) * a;
				#endif
				return col;
            } 
 
			ENDHLSL
		}
	}
}
