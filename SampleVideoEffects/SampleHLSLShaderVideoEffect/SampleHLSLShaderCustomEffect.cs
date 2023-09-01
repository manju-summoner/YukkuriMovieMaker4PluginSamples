using SampleVideoEffects.SampleHLSLShaderEffect;
using System.Runtime.InteropServices;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleVideoEffects.SampleD2DCustomEffect
{
    internal class SampleHLSLShaderCustomEffect : D2D1CustomShaderEffectBase
    {
        public float Value
        {
            set => SetValue((int)EffectImpl.Properties.Value, value);
            get => GetFloatValue((int)EffectImpl.Properties.Value);
        }

        public SampleHLSLShaderCustomEffect(IGraphicsDevicesAndContext devices) : base(Create<EffectImpl>(devices)) 
        {

        }

        [CustomEffect(1)]
        class EffectImpl : D2D1CustomShaderEffectImplBase<EffectImpl>
        {
            ConstantBuffer constantBuffer;
            [CustomEffectProperty(PropertyType.Float, (int)Properties.Value)]
            public float Value
            {
                get=>constantBuffer.Value;
                set
                {
                    constantBuffer.Value = value;
                    UpdateConstants();
                }
            }

            public EffectImpl() : base(ShaderResourceLoader.GetShaderResource("PixelShader.cso"))
            {

            }

            protected override void UpdateConstants()
            {
                drawInformation?.SetPixelShaderConstantBuffer(constantBuffer);
            }

            public override void MapInputRectsToOutputRect(Vortice.RawRect[] inputRects, Vortice.RawRect[] inputOpaqueSubRects, out Vortice.RawRect outputRect, out Vortice.RawRect outputOpaqueSubRect)
            {
                //入力画像のサイズから出力画像のサイズを計算する
                //例:
                //画像に対して10pxの縁取りエフェクトを掛ける場合、outputRectをinputRectsのサイズから10px大きくする
                //画像に対して10pxのモザイクエフェクトをかける場合、出力サイズは変わらないのでinputRects[0]をそのままoutputRectに設定する
                base.MapInputRectsToOutputRect(inputRects, inputOpaqueSubRects, out outputRect, out outputOpaqueSubRect);
            }

            public override void MapOutputRectToInputRects(Vortice.RawRect outputRect, Vortice.RawRect[] inputRects)
            {
                //出力画像のサイズから、入力画像のサイズを計算する
                //例:
                //画像に対して10pxの縁取りエフェクトを掛ける場合、縁取りの計算に周囲10pxの画像が必要なのでinputRects[0]をoutputRectから10px大きくしたものに設定する
                //画像に対して10pxのモザイクエフェクトを掛ける場合、モザイクの計算に周囲10pxの画像が必要なのでinputRects[0]をoutputRectから10px大きくしたものに設定する
                base.MapOutputRectToInputRects(outputRect, inputRects);
            }

            [StructLayout(LayoutKind.Sequential)]
            struct ConstantBuffer
            {
                public float Value;
            }
            public enum Properties
            {
                Value = 0
            }
        }
    }
}