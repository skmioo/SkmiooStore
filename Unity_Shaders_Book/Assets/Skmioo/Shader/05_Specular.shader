// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skmioo/05_Specular"
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
				float3 N = normalize(v.normal);
				float3 L = normalize(_WorldSpaceLightPos0);
				N = mul(N, (float3x3)unity_WorldToObject);
				N = normalize(N);
				//diffuse color 漫反射颜色
				float ndotl = saturate(dot(N, L));
				o.color = _LightColor0 * ndotl;

				//specular color 高光颜色 
				//I:入射光 reflect函数中，入射光由灯光指向顶点 WorldSpaceLightDir得到的是顶点指向灯光
				float3 I = - WorldSpaceLightDir(v.vertex);
				//R反射光
				float3 R = reflect(I, N);
				//计算反射光跟摄像机向量直接的夹角
				float3 V = WorldSpaceViewDir(v.vertex);
				R = normalize(R);
				V = normalize(V);
				//pow函数，使角度越大，系数会很快的衰减，
				float specularScale = pow(saturate(dot(R, V)), _Shininess);
				o.color.rgb += _Specular * specularScale;
				return o;
			}
			
			fixed4 frag(in v2f IN) : COLOR
			{
				//ambient color 环境光颜色
				return IN.color + UNITY_LIGHTMODEL_AMBIENT;
			}
         
            ENDCG
        }
    }
}
