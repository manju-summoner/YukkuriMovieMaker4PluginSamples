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
                output = effect.Output;
            }
        }

        public void ClearInput()
        {
            effect?.SetInput(0, null, true);
        }
        public void SetInput(ID2D1Image input)
        {
            this.input = input;
            effect?.SetInput(0, input, true);
        }

        public void Dispose()
        {
            output?.Dispose();
            effect?.SetInput(0, null, true);
            effect?.Dispose();
        }


        public DrawDescription Update(EffectDescription effectDescription)
        {
            if (effect is null)
                return effectDescription.DrawDescription;

            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            var value = item.Value.GetValue(frame,length,fps) / 100;

            if(isFirst || this.value != value)
                effect.Value = (float)value;

            isFirst = false;
            this.value = value;

            return effectDescription.DrawDescription;
        }
    }
}