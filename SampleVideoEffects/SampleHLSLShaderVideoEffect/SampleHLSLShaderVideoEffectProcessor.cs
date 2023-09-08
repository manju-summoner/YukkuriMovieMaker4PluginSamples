using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleVideoEffects.SampleD2DCustomEffect
{
    internal class SampleHLSLShaderVideoEffectProcessor : IVideoEffectProcessor
    {
        readonly SampleHLSLShaderVideoEffect item;
        bool isFirst = true;
        double value;

        readonly SampleHLSLShaderCustomEffect? effect;
        readonly ID2D1Image? output;
        ID2D1Image? input;

        /// <summary>
        /// エフェクトの出力画像
        /// </summary>
        public ID2D1Image Output => output ?? input ?? throw new NullReferenceException();

        public SampleHLSLShaderVideoEffectProcessor(IGraphicsDevicesAndContext devices, SampleHLSLShaderVideoEffect item)
        {
            this.item = item;

            effect = new SampleHLSLShaderCustomEffect(devices);
            if (!effect.IsEnabled)
            {
                //GPU性能によってエフェクトの読み込みに失敗することがある
                effect.Dispose();
                effect = null;
            }
            else
            {
                output = effect.Output;//EffectからgetしたOutputは必ずDisposeする必要がある。Effect内部では開放されない。
            }
        }

        /// <summary>
        /// エフェクトの入力画像を変更する
        /// </summary>
        /// <param name="input"></param>
        public void SetInput(ID2D1Image input)
        {
            this.input = input;
            effect?.SetInput(0, input, true);
        }

        /// <summary>
        /// エフェクトの入力画像をクリアする
        /// </summary>
        public void ClearInput()
        {
            effect?.SetInput(0, null, true);
        }

        /// <summary>
        /// エフェクトを更新する
        /// </summary>
        /// <param name="effectDescription">エフェクトの描画に必要な各種情報</param>
        /// <returns>描画位置等</returns>
        public DrawDescription Update(EffectDescription effectDescription)
        {
            if (effect is null)
                return effectDescription.DrawDescription;

            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            var value = item.Value.GetValue(frame, length, fps) / 100;

            if (isFirst || this.value != value)
                effect.Value = (float)value;

            isFirst = false;
            this.value = value;

            return effectDescription.DrawDescription;
        }

        /// <summary>
        /// エフェクトの各種リソースを開放する
        /// </summary>
        public void Dispose()
        {
            output?.Dispose();//EffectからgetしたOutputは必ずDisposeする必要がある。Effect内部では開放されない。
            effect?.SetInput(0, null, true);//Inputは必ずnullに戻す。
            effect?.Dispose();
        }
    }
}