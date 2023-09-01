using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin;
using YukkuriMovieMaker.Plugin.Tachie;

namespace SampleTachiePlugin
{
    internal class SampleTachieSource : ITachieSource
    {
        private IGraphicsDevicesAndContext devices;

        public ID2D1Image Output => output;

        readonly ID2D1Bitmap empty;
        IImageFileSource? source;
        readonly Vortice.Direct2D1.Effects.AffineTransform2D transformEffect;
        readonly ID2D1Image output;

        bool isFirst = true;
        string? file;

        public SampleTachieSource(IGraphicsDevicesAndContext devices)
        {
            this.devices = devices;

            empty = devices.DeviceContext.CreateEmptyBitmap();
            transformEffect = new Vortice.Direct2D1.Effects.AffineTransform2D(devices.DeviceContext);
            output = transformEffect.Output;
        }
        public void Update(TimeSpan tachieTime, TimeSpan tachieLength, TimeSpan faceTime, TimeSpan faceLength, ITachieCharacterParameter characterParameter, ITachieItemParameter itemParameter, ITachieFaceParameter faceParameter, double kuchipaku)
        {
            var ip = itemParameter as SampleTachieItemParameter;
            var fp = faceParameter as SampleTachieFaceParameter;

            var file = !string.IsNullOrEmpty(fp?.File) ? fp.File : ip?.File;
            if(isFirst || this.file != file)
            {
                source?.Dispose();
                source = !string.IsNullOrEmpty(file) ? ImageFileSourceFactory.Create(devices, file) : null;
                if (source is null)
                {
                    transformEffect.SetInput(0, empty, true);
                    transformEffect.TransformMatrix = Matrix3x2.CreateTranslation(-empty.Size.Width / 2, -empty.Size.Height / 2);
                }
                else
                {
                    transformEffect.SetInput(0, source.Output, true);
                    transformEffect.TransformMatrix = Matrix3x2.CreateTranslation(-source.Output.Size.Width / 2, -source.Output.Size.Height / 2);
                }
            }
            isFirst = false;
            this.file = file;
        }

        public void Dispose()
        {
            transformEffect.SetInput(0, null, true);
            output.Dispose();
            transformEffect.Dispose();
            empty.Dispose();
            source?.Dispose();
        }
    }
}