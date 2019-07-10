// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

Shader "Custom/NewSurfaceShader" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_EmissionMap ("Emission Map", 2D) = "black" {}
		_EmissionFreq ("Emission Frequency", Range(0, 100)) = 0
		_EmissionOffsetPow ("Emission Offset Power", Range(0, 100)) = 0
		_EmissionSpecial("Emission effect Map", 2D) = "black" {}
		_EmissionAmp("Emission amplitude", Range(0, 1)) = 1
		
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		LOD 200

		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _EmissionMap;
		sampler2D _EmissionSpecial;

		struct Input {
			float2 uv_MainTex;
			float2 uv_EmissionMap;
			float2 uv_EmissionSpecial;

		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;
		float _EmissionFreq;
		float _EmissionOffsetPow;
		float _EmissionAmp;


		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		float glowChange(float2 UV){
		
			float4 val = tex2D(_EmissionSpecial, UV);
			//red channel - emission mask
			//green channel - emission phase offset
			return (_EmissionAmp*1.5)*((sin(_Time*_EmissionFreq + val.g*_EmissionOffsetPow)+1)/2) * val.r;


		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
			float glow = glowChange (IN.uv_EmissionSpecial);
			float3 EM = float3(glow, glow, glow);
			o.Emission =  tex2D(_EmissionMap, IN.uv_EmissionMap).rgb * EM.rgb;


		}
		ENDCG
	}
	FallBack "Diffuse"
}
