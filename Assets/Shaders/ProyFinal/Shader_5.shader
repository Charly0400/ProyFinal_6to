Shader "Custom/Shader_5"
{
         Properties
    {
       MyColor      ("Color", Color)            = (1,1,1,1)
       _NormalMap   ("NormalMap", 2D)           = "bump"{}
       _MainTex     ("DissolveMap", 2D)         = "white"{}
       _Factor		("Fresnel Factor", float)   = 0.5
	    _FPow		("Fresnel Power", float)    = 2.0
    }
        SubShader
       {

           CGPROGRAM
           #pragma surface surf Lambert

           sampler2D _NormalMap, _MainTex;
           half4 MyColor;
           half		_Factor, _FPow;



           struct Input {
           half2 uv_NormalMap, uv_MainTex;
           half3 viewDir;
           }; 

             void surf(Input IN, inout SurfaceOutput o)
            {
           o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
           half fresnel = _Factor * pow(1.0 - dot(normalize(IN.viewDir), o.Normal), _FPow);
           o.Alpha = tex2D(_MainTex, IN.uv_MainTex).a;
           o.Emission = lerp(o.Albedo, MyColor.rgb, MyColor.a) * fresnel;
           o.Albedo = tex2D(_MainTex, IN.uv_MainTex).rgb * 5;
            }

        ENDCG
       }
          FallBack "Diffuse"
}
