Shader "Custom/DotProduct"
{
    Properties
    {
        //MyColor("Color", Color) = (1,1,1,1)
        _MainTex ("Texture", 2D) = "white"{}
        _RimColor("RimColor", Color) = (0.5,.5,0)
        ColorSlider("SilderColor", Range(0,10)) = 1
    }

        SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        //sampler2D _MainTex;
        half4 MyColor;
        sampler2D _MainTex;

        struct Input
        {
          //  half2 uv_MainTex;
            float3 viewDir; //representa el vector de nuestra camara
            float2 uv_MainTex;

        };

        float4 _RimColor;
        half ColorSlider;
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            half rim = saturate(1- dot(normalize(IN.viewDir), o.Normal));
            o.Emission = _RimColor.rgb * pow(rim, ColorSlider);
         

            //----Parte1----//
            /*half dotp2 = dot(IN.viewDir, o.Emission);
            half dotp = 1 - dot(IN.viewDir, o.Normal);
            o.Albedo = float3(1, dotp, 1);
            o.Emission = (o.Albedo * MyColor.rgb);
            o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a;
            //o.Albedo = MyColor.rgb; */
            

        }
        ENDCG
    }
    FallBack "Diffuse"
}
