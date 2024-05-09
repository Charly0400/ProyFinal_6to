Shader "Custom/DotPruebas"
{
    Properties
    {
        _RimColor("RimColor", Color) = (0,.5,.5,0)
        _Color("Color", Color) = (1,1,1,1)
        _Color2("Color", Color) = (1,1,1,1)
        _Color3("Color", Color) = (1,1,1,1)
    }
        SubShader
    {
        CGPROGRAM
        #pragma surface surf Lambert

        struct Input
        {
            float3 viewDir; //Direcci�n de la c�mara, hacia d�nde est� apuntando la c�mara
            float3 worldPos;
        };

        float4 _RimColor;
        float4 _Color;
        float4 _Color2;
        float4 _Color3;

        void surf(Input IN, inout SurfaceOutput o)
        {
            half rim = 1 - (dot(normalize(IN.viewDir), o.Normal));
            o.Emission = frac(IN.worldPos.y * 10 * 0.5) > 0.4 ? //? es un if()
                _Color2 * rim : frac(IN.worldPos.y * 10 * 0.5) > 0.2 ? //los : son un else
                _Color * rim :_Color3;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
