// jave.lin 2019.06.25
Shader "Test/TestMultiCompileByShaderKeywordEnum"{
	Properties{
        // 如果在Material Inspector中设置KeywordEnum提供给用户使用的话，建议不用multi_compile定义，而用shader_feature
        // 因为在Material Inspector编辑的指令一般是确定发布后就不会变得
        // 而什么时候用multi_compile，什么时候用shader_feature呢，遵守以下几点就可以了：
        // 用shader_feature：
        // - 编辑器中使用KeywordEnum来编辑的（这是我们用的是multi_compile，测试用而已）
        // - 或是发布后确定不变得
        // 用multi_compile：
        // - 发布后，运行时，可能需要变化的，如：游戏的画面设置
        // - 通常不会在Properties定义[KeywordEnum]的方式来编辑的，因为会你项目编辑器下开发过程中，脚本中控制的关键字开关会有冲突的
        //      如：
        //          你在Unity Editor Player下运行项目，打开了游戏画面设置，会对该材质的一个关键字控制启用或禁用，然后又选中了Project视图下该材质
        //          该材质的Material Inspector显示的编辑器界面实际上有时实时的对该材质使用了[KeywordEnum]的关键字的控制启用或禁用，那么就会与你上面的脚本有冲突
		//材质 shader Keywords：
		//_HAS__
		//_Q_BEST (Best)
		//_SPECULAR_REFLECTDOTVIEW (ReflectDotView)
		[KeywordEnum(Low,Medium,High,Best)] _Q("Quality mode", Float) = 0               // 质量模式
		[KeywordEnum(ReflectDotView,HalfAngle)] _SPECULAR("Specular Model", Float) = 0  // 高光模型
        _MainTex ("Main Tex", 2D) = "white" {}                                          // 主纹理
		_Color ("Main Color", Color) = (1,1,1,1)                                        // 主色调
		_HalfLambertIntensity ("Half-Lambert Itensity", Range(0, 1)) = 0.5              // Diffuse的半Lambert强度
        _RimIntensity ("Rim Intensity", Range(0, 2)) = 0.5                              // 使用法线检测边缘光的强度
        _SpecularIntensity ("Specular Intensity", Range(0, 100)) = 1                    // 高光模型强度系数1
        _SpecularStrengthen ("Specular Strengthen", Range(0, 1)) = 1                    // 高光模型强度系数2
    }
	SubShader{
		Pass{
			Tags { "Queue" = "Opaque" "LightMode" = "ForwardBase" } // shadow setup:"LightMode"="ForwardBase"
			CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                // ====global keyword start====
				#pragma multi_compile_fwdbase 	// shadow setup:fwdbase // 这里会启用11个内置关键字
                // multi_compile_fwdbase 包含的11个内置关键字分别是：
                // DIRECTIONAL,SHADOWS_DEPTH,SHADOWS_SCREEN,
                // SHADOWS_CUBE,LIGHTMAP_ON,DIRLIGHTMAP_COMBINED,
                // DYNAMICLIGHTMAP_ON,LIGHTMAP_SHADOW_MIXING,
                // SHADOWS_SHADOWMASK,LIGHTPROBE_SH,VERTEXLIGHT_ON
                #pragma multi_compile __ AMBIENT_ON // 2个选项，定义环境光应用开关，_ 表示未选
                #pragma multi_compile __ LIGHTMODEL_AMBIENT SKY_COLOR EQUATOR_COLOR GROUND_COLOR // 5个选项，定义颜色选用的关键字
                #pragma multi_compile __ _Q_LOW _Q_MEDIUM _Q_HIGH _Q_BEST // 5个选项，定义质量选用关键字
                #pragma shader_feature __ _SPECULAR_REFLECTDOTVIEW _SPECULAR_HALFANGLE // 3个选项，定义高光模型，这里我们用shader_feaature定义
                #pragma shader_feature __ TEST TEST2 // 这两个测试的shader_feature全局关键字，只要不启用就不会有额外的变体生成下面有使用的测试代码
                // ====global keyword end====
                // ====local keyword start====
                #pragma multi_compile_local __ AMBIENT_ONLY_R // 2个选项，环境光颜色只有R通道的开关
                // 所以我们这个shader变体数量为：11*2*5*5*2*3=3300(3.3k)，但是在Shader Inspector中看到只有2.4k个，
                // 估计是否有些全局关键字是使用shader_feature的编译指令来定义的给编译优化检测未使用就剔除了
                // ====local keyword end====
                #include "UnityCG.cginc"
                #include "Lighting.cginc" 		// shadow setup:#include "Lighting.cginc"
                #if _Q_BEST
                #include "AutoLight.cginc" 		// shadow setup:#include "AutoLight.cginc"
                #endif
                struct app { float4 vertex : POSITION; float3 normal : NORMAL; float2 uv : TEXCOORD0; };
                struct v2f { float4 pos : POSITION; float3 normal : NORMAL; float3 worldPos : TEXCOORD0;
                #if _Q_BEST
                    LIGHTING_COORDS(1,2)		// shadow setup:LIGHTING_COORDS(n,n+1)
                    float2 uv : TEXCOORD3;
                #else
                    float2 uv : TEXCOORD1;
                #endif
                };
                sampler2D _MainTex;
                float4 _MainTex_ST;
				fixed4 _Color;
                float _RimIntensity;
                float _SpecularIntensity;
                float _SpecularStrengthen;
				float _HalfLambertIntensity;
				bool _HalfLambert;
                v2f vert(app v) {
                    v2f o;
                    o.pos = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    o.normal = normalize(UnityObjectToWorldNormal(v.normal));
                    o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                    #if _Q_BEST
                    TRANSFER_VERTEX_TO_FRAGMENT(o);	// shadow setup:TRANSFER_VERTEX_TO_FRAGMENT(o)
                    #endif
                    return o;
                }
                fixed4 frag(v2f v) : SV_Target{
                    _HalfLambertIntensity = 1 - _HalfLambertIntensity;
                    #if _Q_LOW
						fixed4 col = _Color * tex2D(_MainTex, v.uv);
                        #if TEST
                        col = fixed4(0,0,0,0);
                        #endif
                    #elif _Q_MEDIUM
						fixed4 col = _Color * tex2D(_MainTex, v.uv);
                        col.rgb *= dot(normalize(_WorldSpaceLightPos0.xyz), v.normal) * _HalfLambertIntensity * 0.5 + (1 - _HalfLambertIntensity) * 0.5; //halfLambert
                    #elif _Q_HIGH
						fixed4 col = _Color * tex2D(_MainTex, v.uv);
                        col.rgb *= dot(normalize(_WorldSpaceLightPos0.xyz), v.normal) * _HalfLambertIntensity * 0.5 + (1 - _HalfLambertIntensity) * 0.5; //halfLambert
                        fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - v.worldPos);
                    #elif _Q_BEST
                        half3 lightDir = normalize(_WorldSpaceLightPos0.xyz); // 这里我们只测试方向光，该变量如果是方向光的话，它的前3三分量就是方向
						fixed4 col = _Color * tex2D(_MainTex, v.uv);
                        col.rgb *= dot(lightDir, v.normal) * _HalfLambertIntensity * 0.5 + (1 - _HalfLambertIntensity) * 0.5; //halfLambert
						// 添加高光
						fixed3 viewDir = normalize(_WorldSpaceCameraPos.xyz - v.worldPos);
                        #if _SPECULAR_HALFANGLE
                            fixed3 LPlusV = lightDir + viewDir;
                            float3 reflectDir = normalize(LPlusV / dot(LPlusV, LPlusV));//normalize(LPlusV/length(LPlusV));
                        #else
						    float3 reflectDir = reflect(-lightDir, v.normal);
                        #endif
                        // 计算光照和阴影之后的阴影衰减因子
                        UNITY_LIGHT_ATTENUATION(atten, v, v.worldPos); // shadow setup:UNITY_LIGHT_ATTENUATION(atten,v,v.worldPos)
                        atten *= saturate(dot(v.normal, lightDir));
                        #if _SPECULAR_HALFANGLE
                            col.rgb += fixed3(_LightColor0.rgb * pow(dot(reflectDir, v.normal) * 0.5 + 0.5, 100 - _SpecularIntensity)) * _SpecularStrengthen * atten; // specular
                        #else
                            col.rgb += fixed3(_LightColor0.rgb * pow(dot(reflectDir, viewDir) * 0.5 + 0.5, 100 - _SpecularIntensity)) * _SpecularStrengthen * atten; // specular
                        #endif
                    #else
                        fixed4 col = _Color * tex2D(_MainTex, v.uv);
                    #endif

                    // rim light
					#if _Q_HIGH || _Q_BEST
						col.rgb += _LightColor0.rgb * (1 - max(0, dot(viewDir, v.normal))) * _RimIntensity;
					#endif

                    #if AMBIENT_ON // 判断开关而使用环境色调
                        fixed3 ambientColor;
                        #if AMBIENT_ONLY_R // 仅使用R通道的
                            #if LIGHTMODEL_AMBIENT // 光照综合处理后的系数
                            ambientColor = UNITY_LIGHTMODEL_AMBIENT.rrr;
                            #elif SKY_COLOR
                            ambientColor = unity_AmbientSky.rrr;
                            #elif EQUATOR_COLOR
                            ambientColor = unity_AmbientEquator.rrr;
                            #elif GROUND_COLOR
                            ambientColor = unity_AmbientGround.rrr;
                            #else // nops
                            #endif
                        #else
                            #if LIGHTMODEL_AMBIENT // 光照综合处理后的系数
                            ambientColor = UNITY_LIGHTMODEL_AMBIENT.rgb;
                            #elif SKY_COLOR
                            ambientColor = unity_AmbientSky.rgb;
                            #elif EQUATOR_COLOR
                            ambientColor = unity_AmbientEquator.rgb;
                            #elif GROUND_COLOR
                            ambientColor = unity_AmbientGround.rgb;
                            #else // nops
                            #endif
                        #endif
                        col.rgb += ambientColor;
                        #if _Q_BEST // 应用阴影因子
                            //col.rgb = col.rgb * atten + col.rgb * 0.5; // 后面的 * 0.5，这个值，可以去ambient的灰度值来替代，而不是写死的值，效果会好一些
                            //Gray = R*0.299 + G*0.587 + B*0.114
                            col.rgb = col.rgb * atten + col.rgb * dot(ambientColor.rgb, fixed3(0.299, 0.587, 0.114));
                        #endif
                    #else
                        #if _Q_BEST // 应用阴影因子
                            // 没有应用环境光我们就写死个0.5系数吧
                            col.rgb = col.rgb * atten + col.rgb * 0.5; // ambient的灰度值来替代，而不是写死的值，效果会好一些
                        #endif
                    #endif

					return col;
				}
            ENDCG
        }

        Pass // 投影用的pass
        {
            Tags {"LightMode"="ShadowCaster"}

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_shadowcaster
            #include "UnityCG.cginc"

            struct v2f { 
                V2F_SHADOW_CASTER;
            };

            v2f vert(appdata_base v)
            {
                v2f o;
                TRANSFER_SHADOW_CASTER_NORMALOFFSET(o)
                return o;
            }

            float4 frag(v2f i) : SV_Target
            {
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
	}
}
