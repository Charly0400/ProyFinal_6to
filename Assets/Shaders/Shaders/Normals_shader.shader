Shader "Custom/Normals_shader"
{
    Properties
    {
        
        _MyTex ("Albedo", 2D) = "white" {}
        _MyBump("Bump Texture", 2D) = "bump"{}
        //MyNormal
        Perro("Normal", Range(0,10)) = 1
        MyCube("Cubo", CUBE) = ""{}

        
    }
        SubShader
    {


        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MyTex;
        sampler2D _MyBump;
        samplerCUBE MyCube;
        half Perro;

        struct Input {
        float2 uv_MyTex;
        float2 uv_MyBump;
        float3 worldRefl; INTERNAL_DATA
        };
        
        void surf(Input IN, inout SurfaceOutput o) {
            o.Albedo = tex2D(_MyTex, IN.uv_MyTex).rgb;
            o.Normal = UnpackNormal(tex2D(_MyBump, IN.uv_MyBump));
            //o.Normal.xy *= Perro;
            o.Normal *= float3(Perro, Perro, 1);
            o.Emission = texCUBE(MyCube, IN.worldRefl).rgb;

        }



        
        ENDCG
    }
    FallBack "Diffuse"
}
