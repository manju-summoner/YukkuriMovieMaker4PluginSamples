using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleVideoEffects.SampleD2DEffect
{
    internal class SampleD2DVideoEffectProcessor : IVideoEffectProcessor
    {
        readonly SampleD2DVideoEffect item;
        readonly Vortice.Direct2D1.Effects.GaussianBlur blurEffect;

        public ID2D1Image Output { get; }

        public SampleD2DVideoEffectProcessor(IGraphicsDevicesAndContext devices, SampleD2DVideoEffect item)
        {
            this.item = item;

            blurEffect = new Vortice.Direct2D1.Effects.GaussianBlur(devices.DeviceContext);
            Output = blurEffect.Output;
        }

        public void SetInput(ID2D1Image input)
        {
            blurEffect.SetInput(0, input, true);
        }

        public void ClearInput()
        {
            blurEffect.SetInput(0, null, true);
        }

        public DrawDescription Update(EffectDescription effectDescription)
        {
            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            blurEffect.StandardDeviation = (float)item.Blur.GetValue(frame,length, fps);
            return effectDescription.DrawDescription;
        }

        public void Dispose()
        {
            blurEffect.SetInput(0, null, true);
            Output.Dispose();
            blurEffect.Dispose();
        }
    }
}