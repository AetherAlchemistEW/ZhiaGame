// Upgrade NOTE: upgraded instancing buffer 'ReactiveTextUnsteady' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ReactiveText/Unsteady"
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
		_Instensity("Instensity", Float) = 4
		_ClampMinimum("Clamp Minimum", Float) = 0
		_ClampMaximum("Clamp Maximum", Float) = 0
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
			UNITY_INSTANCING_BUFFER_START(ReactiveTextUnsteady)
				UNITY_DEFINE_INSTANCED_PROP(float, _Instensity)
#define _Instensity_arr ReactiveTextUnsteady
				UNITY_DEFINE_INSTANCED_PROP(float, _ClampMinimum)
#define _ClampMinimum_arr ReactiveTextUnsteady
				UNITY_DEFINE_INSTANCED_PROP(float, _ClampMaximum)
#define _ClampMaximum_arr ReactiveTextUnsteady
			UNITY_INSTANCING_BUFFER_END(ReactiveTextUnsteady)
			float3 mod289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
			}
			
			
			v2f vert( appdata_t IN  )
			{
				v2f OUT;
				OUT.worldPosition = IN.vertex;
				float3 worldPos = mul(unity_ObjectToWorld, IN.vertex.xyz).xyz;
				float3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				float4 clipPos = UnityObjectToClipPos(IN.vertex.xyz);
				float4 screenPos = ComputeScreenPos(clipPos);
				float4 screenPos1 = screenPos;
				screenPos1.xyzw /= screenPos1.w;
				float simplePerlin2D3 = snoise( ( screenPos1 * unity_DeltaTime.w ).xy );
				float clampResult72 = clamp( ( simplePerlin2D3 * ( cos( _Time.w ) * sin( _Time.y ) * sin( _Time.x ) ) ) , -1.0 , 1.0 );
				float _Instensity_Instance = UNITY_ACCESS_INSTANCED_PROP(_Instensity_arr, _Instensity);
				float fresnelFinalVal10 = (clampResult72 + clampResult72*pow( 1.0 - dot( screenPos1.xyz, worldViewDir ) , _Instensity_Instance));
				float _ClampMinimum_Instance = UNITY_ACCESS_INSTANCED_PROP(_ClampMinimum_arr, _ClampMinimum);
				float _ClampMaximum_Instance = UNITY_ACCESS_INSTANCED_PROP(_ClampMaximum_arr, _ClampMaximum);
				float clampResult85 = clamp( fresnelFinalVal10 , _ClampMinimum_Instance , _ClampMaximum_Instance );
				float3 temp_cast_2 = (clampResult85).xxx;
				
				OUT.worldPosition.xyz += temp_cast_2;
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
678;92;480;390;333.5321;-145.3143;1;False;False
Node;AmplifyShaderEditor.ScreenPosInputsNode;1;-1210.863,-187.2924;Float;False;0;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.DeltaTime;84;-1194.875,2.651834;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.TimeNode;74;-1419.523,179.2961;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.CosOpNode;76;-1177.449,396.1945;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;83;-988.5082,-44.48097;Float;False;2;2;0;FLOAT4;0.0;False;1;FLOAT;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SinOpNode;75;-1179.386,309.048;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SinOpNode;34;-1178.346,226.1792;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;77;-980.2056,227.711;Float;False;3;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.NoiseGeneratorNode;3;-834.6415,71.66944;Float;False;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;35;-602.7607,199.8798;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;72;-456.72,182.913;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;86;-446.7252,305.9876;Float;False;InstancedProperty;_Instensity;Instensity;0;0;4;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;98;-185.3585,375.6193;Float;False;InstancedProperty;_ClampMaximum;Clamp Maximum;1;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;97;-181.9132,294.1267;Float;False;InstancedProperty;_ClampMinimum;Clamp Minimum;1;0;0;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.FresnelNode;10;-223.0261,142.201;Float;False;4;0;FLOAT3;0,0,0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;3;FLOAT;5.0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;85;164.9772,114.318;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;-3.0;False;2;FLOAT;3.0;False;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;90;-920.0212,-279.7126;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;1;FLOAT
Node;AmplifyShaderEditor.TemplateMasterNode;0;477.7634,14.05806;Float;False;True;2;Float;ASEMaterialInspector;0;3;ReactiveText/Unsteady;5056123faa0c79b47ab6ad7e8bf059a4;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;76;0;74;4
WireConnection;83;0;1;0
WireConnection;83;1;84;4
WireConnection;75;0;74;1
WireConnection;34;0;74;2
WireConnection;77;0;76;0
WireConnection;77;1;34;0
WireConnection;77;2;75;0
WireConnection;3;0;83;0
WireConnection;35;0;3;0
WireConnection;35;1;77;0
WireConnection;72;0;35;0
WireConnection;10;0;1;0
WireConnection;10;1;72;0
WireConnection;10;2;72;0
WireConnection;10;3;86;0
WireConnection;85;0;10;0
WireConnection;85;1;97;0
WireConnection;85;2;98;0
WireConnection;0;1;85;0
ASEEND*/
//CHKSM=3B0B975648AA2223386B2D8331F2B0257F0F7431