// Upgrade NOTE: upgraded instancing buffer 'CoreUIPanels' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "CoreUI/Panels"
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
		_VariationIntensity("VariationIntensity", Float) = 0
		_TiledVariation("TiledVariation", 2D) = "gray" {}
		_LightMap("LightMap", 2D) = "gray" {}
		_LightIntensity("LightIntensity", Float) = 0
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
			
			#pragma multi_compile_instancing

			
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
			uniform float _VariationIntensity;
			uniform sampler2D _TiledVariation;
			uniform float4 _TiledVariation_ST;
			uniform sampler2D _LightMap;
			uniform float4 _LightMap_ST;
			UNITY_INSTANCING_BUFFER_START(CoreUIPanels)
				UNITY_DEFINE_INSTANCED_PROP(float, _LightIntensity)
#define _LightIntensity_arr CoreUIPanels
			UNITY_INSTANCING_BUFFER_END(CoreUIPanels)
			
			v2f vert( appdata_t IN  )
			{
				v2f OUT;
				OUT.worldPosition = IN.vertex;
				
				OUT.worldPosition.xyz +=  float3( 0, 0, 0 ) ;
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
				float2 uv_TiledVariation = IN.texcoord.xy*_TiledVariation_ST.xy + _TiledVariation_ST.zw;
				float2 uv_LightMap = IN.texcoord.xy*_LightMap_ST.xy + _LightMap_ST.zw;
				float _LightIntensity_Instance = UNITY_ACCESS_INSTANCED_PROP(_LightIntensity_arr, _LightIntensity);
				half4 color = (tex2D(_MainTex, uv_LightMap) * _Color );
				color += ( ( _VariationIntensity * tex2D( _TiledVariation, uv_TiledVariation ) ) * ( tex2D( _LightMap, uv_LightMap ) * _LightIntensity_Instance ));

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
678;92;480;390;855.144;606.2675;2.607281;False;False
Node;AmplifyShaderEditor.RangedFloatNode;7;-618.3018,200.8518;Float;False;InstancedProperty;_LightIntensity;LightIntensity;2;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;1;-767.5353,-230.9764;Float;True;Property;_TiledVariation;TiledVariation;0;0;None;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SamplerNode;2;-765.5005,-7.164198;Float;True;Property;_LightMap;LightMap;1;0;None;True;0;False;gray;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;6;-618.3022,-339.9478;Float;False;Property;_VariationIntensity;VariationIntensity;2;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;5;-381.5022,34.05237;Float;False;2;2;0;COLOR;0.0;False;1;FLOAT;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;4;-373.5021,-285.5476;Float;False;2;2;0;FLOAT;0.0,0,0,0;False;1;COLOR;0.0;False;1;COLOR
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;3;-228.8447,-113.3174;Float;False;2;2;0;COLOR;0.0;False;1;COLOR;0.0,0,0,0;False;1;COLOR
Node;AmplifyShaderEditor.TemplateMasterNode;0;0,0;Float;False;True;2;Float;ASEMaterialInspector;0;3;CoreUI/Panels;5056123faa0c79b47ab6ad7e8bf059a4;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;5;0;2;0
WireConnection;5;1;7;0
WireConnection;4;0;6;0
WireConnection;4;1;1;0
WireConnection;3;0;4;0
WireConnection;3;1;5;0
WireConnection;0;0;3;0
ASEEND*/
//CHKSM=11D9D1F1D89B1053DEBF74A889254B89377EE58B