using SampleVideoEffects.SampleHLSLShaderEffect;
using System.Runtime.InteropServices;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleVideoEffects.SampleD2DCustomEffect
{
    /// <summary>
    /// ID2D1Effectとして動作するカスタムエフェクト
    /// D2D1CustomShaderEffectBaseを継承する
    /// </summary>
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

        /// <summary>
        /// エフェクトの実装
        /// [CustomEffect]を設定する必要がある。inputCountは入力画像の数。
        /// </summary>
        [CustomEffect(1)]
        class EffectImpl : D2D1CustomShaderEffectImplBase<EffectImpl>
        {
            /// <summary>
            /// HLSLに渡すバッファ
            /// </summary>
            ConstantBuffer constantBuffer;

            /// <summary>
            /// エフェクトのプロパティ
            /// [CustomEffectProperty]属性でプロパティの型とIDを設定する必要がある。
            /// </summary>
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

            public EffectImpl() : base(ShaderResourceLoader.GetShaderResource("PixelShader.cso")/*ここでシェーダーのbyte列を渡す*/)
            {

            }

            /// <summary>
            /// 設定をシェーダーに渡す
            /// </summary>
            protected override void UpdateConstants()
            {
                drawInformation?.SetPixelShaderConstantBuffer(constantBuffer);
            }

            /// <summary>
            /// 入力画像の範囲から出力画像の範囲を計算する
            /// 例:
            /// 画像に対して10pxの縁取りエフェクトを掛ける場合、outputRectをinputRectsの範囲から10px大きくする
            /// 画像に対して10pxのモザイクエフェクトをかける場合、出力範囲は変わらないのでinputRects[0]をそのままoutputRectに設定する
            /// </summary>
            /// <param name="inputRects">入力画像の範囲。inputの数だけ渡される。最適化のため、入力画像の範囲がそのまま渡されるわけではなく、分割されることもある。</param>
            /// <param name="inputOpaqueSubRects">入力画像の不透明な部分の範囲。最適化のため、入力画像の範囲がそのまま渡されるわけではなく、分割されることもある。</param>
            /// <param name="outputRect">入力画像をもとに計算した出力画像の範囲。</param>
            /// <param name="outputOpaqueSubRect">入力画像を元に計算した出力画像の不透明な部分</param>
            public override void MapInputRectsToOutputRect(Vortice.RawRect[] inputRects, Vortice.RawRect[] inputOpaqueSubRects, out Vortice.RawRect outputRect, out Vortice.RawRect outputOpaqueSubRect)
            {
                base.MapInputRectsToOutputRect(inputRects, inputOpaqueSubRects, out outputRect, out outputOpaqueSubRect);
            }

            /// <summary>
            /// 出力画像を生成するために入力する必要のある入力画像の範囲を計算する
            /// 例:
            /// 画像に対して10pxの縁取りエフェクトを掛ける場合、縁取りの計算に周囲10pxの画像が必要なのでinputRects[0]をoutputRectから10px大きくしたものに設定する
            /// 画像に対して10pxのモザイクエフェクトを掛ける場合、モザイクの計算に周囲10pxの画像が必要なのでinputRects[0]をoutputRectから10px大きくしたものに設定する
            /// </summary>
            /// <param name="outputRect">出力画像の範囲。最適化のため、出力画像の範囲がそのまま渡されるわけではなく、分割されることもある。</param>
            /// <param name="inputRects">出力画像を生成するために入力する必要のある入力画像の範囲。</param>
            public override void MapOutputRectToInputRects(Vortice.RawRect outputRect, Vortice.RawRect[] inputRects)
            {
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