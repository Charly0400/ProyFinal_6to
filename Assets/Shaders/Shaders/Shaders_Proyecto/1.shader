Shader "Custom/1"
{
    Properties
    {
       MyColor("Colorin", Color) = (1,1,1,1)
       MyEmission("Emission", Color) = (1,1,1,1)
       MyNormal("Normal", Color) = (1,1,1,1)
       MyCube("Cubo", CUBE) = ""{}

    }
        SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert

        struct Input {
            float2 uvMainTex;
        };
    // Variable de baja precision, el 4 represente un array de 4 posiciones
        fixed4 MyColor, MyEmission, MyNormal;
        samplerCUBE MyCube;

        void surf(Input In, inout SurfaceOutput o)
        {
            o.Albedo = MyColor.rgb;
            //o.Albedo.b = MyColor.b = (255);
            //o.Albedo = MyColor.g;
            //o.Albedo = MyColor.b;

            o.Emission = texCUBE(MyCube, MyEmission).rgb;
            o.Normal = MyNormal.rbg;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
