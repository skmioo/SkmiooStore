// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

//https://www.jianshu.com/p/8006145bb01e
Shader "AUYShader/Scene/LightMap/Normal"
{
	Properties
	{
	   _MainTex("Texture", 2D) = "white" {}
	//https://blog.csdn.net/liweizhao/article/details/81937590
   //使用MaterialPropertyBlock来进行贴图设置
   //MaterialPropertyBlock mpb = new MaterialPropertyBlock();
   //mpb.SetTexture("_TargetLightMap", m_listTargetFarLMs[renderer.lightmapIndex].LightMap);
	   [PerRendererData]_TargetLightMap("Texture", 2D) = "white" {}
	}

		CGINCLUDE

#include "UnityCG.cginc"
#pragma multi_compile_fog
#pragma multi_compile __ TIMESHIFT_ON
#pragma multi_compile _ FAKE_BLOOM
		//uniform fragment跟vertex都可以用
		uniform sampler2D _MainTex;
	uniform float4 _MainTex_ST;
#ifdef TIMESHIFT_ON
	uniform sampler2D _TargetLightMap;
	uniform float _TimeShiftProgress;
#endif

//通过代码开启某个宏定义
//Shader.EnableKeyword("FAKE_BLOOM");
//通过代码检测宏是否定义
//Shader.IsKeywordEnabled("FAKE_BLOOM")
#ifdef FAKE_BLOOM
	half _FakeBloomValue;
#endif 

	struct a2v0
	{
		float4 vertex : POSITION;
		half2 texcoord0 : TEXCOORD0;
	};

	struct v2f0
	{
		half4 pos : SV_POSITION;
		half2 uv0 : TEXCOORD0;
		UNITY_FOG_COORDS(1)
	};

	v2f0 vert0(a2v0 v)
	{
		v2f0 o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv0 = v.texcoord0;
		UNITY_TRANSFER_FOG(o, o.pos);
		return o;
	}

	fixed4 frag0(v2f0 i) : SV_Target
	{
	   fixed4 col = tex2D(_MainTex, i.uv0);
	   UNITY_APPLY_FOG(i.fogCoord, col);
	   return col;
	}


		struct a2v
	{
		float4 vertex : POSITION;
		half2 texcoord0 : TEXCOORD0;
		half2 texcoord1 : TEXCOORD1;
	};

	struct v2f
	{
		half4 pos : SV_POSITION;
		half2 uv0 : TEXCOORD0;
		half2 uv1 : TEXCOORD1;
		UNITY_FOG_COORDS(2)
	};

	v2f vert(a2v v)
	{
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv0.xy = v.texcoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
		o.uv1.xy = v.texcoord1.xy * unity_LightmapST.xy + unity_LightmapST.zw;
		UNITY_TRANSFER_FOG(o, o.pos);
		return o;
	}

	fixed4 frag(v2f i) : SV_Target
	{
	   fixed4 clr = tex2D(_MainTex, i.uv0);
	   half4 lightmap = UNITY_SAMPLE_TEX2D(unity_Lightmap, i.uv1);
 #ifdef TIMESHIFT_ON
	   half4 lmTarget = tex2D(_TargetLightMap, i.uv1);
	   lightmap = lerp(lightmap, lmTarget, _TimeShiftProgress);
 #endif
	   fixed3 lightClr = DecodeLightmap(lightmap);
	   fixed4 col = fixed4(clr.rgb*lightClr*1.62, 1);

	   UNITY_APPLY_FOG(i.fogCoord, col);

 #if FAKE_BLOOM
	   col.rgb *= _FakeBloomValue;
 #endif
	   return col;
	}
		ENDCG

	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }
			Pass
		{
		   Tags
		   {
			  "LightMode" = "VertexLMRGBM"
		   }
			//BlendOp Add,Min
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}

			Pass
		{
		   Tags
		   {
			  "LightMode" = "VertexLM"
		   }
			//BlendOp Add,Min
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			ENDCG
		}


			Pass
		{
		   Tags
		   {
			  "LightMode" = "Vertex"
		   }
		   CGPROGRAM
		   #pragma vertex vert0
		   #pragma fragment frag0
		   ENDCG
		}

			Pass
		{
		   Name "ShadowCaster"
		   Tags{ "LightMode" = "ShadowCaster" }

		   CGPROGRAM
		   #pragma vertex vert
		   #pragma fragment frag
		   #pragma target 2.0
		   #pragma multi_compile_shadowcaster
		   #include "UnityCG.cginc"

		   struct v2fShadow
		   {
			  V2F_SHADOW_CASTER;
		   };

		   v2fShadow vertShadow(appdata_base v)
		   {
			  v2fShadow o;
			  TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
			  return o;
		   }

		   float4 fragShadow(v2fShadow i) : SV_Target
		   {
			  SHADOW_CASTER_FRAGMENT(i)
		   }
		   ENDCG
		}
	}
}