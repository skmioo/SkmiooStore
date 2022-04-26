// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/00_template"
{	
	properties
	{
		_Specular("Specular Color", color) = (1,1,1,1)
		_Shininess("Shininess", range(1, 64)) = 8
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

			float4 _Specular;
			float _Shininess;
			struct v2f
			{
				float4 pos : POSITION;
				fixed4 color : COLOR;
			};


			v2f vert(appdata_base v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos(v.vertex);
				//N 世界法向量
				float3 N = UnityObjectToWorldNormal(v.normal);
				//L 灯光向量
				float3 L = normalize(WorldSpaceLightDir(v.vertex));
				//V 摄像机向量
				float3 V = normalize(WorldSpaceViewDir(v.vertex));
				//H 摄像机向量跟灯光向量的半角向量
				float3 H = normalize(L + V);

				//ambient color 环境光颜色
				o.color = UNITY_LIGHTMODEL_AMBIENT;

				//diffuse color 漫反射颜色
				float ndotl = saturate(dot(N, L));
				o.color += _LightColor0 * ndotl;

				//specular color 高光颜色 pow函数，使角度越大，系数会很快的衰减，
				float specularScale = pow(saturate(dot(H, N)), _Shininess);
				o.color.rgb += _Specular * specularScale;

				return o;
			}

			fixed4 frag(in v2f IN) : COLOR
			{
				return IN.color;
			}

			ENDCG
		}
	}
}
