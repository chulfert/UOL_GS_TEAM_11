Shader "Custom/PinkTransparent"
{
    Properties
    {
        _Transparency ("Transparency", Range(0.0, 1.0)) = 0.5
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        ZWrite Off // We don't want to write to the depth buffer
        Pass
        {
            ColorMask RGB
            ZTest Less // Perform depth testing
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };
            
            struct v2f
            {
                float4 pos : SV_POSITION;
                float depth : TEXCOORD0; // Pass depth information to fragment shader
                float3 normal : TEXCOORD1; // Pass normal to fragment shader
            };
            
            float _Transparency;
            
            v2f vert(appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.depth = o.pos.z / o.pos.w; // Calculate normalized device coordinates depth
                o.normal = v.normal; // Pass normal to fragment shader
                return o;
            }
            
            half4 frag(v2f i) : SV_Target
            {
                // Check if the normal is facing upwards
                if (i.normal.y <= 0.0) discard;
                
                half4 col = half4(203.0/255.0, 29.0/255.0, 205.0/255.0, 1.0); // CB1DCD
                col.a *= _Transparency;
                return col;
            }
            ENDCG
        }
    }
}
