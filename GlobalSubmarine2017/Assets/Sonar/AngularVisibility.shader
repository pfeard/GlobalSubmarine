Shader "Unlit/AngularVisibility"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_GradientTex ("Gradient Texture", 2D) = "white" {}
		_Tint ("Tint", Color) = (1,1,1,1)
		_Period ("Period", float) = 2
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert alpha
			#pragma fragment frag alpha

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
				float4 worldpos : float4;
			};

			sampler2D _MainTex;
			sampler2D _GradientTex;
			float4 _Tint;
			float _Period;
			float4 _MainTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldpos = v.vertex;
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				float gradientValue = tex2D(_GradientTex, i.uv).r;
				gradientValue = 1.0f - fmod(gradientValue + _Time.y/_Period, 1.0f);
				float opacity = pow(gradientValue, 4);
				fixed4 col = tex2D(_MainTex, i.uv) * opacity * _Tint;
	

				return col;
			}
			ENDCG
		}
	}
}
