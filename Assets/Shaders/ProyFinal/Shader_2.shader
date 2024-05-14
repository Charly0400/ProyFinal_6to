Shader "Custom/Shader_2"
{
    //Normals
    Properties
    {
       _MyTex("Albedo", 2D) = "white"{}
       _NormalMap("NormalMap", 2D) = "bump" {}
       MyRange("Range",Range(0,10)) = 1
       _MyCube("Cubo", CUBE) = " " {}
    }
    SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D _MyTex;
        sampler2D _NormalMap;
        half MyRange;
        samplerCUBE _MyCube;

        struct Input 
        {
        float2 uv_NormalMap;
        float2 uv_MyTex;
        float3 worldRefl; INTERNAL_DATA
        };

        void surf(Input IN, inout SurfaceOutput o) 
        {
        o.Normal *= float3 (MyRange, MyRange, 1);
        o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
        o.Albedo = tex2D(_MyTex, IN.uv_MyTex).rgb;
        o.Emission = texCUBE(_MyCube, WorldReflectionVector(IN,o.Normal)).rgb;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
