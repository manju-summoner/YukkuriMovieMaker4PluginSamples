using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.Tachie;

namespace SampleTachiePlugin
{
    public class SampleTachiePlugin : ITachiePlugin
    {
        public string Name => "サンプル立ち絵プラグイン";


        public ITachieCharacterParameter CreateCharacterParameter() => new SampleTachieCharacterParameter();

        public ITachieItemParameter CreateItemParameter() => new SampleTachieItemParameter();

        public ITachieFaceParameter CreateFaceParameter() => new SampleTachieFaceParameter();

        public IEnumerable<ExoItem> CreateExoItems(int FPS, IEnumerable<TachieItemExoDescription> tachieItemDescriptions, IEnumerable<TachieFaceItemExoDescription> faceItemDescriptions, IEnumerable<TachieVoiceItemExoDescription> voiceDescriptions)
        {
            return Enumerable.Empty<ExoItem>();
        }

        public bool HasScriptFile => false;
        public void CreateScriptFile(string scriptDirectoryPath)
        {
            
        }

        public ITachieSource CreateTachieSource(IGraphicsDevicesAndContext devices)
        {
            return new SampleTachieSource(devices);
        }
    }
}