// Upgrade NOTE: upgraded instancing buffer 'ReactiveTextFlicker' to new syntax.

// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "ReactiveText/Flicker"
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
		_WaveMultiplier("Wave Multiplier", Float) = 1
		_TextureSample0("Texture Sample 0", 2D) = "white" {}
		_NoiseScale("Noise Scale", Vector) = (0.5,0.5,0,0)
		_NoiseMultiplier("Noise Multiplier", Float) = 1
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
			uniform sampler2D _TextureSample0;
			UNITY_INSTANCING_BUFFER_START(ReactiveTextFlicker)
				UNITY_DEFINE_INSTANCED_PROP(float, _WaveMultiplier)
#define _WaveMultiplier_arr ReactiveTextFlicker
				UNITY_DEFINE_INSTANCED_PROP(float2, _NoiseScale)
#define _NoiseScale_arr ReactiveTextFlicker
				UNITY_DEFINE_INSTANCED_PROP(float, _NoiseMultiplier)
#define _NoiseMultiplier_arr ReactiveTextFlicker
			UNITY_INSTANCING_BUFFER_END(ReactiveTextFlicker)
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
				float _WaveMultiplier_Instance = UNITY_ACCESS_INSTANCED_PROP(_WaveMultiplier_arr, _WaveMultiplier);
				float3 worldPos = mul(unity_ObjectToWorld, IN.vertex.xyz).xyz;
				float3 worldViewDir = normalize( UnityWorldSpaceViewDir( worldPos ) );
				float4 clipPos = UnityObjectToClipPos(IN.vertex.xyz);
				float4 screenPos = ComputeScreenPos(clipPos);
				float4 screenPos2 = screenPos;
				screenPos2.xyzw /= screenPos2.w;
				float simplePerlin2D9 = snoise( screenPos2.xy );
				float4 clampResult24 = clamp( ( ( sin( _Time.y ) * sin( _Time.x ) * cos( _Time.w ) ) * simplePerlin2D9 ) , float4( -1.0,0,0,0 ) , float4( 1.0,0,0,0 ) );
				float fresnelFinalVal19 = (clampResult24.x + clampResult24.x*pow( 1.0 - dot( screenPos2.xyz, worldViewDir ) , 5.0));
				float clampResult11 = clamp( fresnelFinalVal19 , -1.0 , 1.0 );
				float4 temp_cast_4 = (( _WaveMultiplier_Instance * clampResult11 )).xxxx;
				float2 _NoiseScale_Instance = UNITY_ACCESS_INSTANCED_PROP(_NoiseScale_arr, _NoiseScale);
				float2 uv31 = IN.texcoord.xy*_NoiseScale_Instance + float2( 0,0 );
				float cos43 = cos( _Time[1] );
				float sin43 = sin( _Time[1] );
				float2 rotator43 = mul((abs( uv31+_Time[1] * float2(1,1 ))) - float2( 0,0 ), float2x2(cos43,-sin43,sin43,cos43)) + float2( 0,0 );
				float _NoiseMultiplier_Instance = UNITY_ACCESS_INSTANCED_PROP(_NoiseMultiplier_arr, _NoiseMultiplier);
				
				OUT.worldPosition.xyz += step( temp_cast_4 , ( tex2Dlod( _TextureSample0, float4( rotator43, 0.0 , 0.0 ) ) * _NoiseMultiplier_Instance ) ).xyz;
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
678;92;480;390;1902.226;558.4921;4.606466;False;False
Node;AmplifyShaderEditor.TimeNode;3;-1748.521,208.0591;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinOpNode;7;-1504.615,262.4241;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.CosOpNode;6;-1502.678,349.5705;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ScreenPosInputsNode;2;-1359.335,-36.05311;Float;False;0;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinOpNode;5;-1503.576,161.4588;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.Vector2Node;35;-1222.318,316.3279;Float;False;InstancedProperty;_NoiseScale;Noise Scale;1;0;0.5,0.5;0;3;FLOAT2;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;8;-1305.435,181.0871;Float;False;3;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.NoiseGeneratorNode;9;-1105.967,65.25595;Float;False;Simplex2D;1;0;FLOAT2;0,0;False;1;FLOAT
Node;AmplifyShaderEditor.TextureCoordinatesNode;31;-1037.37,318.4201;Float;False;0;-1;2;3;2;SAMPLER2D;;False;0;FLOAT2;1,1;False;1;FLOAT2;0,0;False;5;FLOAT2;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;10;-877.5501,155.4489;Float;False;2;2;0;FLOAT4;0.0;False;1;FLOAT;0.0;False;1;FLOAT4
Node;AmplifyShaderEditor.PannerNode;32;-814.574,321.6011;Float;False;1;1;2;0;FLOAT2;0,0;False;1;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.ClampOpNode;24;-736.6915,145.0631;Float;False;3;0;FLOAT4;0.0;False;1;FLOAT4;-1.0,0,0,0;False;2;FLOAT4;1.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.RotatorNode;43;-651.3365,318.4027;Float;False;3;0;FLOAT2;0,0;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;1;FLOAT2
Node;AmplifyShaderEditor.FresnelNode;19;-579.8779,87.02324;Float;False;4;0;FLOAT3;0,0,0;False;1;FLOAT;0.0;False;2;FLOAT;1.0;False;3;FLOAT;5.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;14;-527.5693,-10.4656;Float;False;InstancedProperty;_WaveMultiplier;Wave Multiplier;0;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SamplerNode;26;-477.21,276.5069;Float;True;Property;_TextureSample0;Texture Sample 0;0;0;Assets/CREATED/Textures/noise.gif;True;0;False;white;Auto;False;Object;-1;Auto;Texture2D;6;0;SAMPLER2D;;False;1;FLOAT2;0,0;False;2;FLOAT;0.0;False;3;FLOAT2;0,0;False;4;FLOAT2;0,0;False;5;FLOAT;1.0;False;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;11;-335.8893,82.22232;Float;False;3;0;FLOAT;0.0;False;1;FLOAT;-1.0;False;2;FLOAT;1.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;37;-381.9292,471.6219;Float;False;InstancedProperty;_NoiseMultiplier;Noise Multiplier;1;0;1;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;36;-165.7049,327.1272;Float;False;2;2;0;FLOAT4;0.0;False;1;FLOAT;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.SimpleMultiplyOpNode;15;-167.8672,22.27508;Float;False;2;2;0;FLOAT;0.0;False;1;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.StepOpNode;49;-23.13417,19.58625;Float;False;2;0;FLOAT;0.0;False;1;FLOAT4;0.0,0,0,0;False;1;FLOAT4
Node;AmplifyShaderEditor.TemplateMasterNode;0;107.1397,1.430511E-06;Float;False;True;2;Float;ASEMaterialInspector;0;3;ReactiveText/Flicker;5056123faa0c79b47ab6ad7e8bf059a4;2;0;FLOAT4;0,0,0,0;False;1;FLOAT3;0,0,0;False;0
WireConnection;7;0;3;1
WireConnection;6;0;3;4
WireConnection;5;0;3;2
WireConnection;8;0;5;0
WireConnection;8;1;7;0
WireConnection;8;2;6;0
WireConnection;9;0;2;0
WireConnection;31;0;35;0
WireConnection;10;0;8;0
WireConnection;10;1;9;0
WireConnection;32;0;31;0
WireConnection;24;0;10;0
WireConnection;43;0;32;0
WireConnection;19;0;2;0
WireConnection;19;1;24;0
WireConnection;19;2;24;0
WireConnection;26;1;43;0
WireConnection;11;0;19;0
WireConnection;36;0;26;0
WireConnection;36;1;37;0
WireConnection;15;0;14;0
WireConnection;15;1;11;0
WireConnection;49;0;15;0
WireConnection;49;1;36;0
WireConnection;0;1;49;0
ASEEND*/
//CHKSM=5EDDD5A6DF1E828566FCE0693A0FBDF18D8FB13A