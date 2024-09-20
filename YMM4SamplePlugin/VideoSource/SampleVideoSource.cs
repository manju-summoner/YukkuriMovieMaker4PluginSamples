using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileSource;

namespace YMM4SamplePlugin.VideoSource
{
    class SampleVideoSource : IVideoFileSource
    {
        /// <summary>
        /// 動画の長さ
        /// </summary>
        public TimeSpan Duration => TimeSpan.FromSeconds(1);

        /// <summary>
        /// 出力映像
        /// </summary>
        public ID2D1Image Output => output;

        readonly ID2D1Bitmap bitmap;
        readonly Vortice.Direct2D1.Effects.AffineTransform2D transformEffect;
        readonly ID2D1Image output;

        public SampleVideoSource(IGraphicsDevicesAndContext devices, int width, int height)
        {
            bitmap = devices.DeviceContext.CreateEmptyBitmap(width, height);
            transformEffect = new Vortice.Direct2D1.Effects.AffineTransform2D(devices.DeviceContext);
            transformEffect.SetInput(0, bitmap, true);
            transformEffect.TransformMatrix = Matrix3x2.CreateTranslation(-bitmap.Size.Width / 2, -bitmap.Size.Height / 2);
            output = transformEffect.Output;//EffectでgetしたOutputは必ずDisposeする。Effect側では開放されない。
        }

        /// <summary>
        /// 映像を更新する
        /// </summary>
        /// <param name="time"></param>
        public void Update(TimeSpan time)
        {

        }

        /// <summary>
        /// 指定した時間のフレーム数を取得する。exo出力用。
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public int GetFrameIndex(TimeSpan time)
        {
            return 0;
        }

        public void Dispose()
        {
            output.Dispose();//EffectでgetしたOutputは必ずDisposeする。Effect側では開放されない。
            transformEffect.SetInput(0, null, true);//Inputは必ずnullに戻す。
            transformEffect.Dispose();
            bitmap.Dispose();
        }
    }
}