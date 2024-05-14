Shader "Custom/Shader_4"
{
     Properties
    {
        _RimColor("RimColor", Color) = (0.5,.5,0)
        _MyColor("Color", Color) = (1,1,1,1)
        _MyColor2("Color2", Color) = (1,1,1,1)
        _MyColor3("Color2", Color) = (1,1,1,1)
        _MainTex("Texture", 2D) = "white"{}
        _MyBump("Bump Texture", 2D) = "bump"{}
    }
        SubShader
    {
        CGPROGRAM

        #pragma surface surf Lambert

        struct Input
        {
            float3 viewDir;
            float3 worldPos;
            float2 uv_MainTex,uv_MyBump;
        };
        sampler2D _MainTex,_MyBump;
        float4 _RimColor;
        float4 _MyColor;
        float4 _MyColor2;
        float4 _MyColor3;
        

        void surf (Input IN, inout SurfaceOutput o)
        {
            o.Normal = UnpackNormal(tex2D(_MyBump, IN.uv_MyBump));
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;
            half _RimColor = 1.10 - (dot(normalize(IN.viewDir), o.Normal));
            o.Emission = frac(IN.worldPos.y * 10 * 0.5) > 0.6 ?
                _MyColor * (_RimColor > 0.8) : frac(IN.worldPos.y * 10 * 0.5) > 0.3 ?
                _MyColor2 * (_RimColor > 0.8) : _MyColor3 * (_RimColor > 0.8);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
