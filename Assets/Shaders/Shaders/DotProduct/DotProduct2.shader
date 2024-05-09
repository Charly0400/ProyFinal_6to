Shader "Custom/DotProduct2"
{
    Properties
    {
        _RimColor("RimColor", Color) = (0.5,.5,0)
        _MyColor("Color", Color) = (1,1,1,1)
        _MyColor2("Color2", Color) = (1,1,1,1)
        _MyColor3("Color2", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white"{}
    }
        SubShader
    {
        CGPROGRAM

        #pragma surface surf Lambert

        struct Input
        {
            float3 viewDir;
            float3 worldPos;
            float2 uv_MainTex;
        };
        sampler2D _MainTex;
        float4 _RimColor;
        float4 _MyColor;
        float4 _MyColor2;
        float4 _MyColor3;
        

        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            half rim = 1 - (dot(normalize(IN.viewDir), o.Normal));
            //o.Emission = rim > 0.5 ? float3(1, 0, 0): rim > 0.3 ? float3(0, 1, 0) : 0;
            //o.Emission = IN.worldPos.y > 1 ? float3(1, 0, 0) : float3(0, 0, 1);
            o.Emission = frac(IN.worldPos.y * 10 * 0.5) > 0.6 ?
                _MyColor * (rim > 0.8) : frac(IN.worldPos.y * 10 * 0.5) > 0.3 ?
                _MyColor2 * (rim > 0.8) : _MyColor3 * (rim > 0.8);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
