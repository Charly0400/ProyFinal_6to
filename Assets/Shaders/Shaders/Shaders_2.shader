Shader "Custom/Shaderspropietates_ocomoquieras"
{
    Properties
    {
       MyColor("Color", Color) = (1,1,1,1)
       MyRange("Rango", Range(0,10)) = 1
       _MyTex("Textura", 2D) = "white"{}
       MyCube("Cubo", CUBE) = ""{}
       MyFloat("Float", Float) = 0.5
       MyVector("Vector", Vector) = (1,1,1,1)

    }
        SubShader
       {

           CGPROGRAM
           #pragma surface surf Lambert

           fixed4 MyColor;
           half MyRange;
           sampler2D _MyTex;
           samplerCUBE MyCube;
           float MyFloat;
           float4 MyVector;



           struct Input {
           float2 uv_MyTex;
           float3 worldRefl;
           };

       void surf(Input IN, inout SurfaceOutput o)
       {
           o.Albedo = tex2D(_MyTex, IN.uv_MyTex).rgb;
           o.Emission = texCUBE(MyCube, IN.worldRefl).rgb;

       }

        ENDCG
       }
           FallBack "Diffuse"
}
