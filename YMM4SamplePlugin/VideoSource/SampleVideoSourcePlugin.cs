using System.IO;
using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileSource;

namespace YMM4SamplePlugin.VideoSource
{
    public class SampleVideoSourcePlugin : IVideoFileSourcePlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプル動画読み込みプラグイン";

        /// <summary>
        /// 動画ソースを作成する
        /// </summary>
        /// <param name="devices">デバイス</param>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>動画ソース</returns>
        public IVideoFileSource? CreateVideoFileSource(IGraphicsDevicesAndContext devices, string filePath)
        {
            if (Path.GetFileName(filePath) is "fhd.txt")
                return new SampleVideoSource(devices, 1920, 1080);
            return null;
        }
    }
}