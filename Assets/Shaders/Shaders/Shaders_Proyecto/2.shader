Shader "Custom/2"
{
    Properties
    {
      _AlbedoTex ("Albedo Texture", 2D) = "white" {}
        _BumpTex ("Bump Texture", 2D) = "bump" {}
        _AlbedoColor ("Albedo Color", Color) = (1, 1, 1, 1)
        _BumpColor ("Bump Color", Color) = (1, 1, 1, 1)
        _NormalStrength ("Normal Strength", Range(0, 10)) = 1
    }
    
    SubShader
    {

        
        CGPROGRAM
        #pragma surface surf Lambert
        
        fixed4 _AlbedoColor;
        fixed4 _BumpColor;
        sampler2D _AlbedoTex;
        sampler2D _BumpTex; 
        samplerCUBE _CubeTex;
        half _NormalStrength;
        
        struct Input
        {
            float2 uv_AlbedoTex;
            float2 uv_BumpTex;

        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {

            fixed4 albedo = tex2D(_AlbedoTex, IN.uv_AlbedoTex) * _AlbedoColor;
            o.Albedo = albedo.rgb;

            fixed4 bump = tex2D(_BumpTex, IN.uv_BumpTex) * _BumpColor;
            o.Normal = UnpackNormal(bump);
            o.Normal *= _NormalStrength;
            
            o.Alpha = albedo.a;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
