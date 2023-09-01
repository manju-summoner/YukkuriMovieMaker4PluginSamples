using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileSource;

namespace SampleVideoSourcePlugin
{
    public class SampleVideoSourcePlugin : IVideoFileSourcePlugin
    {
        public string Name => "サンプル動画読み込みプラグイン";

        public IVideoFileSource? CreateVideoFileSource(IGraphicsDevicesAndContext devices, string filePath)
        {
            if(Path.GetFileName(filePath) is "fhd.txt")
                return new SampleVideoSource(devices, 1920, 1080);
            return null;
        }
    }
}