
            Shader "Vuforia/Built-In/TransparentAlpha" {
            Properties {
                _MainTex ("Base (RGB) Trans (A)", 2D) = "white" {}
            }

            SubShader {
                Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
                LOD 100

                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha

                Pass {
                    CGPROGRAM
                        #pragma vertex vert
                        #pragma fragment frag
                        #pragma target 2.0

                        #include "UnityCG.cginc"

                        struct appdata {
                            float4 vertex : POSITION;
                            float2 texcoord : TEXCOORD0;
                            UNITY_VERTEX_INPUT_INSTANCE_ID
                        };

                        struct v2f {
                            float4 vertex : SV_POSITION;
                            float2 texcoord : TEXCOORD0;
                            UNITY_VERTEX_OUTPUT_STEREO
                        };

                        sampler2D _MainTex;
                        float4 _MainTex_ST;

                        v2f vert (appdata v)
                        {
                            v2f o;
                            UNITY_SETUP_INSTANCE_ID(v);
                            UNITY_INITIALIZE_OUTPUT(v2f, o);
                            UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                            o.vertex = UnityObjectToClipPos(v.vertex);
                            o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                            return o;
                        }

                        fixed4 frag (v2f i) : SV_Target
                        {
                            fixed4 col = float4(1, 1, 1, tex2D(_MainTex, i.texcoord).r);

                            return col;
                        }
                    ENDCG
                }
            }

            }
            