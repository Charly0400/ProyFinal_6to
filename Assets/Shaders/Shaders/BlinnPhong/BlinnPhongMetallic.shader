Shader "Custom/BlinnPhong"
{
    Properties
    {
        _Color      ("Color", Color) = (1,1,1,1)
        _MetalTex   ("Metal", 2D) = "white"{}
        _NormalMap  ("NormalMap", 2D) = "bump"{}
        _Metallic   ("Metallic", Range(0.0,1.0)) = 0.0
    }
        SubShader
        {
            Tags { "Queue" = "Geometry"}

            CGPROGRAM

            #pragma surface surf StandardSpecular //utilizar el specular con el blinnPhong

            struct Input {
                float2 uv_NormalMap;
                float2 uv_MetalTex;
            };

            sampler2D _MetalTex, _NormalMap;
            half _Metallic;
            fixed4 _Color;

            void surf(Input IN, inout SurfaceOutputStandardSpecular o)
            {

                o.Albedo = _Color.rgb;
                o.Smoothness = tex2D(_MetalTex, IN.uv_MetalTex).r; 
                o.Specular = _Metallic;
                o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));


            }
            ENDCG
        }
            FallBack "Diffuse"
}
