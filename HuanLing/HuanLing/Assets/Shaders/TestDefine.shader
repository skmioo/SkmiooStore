//https://www.jianshu.com/p/8006145bb01e
Shader "Custom/TestDefine"
{
	//点击材质球，面板设置上面的三个横线，打开Debug Shader keywords设置_TEST_B 跟_TEST_A
	//[KeywordEnum(A,B)] _TEST("TEST", Float) = 0 更改的就是Debug Shader keywords里的值
			Properties
		{
			//在属性面板中描述定义了_TEST_A _TEST_B
			//此处的名字必须按这种前后分割的规则与下面对应
			//_TEST所有字母必须大写
			//KeywordEnum（括号内的可以小写但下面必须全部大写）
			[KeywordEnum(A,B)] _TEST("TEST", Float) = 0
		}
		CGINCLUDE
			
#include "UnityCG.cginc"

	   struct a2v
	   {
		   half4 vertex : POSITION;
	   };

	   struct v2f
	   {
		   half4 pos : SV_POSITION;
	   };

	   v2f vert(a2v v)
	   {
		   v2f o;
		   o.pos = UnityObjectToClipPos(v.vertex);
		   return o;
	   }

#pragma multi_compile _TEST_A _TEST_B
	   fixed4 frag(v2f i) : SV_Target
	   {
		   #if defined (_TEST_A)
			   return fixed4(0.0,0.0,1.0,1.0);//蓝
		   #elif defined (_TEST_B)
			   return fixed4(1.0,0.0,0.0,1.0);//红
		   #else
			   return fixed4(0.0,1.0,0.0,1.0);//绿
		   #endif
	   }


		   ENDCG

		   SubShader
	   {
		   Tags{ "Queue" = "Geometry" "IgnoreProjector" = "True" }
			   Pass
		   {
			  CGPROGRAM
			  #pragma vertex vert
			  #pragma fragment frag
			  ENDCG
		   }
	   }
}