using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace YMM4SamplePlugin.VideoEffect.SampleD2DVideoEffect
{
    internal class SampleD2DVideoEffectProcessor : IVideoEffectProcessor
    {
        readonly SampleD2DVideoEffect item;
        readonly Vortice.Direct2D1.Effects.GaussianBlur blurEffect;

        public ID2D1Image Output { get; }

        bool isFirst = true;
        double blur;

        public SampleD2DVideoEffectProcessor(IGraphicsDevicesAndContext devices, SampleD2DVideoEffect item)
        {
            this.item = item;

            blurEffect = new Vortice.Direct2D1.Effects.GaussianBlur(devices.DeviceContext);
            Output = blurEffect.Output;//EffectからgetしたOutputは必ずDisposeする。Effect側ではDisposeされない。
        }

        /// <summary>
        /// エフェクトに入力する映像を設定する
        /// </summary>
        /// <param name="input"></param>
        public void SetInput(ID2D1Image? input)
        {
            blurEffect.SetInput(0, input, true);
        }

        /// <summary>
        /// エフェクトに入力する映像をクリアする
        /// </summary>
        public void ClearInput()
        {
            blurEffect.SetInput(0, null, true);
        }

        /// <summary>
        /// エフェクトを更新する
        /// </summary>
        /// <param name="effectDescription">エフェクトの描画に必要な各種設定項目</param>
        /// <returns>描画関連の設定項目</returns>
        public DrawDescription Update(EffectDescription effectDescription)
        {
            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            var blur = item.Blur.GetValue(frame, length, fps);

            if (isFirst || this.blur != blur)
                blurEffect.StandardDeviation = (float)blur;

            isFirst = false;
            this.blur = blur;

            return effectDescription.DrawDescription;
        }

        public void Dispose()
        {
            blurEffect.SetInput(0, null, true);//Inputは必ずnullに戻す。
            Output.Dispose();//EffectからgetしたOutputは必ずDisposeする。Effect側ではDisposeされない。
            blurEffect.Dispose();
        }
    }
}