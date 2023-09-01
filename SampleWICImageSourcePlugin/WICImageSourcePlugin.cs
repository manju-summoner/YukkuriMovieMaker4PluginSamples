using Vortice.Direct2D1;
using Vortice.WIC;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileSource;

namespace SampleWICImageSourcePlugin
{
    public class WICImageSourcePlugin : IImageFileSourcePlugin
    {
        public string Name => "サンプル画像読み込みプラグイン";

        /// <summary>
        /// 指定したファイルパスからBitmapを作成します
        /// </summary>
        /// <param name="devices">デバイス</param>
        /// <param name="filePath">読み込むファイル</param>
        /// <returns>読み込んだBitmap</returns>
        public ID2D1Bitmap? CreateBitmap(IGraphicsDevicesAndContext devices, string filePath)
        {
            try
            {
                using var factory = new IWICImagingFactory();
                using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                using var wicStream = factory.CreateStream(stream);
                using var decoder = factory.CreateDecoderFromStream(wicStream);
                using var decodedFrame = decoder.GetFrame(0);
                using var converter = factory.CreateFormatConverter();
                converter.Initialize(decodedFrame, PixelFormat.Format32bppPBGRA, BitmapDitherType.None, null, 0, BitmapPaletteType.Custom);

                return devices.DeviceContext.CreateBitmapFromWicBitmap(converter, null);
            }
            catch
            {
                return null;
            }
        }
    }
}