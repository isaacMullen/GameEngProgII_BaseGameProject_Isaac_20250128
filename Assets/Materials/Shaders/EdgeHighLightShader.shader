Shader "Custom/LargerSquareBorder"
{
    Properties
    {
        _EdgeColor ("Edge Color", Color) = (1,0,0,1) // Red border
        _EdgeSize ("Edge Size", Range(0, 1)) = 0.5 // The size of the square relative to the screen (0 to 1)
        _BorderThickness ("Border Thickness", Range(0, 0.5)) = 0.1 // The thickness of the border outside the square
    }
    SubShader
    {
        Tags { "Queue"="Overlay" "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            // Declare properties
            float _EdgeSize;
            float _BorderThickness;
            float4 _EdgeColor;

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // Define square bounds with adjustable size and border thickness
                // The edge will extend further by making _BorderThickness larger
                float left = 0.5 - _EdgeSize * 0.5 - _BorderThickness;
                float right = 0.5 + _EdgeSize * 0.5 + _BorderThickness;
                float bottom = 0.5 - _EdgeSize * 0.5 - _BorderThickness;
                float top = 0.5 + _EdgeSize * 0.5 + _BorderThickness;

                // Check if inside the original square (not the oval shape)
                if (i.uv.x > left && i.uv.x < right && i.uv.y > bottom && i.uv.y < top)
                {
                    discard; // Remove inner part, keeping only the outer border
                }

                return _EdgeColor; // Red border color
            }
            ENDCG
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            Cull Off

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return float4(0, 0, 0, 0); // Fully transparent inside
            }
            ENDCG
        }
    }
}
