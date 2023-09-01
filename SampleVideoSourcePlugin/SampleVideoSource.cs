using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileSource;

namespace SampleVideoSourcePlugin
{
    class SampleVideoSource : IVideoFileSource
    {
        public TimeSpan Duration => TimeSpan.FromSeconds(1);
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
            output = transformEffect.Output;
        }

        public int GetFrameIndex(TimeSpan time)
        {
            return 0;
        }

        public void Update(TimeSpan time)
        {

        }

        public void Dispose()
        {
            output.Dispose();
            transformEffect.SetInput(0,null, true);
            transformEffect.Dispose();
            bitmap.Dispose();
        }
    }
}