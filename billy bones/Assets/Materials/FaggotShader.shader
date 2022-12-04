Shader "Unlit/FaggotShader"
{
	Properties
	{
		_Color("Tint", Color) = (0, 0, 0, 1)
		_MainTex("Texture", 2D) = "white" {}
		_Smoothness("Smoothness", Range(0, 1)) = 0
		_Metallic("Metalness", Range(0, 1)) = 0
		[HDR] _Emission("Emission", color) = (0,0,0)
		_MainBG("Background", 2D) = "white"{}
		_BGColor("BGColor", Color) = (0, 0, 0, 1)
		_BGSmoothness("BGSmoothness", Range(0, 1)) = 0
		_BGMetallic("BGMetalness", Range(0, 1)) = 0
		[HDR] _BGEmission("Emission", color) = (0,0,0)
	}
		SubShader
		{
			Tags {"RenderType" = "Opaque" "Queue" = "Geometry"}

			CGPROGRAM

			#pragma surface surf Standard fullforwardshadows
			#pragma target 3.0

			sampler2D _MainTex, _MainBG;
			fixed4 _Color, _BGColor;
			half _Smoothness, _BGSmoothness;
			half _Metallic, _BGMetallic;
			half3 _Emission, _BGEmission;
			struct Input
			{
				float2 uv_MainTex, uv_MainBG;
			};
			void surf(Input i, inout SurfaceOutputStandard o)
			{
				fixed4 col = tex2D(_MainTex, i.uv_MainTex);
				fixed4 bg = tex2D(_MainBG, i.uv_MainTex);
				col *= _Color;
				bg *= _BGColor;
				o.Albedo = col.rgb * col.a + (1 - col.a) * bg.rgb;
				o.Metallic = _Metallic * col.a + _BGMetallic * (1 - col.a);
				o.Smoothness = _Smoothness * col.a + _BGSmoothness * (1 - col.a);
				o.Emission = _Emission * col.a + _BGEmission * (1 - col.a);
			}
			ENDCG
		}
			FallBack "Standard"
}

