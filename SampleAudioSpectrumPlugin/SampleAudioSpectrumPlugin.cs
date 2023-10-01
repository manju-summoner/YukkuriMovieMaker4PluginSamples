using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleAudioSpectrumPlugin
{
    public class SampleAudioSpectrumPlugin : IAudioSpectrumPlugin
    {
        public bool IsExoShapeSupported => false;

        public bool IsExoMaskSupported => false;

        public string Name => "サンプル波形";

        public IAudioSpectrumParameter CreateAudioSpectrumParameter(SharedDataStore? sharedData)
        {
            return new SampleAudioSpectrumParameter(sharedData);
        }
    }
}