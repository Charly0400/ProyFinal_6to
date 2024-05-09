Shader "Custom/Shader_1"
{
    Properties
    {
       MyColor("Colorin", Color) = (1,1,1,1)
       MyEmission("Emission", Color) = (1,1,1,1)
       MyNormal ("Normal", Color) = (1,1,1,1)

    }
    SubShader
    {

        CGPROGRAM
        #pragma surface surf Lambert
        
        struct Input {
            float2 uvMainTex;
        };
    // Variable de baja precision, el 4 represente un array de 4 posiciones
        fixed4 MyColor;
        fixed4 MyEmission;
        fixed4 MyNormal;

        void surf(Input In, inout SurfaceOutput o)
        {
            o.Albedo = MyColor.rgb;
            //o.Albedo.b = MyColor.b = (255);
            //o.Albedo = MyColor.g;
            //o.Albedo = MyColor.b;

            o.Emission = MyEmission.xyz;
            o.Normal = MyNormal.xyz;
        }


        ENDCG
    }
    FallBack "Diffuse"
}
