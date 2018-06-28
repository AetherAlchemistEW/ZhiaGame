// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ReactiveText/Boat"
{
	Properties
	{
		_MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Color) = (1,1,1,1)
		
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15

		[Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip ("Use Alpha Clip", Float) = 0
		_WaveRate("WaveRate", Float) = 0
		_WaveIntensity("WaveIntensity", Float) = 5
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent"
			"IgnoreProjector"="True"
			"RenderType"="Transparent"
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
			
		}
		
		Stencil
		{
			Ref [_Stencil]
			Comp [_StencilComp]
			Pass [_StencilOp] 
			ReadMask [_StencilReadMask]
			WriteMask [_StencilWriteMask]
		}

		Cull Off
		Lighting Off
		ZWrite Off
		ZTest [unity_GUIZTestMode]
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]

		

		Pass
		{
			Name "Default"
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 2.0

			#include "UnityCG.cginc"
			#include "UnityUI.cginc"

			#pragma multi_compile __ UNITY_UI_ALPHACLIP
			
			#include "UnityShaderVariables.cginc"

			
			struct appdata_t
			{
				float4 vertex   : POSITION;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				half2 texcoord  : TEXCOORD0;
				float4 worldPosition : TEXCOORD1;
			};
			
			uniform fixed4 _Color;
			uniform fixed4 _TextureSampleAdd;
			uniform float4 _ClipRect;
			uniform sampler2D _MainTex;
			uniform float _WaveRate;
			uniform float _WaveIntensity;
			
			v2f vert( appdata_t IN  )
			{
				v2f OUT;
				OUT.worldPosition = IN.vertex;
				float4 clipPos = UnityObjectToClipPos(IN.vertex.xyz);
				float4 screenPos = ComputeScreenPos(clipPos);
				float4 screenPos26 = screenPos;
				screenPos26.xyzw /= screenPos26.w;
				float mulTime5 = _Time.y * _WaveRate;
				float3 temp_cast_0 = (( screenPos26.y * ( sin( mulTime5 ) * _WaveIntensity ) )).xxx;
				
				OUT.worldPosition.xyz += temp_cast_0;
				OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

				OUT.texcoord = IN.texcoord;
				
				#ifdef UNITY_HALF_TEXEL_OFFSET
				OUT.vertex.xy += (_ScreenParams.zw-1.0) * float2(-1,1) * OUT.vertex.w;
				#endif
				
				OUT.color = IN.color * _Color;
				return OUT;
			}

			fixed4 frag(v2f IN  ) : SV_Target
			{
				half4 color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color;
				
				color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
				
				#ifdef UNITY_UI_ALPHACLIP
				clip (color.a - 0.001);
				#endif

				return color;
			}
		ENDCG
		}
	}
}/*ASEBEGIN
Version=13101
660;92;498;390;1212.469;522.3343;3.042176;False;False
Node;AmplifyShaderEditor.RangedFloatNode;31;-1020.151,123.2632;Float;False;Property;_WaveRate;WaveRate;1;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleTimeNode;5;-830.965,128.8234;Float;False;1;0;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;7;-684.1938,228.3802;Float;False;Property;_WaveIntensity;WaveIntensity;0;0;5;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SinOpNode;4;-622.3398,129.1607;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;6;-446.3358,167.3654;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ScreenPosInputsNode;26;-482.2591,-57.2398;Float;False;0;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-199.893,28.68153;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0,0,0,0;False;1;FLOAT
Node;AmplifyShaderEditor.TemplateMasterNode;29;14.90989,6.482277;Float;False;True;2;Float;ASEMaterialInspector;0;3;ReactiveText/Boat;5056123faa0c79b47ab6ad7e8bf059a4;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;5;0;31;0
WireConnection;4;0;5;0
WireConnection;6;0;4;0
WireConnection;6;1;7;0
WireConnection;10;0;26;2
WireConnection;10;1;6;0
WireConnection;29;1;10;0
ASEEND*/
//CHKSM=D66F17B04758C942B03EACADE319F07185667155