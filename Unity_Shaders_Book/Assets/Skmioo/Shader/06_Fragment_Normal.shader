// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/06_Fragment_Normal"
{
	properties
	{
		_MainColor("Main Color", color) = (1,1,1,1)
		_Specular("Specular Color", color) = (1,1,1,1)
		_Shininess("Shininess", range(1, 64)) = 8
	}

	SubShader
	{

		Pass
		{
			Tags { "LightMode" = "ForwardBase" }
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "unitycg.cginc"
			#include "UnityLightingCommon.cginc"

			float4 _Specular;
			float _Shininess;
			float4 _MainColor;
			struct v2f 
			{
				float4 pos : POSITION;
				float3 normal : TEXCOORD0;
				float4 vertex : TEXCOORD1;
			}; 
			

			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;
				o.vertex = v.vertex;

				return o;
			}
			
			fixed4 frag(in v2f IN) : COLOR
			{
				//ambient color 环境光颜色
				fixed4 color = UNITY_LIGHTMODEL_AMBIENT;
				//N 世界法向量
				float3 N = UnityObjectToWorldNormal(IN.normal);
				//L 世界灯光向量
				float3 L = normalize(WorldSpaceLightDir(IN.vertex));

				//V 摄像机向量
				float3 V = normalize(WorldSpaceViewDir(IN.vertex));
				//H 摄像机向量跟灯光向量的半角向量
				float3 H = normalize(L + V);

				//diffuse color 漫反射颜色
				float diffuseScale = saturate(dot(N, L));
				color += _LightColor0 * diffuseScale * _MainColor;

				//specular color 高光颜色 pow函数，使角度越大，系数会很快的衰减，
				float specularScale = pow(saturate(dot(H, N)), _Shininess);
				color.rgb += _Specular * specularScale;

				//ForwardBase下4个点光源 Shade4PointLights
				float3 wpos = mul(unity_ObjectToWorld, IN.vertex).xyz;
				color.rgb += Shade4PointLights(unity_4LightPosX0, unity_4LightPosY0, unity_4LightPosZ0,
					unity_LightColor[0].rgb, unity_LightColor[1].rgb, unity_LightColor[2].rgb, unity_LightColor[3].rgb,
					unity_4LightAtten0, wpos, N);

				return color;
			}
         
            ENDCG
        }
    }
}
