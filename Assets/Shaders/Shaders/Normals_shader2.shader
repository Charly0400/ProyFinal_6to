Shader "Custom/Normals_shader2"
{
    Properties
    {
        
        _MyTex ("Albedo", 2D) = "white" {}
        MyCube("Cubo", CUBE) = ""{}

        
    }
        SubShader
    {


        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MyTex;
        samplerCUBE MyCube;

        struct Input {
        float2 uv_MyTex;
        float3 worldRefl; INTERNAL_DATA
        };
        
        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo *= texCUBE(_MyTex, IN.uv_MyTex).rgb;
            o.Normal = 1;

        }



        
        ENDCG
    }
    FallBack "Diffuse"
}
