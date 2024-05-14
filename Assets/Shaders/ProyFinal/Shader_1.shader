Shader "Custom/Shader_1"
{
     Properties
    {
        MyColor("Color",color) = (1,1,1,1)
        MyRange("Range", Range(0,10)) = 1
        _MyBump("Bump Texture", 2D) = "bump"{}

        MyCube("Cube",CUBE) = ""{}
    }
        SubShader
        {

            CGPROGRAM
            #pragma surface surf Lambert

            samplerCUBE MyCube;
            sampler2D _MyBump;
            fixed4 MyColor;
            half MyRange;

        struct Input {
        float3 worldRefl;  INTERNAL_DATA
        float2 uv_MyTex, uv_MyBump;
};
       
        void surf(Input IN, inout SurfaceOutput o)
        {
            o.Normal = UnpackNormal(tex2D(_MyBump, IN.uv_MyBump) * MyRange);
            o.Emission = texCUBE(MyCube, WorldReflectionVector(IN,o.Normal)).rgb;
        }

        ENDCG
    }
    FallBack "Diffuse"
}
