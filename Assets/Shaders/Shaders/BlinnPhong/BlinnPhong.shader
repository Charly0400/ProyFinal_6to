Shader "Custom/BlinnPhong"
{
    Properties
    {
        _MainTex    ("Texture", 2D)             = "white"{}
        _Color      ("Color", Color)            = (1,1,1,1)
        _SpecColor  ("Spec Color", Color)       = (1,1,1,1)
        _Spec       ("Specular", Range(0,1))    = 0.5
        _Gloss      ("Gloss", Range(0,1))       = 0.5
    }
    SubShader
    {
        Tags { "Queue" = "Geometry"}
       
        CGPROGRAM
       
        #pragma surface surf BlinnPhong

        struct Input {

            float2 uv_MainTex;
        };
        
        sampler2D _MainTex;
        float4 _Color;
        //float4 _SpecColor;
        half _Spec;
        fixed _Gloss;
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex);
            o.Specular = _Spec;
            o.Gloss = _Gloss;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
