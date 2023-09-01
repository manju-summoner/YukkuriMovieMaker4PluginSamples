using YukkuriMovieMaker.Plugin.FileSource;

namespace SampleAudioSourcePlugin
{
    public class SampleAudioSourcePlugin : IAudioFileSourcePlugin
    {
        public string Name => "サンプル音声読み込みプラグイン";

        public IAudioFileSource? CreateAudioFileSource(string filePath, int audioTrackIndex)
        {
            if(Path.GetFileName(filePath) is "1khz.txt")
                return new SampleAudioSource();
            return null;
        }
    }
}