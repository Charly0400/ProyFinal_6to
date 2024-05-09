Shader "Custom/3"
{
    Properties
    {
       _Diffuse		("Diffuse Texture (RGBA)", 2D)		    = "white"{}
       _Color			("Fresnel Color (RGBA)", Color)		= (1.0, 1.0, 1.0, 1.0)
       _Emission		("Emission (RGBA)", Color)			= (1.0, 1.0, 1.0, 1.0)
       _Factor			("Fresnel Factor", float)			= 0.5
       _FPow			("Fresnel Power", float)			= 2.0
    }
    SubShader
    {
 

        CGPROGRAM
        #pragma surface surf Lambert
        sampler2D	_Diffuse, _Illumination;
		half4		_Color, _Emission;
        half		_Factor, _FPow;



        struct Input
        {
            half3 viewDir;
            half2 uv_Diffuse, uv_Illumination;
        };

        void surf (Input IN, inout SurfaceOutput o) {

            half fresnel = _Factor * pow(1.0 - dot(normalize(IN.viewDir), o.Normal), _FPow);
            o.Albedo = tex2D(_Diffuse, IN.uv_Diffuse).rgb;
			o.Emission = lerp(o.Albedo, _Color.rgb, _Color.a) * fresnel + 
				(tex2D(_Illumination, IN.uv_Illumination).a * _Emission.rgb * _Emission.a);
			o.Alpha = tex2D(_Diffuse, IN.uv_Diffuse).rgb ;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
