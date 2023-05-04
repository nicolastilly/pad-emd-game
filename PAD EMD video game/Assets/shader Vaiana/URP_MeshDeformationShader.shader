Shader "Custom/URP_MeshDeformationShader"
{
    Properties
    {
        _BaseMap("BaseMap", 2D) = "white" {}
        _Speed("Speed", Range(0, 5)) = 1
        _Amplitude("Amplitude", Range(0, 1)) = 0.1
    }

    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Opaque" }
        LOD 100

        CGPROGRAM
        #pragma surface surf Lambert vertex:vert
        #pragma target 4.5
        #pragma exclude_renderers gles

        sampler2D _BaseMap;
        float _Speed;
        float _Amplitude;

        struct Input
        {
            float2 uv_BaseMap;
        };

        void vert(inout appdata_full v, out Input o)
        {
            float time = _Time.y * _Speed;
            float sinTime = sin(time + v.vertex.z);
            v.vertex.xyz += v.normal * sinTime * _Amplitude;
            o.uv_BaseMap = v.texcoord;
        }

        void surf(Input IN, inout SurfaceOutput o)
        {
            half4 c = tex2D(_BaseMap, IN.uv_BaseMap);
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
