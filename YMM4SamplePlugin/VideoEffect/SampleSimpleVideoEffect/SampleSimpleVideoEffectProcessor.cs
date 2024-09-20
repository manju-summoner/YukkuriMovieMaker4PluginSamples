using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace YMM4SamplePlugin.VideoEffect.SampleSimpleVideoEffect
{
    internal class SampleSimpleVideoEffectProcessor : IVideoEffectProcessor
    {
        readonly SampleSimpleVideoEffect item;
        ID2D1Image? input;

        public ID2D1Image Output => input ?? throw new NullReferenceException(nameof(input) + "is null");

        public SampleSimpleVideoEffectProcessor(SampleSimpleVideoEffect item)
        {
            this.item = item;
        }

        /// <summary>
        /// エフェクトを更新する
        /// </summary>
        /// <param name="effectDescription">エフェクトの描画に必要な各種情報</param>
        /// <returns>描画位置等の情報</returns>
        public DrawDescription Update(EffectDescription effectDescription)
        {
            var frame = effectDescription.ItemPosition.Frame;
            var length = effectDescription.ItemDuration.Frame;
            var fps = effectDescription.FPS;

            var x = item.X.GetValue(frame, length, fps);
            var y = item.Y.GetValue(frame, length, fps);

            var drawDesc = effectDescription.DrawDescription;
            return
                drawDesc with
                {
                    Draw = new(
                    drawDesc.Draw.X + (float)x,
                    drawDesc.Draw.Y + (float)y,
                    drawDesc.Draw.Z)
                };
        }
        public void ClearInput()
        {
            input = null;
        }
        public void SetInput(ID2D1Image? input)
        {
            this.input = input;
        }

        public void Dispose()
        {

        }

    }
}