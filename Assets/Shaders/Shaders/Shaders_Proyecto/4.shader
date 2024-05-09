Shader "Custom/4"
{
    Properties
    {
        _Color    ("Color", Color)  = (1,1,1,1)
        _MainTex  ("Albedo (RGB)", 2D) = "white" {}
        _Emission    ("Emission (RGBA)", Color) = (1.0, 1.0, 1.0, 1.0)
        MyCube("Cubo", CUBE) = ""{}
    }
    SubShader
    {
        

        CGPROGRAM
       
       #pragma surface surf Lambert

        half4 _Color, _Emission;
        sampler2D _MainTex;
        samplerCUBE MyCube;

        struct Input
        {
            half2 uv_MainTex;

        };



      
        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Emission = ((o.Albedo, _Color.rgb, _Color.a)  * _Emission.rgb * _Emission.a);
            o.Emission = texCUBE(MyCube, _Color).rgb;
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex). rgb;
            o.Alpha = tex2D(_MainTex, IN.uv_MainTex).rgb ;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
