using SpeechLib;
using YukkuriMovieMaker.Plugin;

namespace SampleSAPI5VoicePlugin
{
    public class SAPI5VoiceSettings : SettingsBase<SAPI5VoiceSettings>
    {
        public override SettingsCategory Category => SettingsCategory.Voice;
        //HasSettingViewがfalseの場合は実装しなくても良い
        public override string Name => throw new NotImplementedException();
        public override bool HasSettingView => false;
        public override object SettingView => throw new NotImplementedException();


        bool isCached = false;
        string[] speakers = Array.Empty<string>();
        public bool IsCached { get=> isCached; set => Set(ref isCached, value); }
        public string[] Speakers { get => speakers; set => Set(ref speakers, value); }

        public override void Initialize()
        {

        }

        public async Task UpdateSpeakersAsync()
        {
            IsCached = true;
            await Task.Run(() =>
            {
                var spVoice = new SpVoice();
                Speakers = spVoice
                    .GetVoices()
                    .Cast<ISpeechObjectToken>()
                    .Select(x => x.GetAttribute("Name"))
                    .ToArray();
            });
        }
    }
}