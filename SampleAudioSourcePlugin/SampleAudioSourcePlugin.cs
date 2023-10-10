using YukkuriMovieMaker.Plugin.FileSource;
using System.IO;

namespace SampleAudioSourcePlugin
{
    public class SampleAudioSourcePlugin : IAudioFileSourcePlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプル音声読み込みプラグイン";

        /// <summary>
        /// 音声ソースを作成する
        /// </summary>
        /// <param name="filePath">ファイルパス</param>
        /// <param name="audioTrackIndex">音声トラックの番号</param>
        /// <returns>音声ソース</returns>
        public IAudioFileSource? CreateAudioFileSource(string filePath, int audioTrackIndex)
        {
            if(Path.GetFileName(filePath) is "1khz.txt")
                return new SampleAudioSource();
            return null;
        }
    }
}
