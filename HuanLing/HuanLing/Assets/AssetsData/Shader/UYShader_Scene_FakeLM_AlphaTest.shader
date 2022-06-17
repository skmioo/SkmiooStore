// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "AUYShader/Scene/FakeLM/AlphaTest"
{
   Properties
   {
      _MainTex("Texture", 2D) = "white" {}
      _DayLightColor("Day Light Color",Color) = (1,1,1,1)
      _DayLightScale("Day Light Scale",Range(0,2)) = 1
      _NightLightColor("Night Light Color",Color) = (0.5,0.5,0.5,1)
      _NightLightScale("Night Light Scale",Range(0,2)) = 1
      _Cutoff("Alpha cutoff", Range(0,1)) = 0.5
   }

   CGINCLUDE

   #include "UnityCG.cginc"
   #pragma multi_compile_fog
   uniform sampler2D _MainTex;
   uniform float4    _MainTex_ST;
   uniform half4     _DayLightColor;
   uniform half4     _NightLightColor;
   uniform half      _Sky_LerpNightDay;
   uniform half      _DayLightScale;
   uniform half      _NightLightScale;
   uniform half      _Cutoff;

   struct a2v
   {
      half4 vertex : POSITION;
      half2 texcoord0 : TEXCOORD0;
   };

   struct v2f
   {
      half4 pos : SV_POSITION;
      half4 colorNightDay : COLOR;
      half2 uv0 : TEXCOORD0;
      UNITY_FOG_COORDS(1)
   };

   v2f vert(a2v v)
   {
      v2f o;
      o.pos = UnityObjectToClipPos(v.vertex);
      o.uv0.xy = v.texcoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
      o.colorNightDay = lerp(_NightLightColor*_NightLightScale, _DayLightColor*_DayLightScale, _Sky_LerpNightDay);
      UNITY_TRANSFER_FOG(o, o.pos);
      return o;
   }

   fixed4 frag(v2f i) : SV_Target
   {
      fixed4 col = tex2D(_MainTex, i.uv0);
      clip(col.a - _Cutoff);
      col.rgb *= i.colorNightDay.rgb;
      UNITY_APPLY_FOG(i.fogCoord, col);
      return col;
   }

   ENDCG

   SubShader
   {
      Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" }
      Pass
      {
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         ENDCG
      }
   }
}