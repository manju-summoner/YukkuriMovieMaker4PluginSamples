using SpeechLib;
using YukkuriMovieMaker.Plugin;

namespace YMM4SamplePlugin.Voice
{
    /// <summary>
    /// 設定クラス
    /// Speaker一覧をキャッシュする
    /// </summary>
    public class SAPI5VoiceSettings : SettingsBase<SAPI5VoiceSettings>
    {
        /// <summary>
        /// 設定のカテゴリ
        /// ボイス設定はSettingsCategory.Voice
        /// HasSettingViewがfalseの場合は実装しなくても良い
        /// </summary>
        public override SettingsCategory Category => SettingsCategory.Voice;

        /// <summary>
        /// 設定の名前
        /// HasSettingViewがfalseの場合は実装しなくても良い
        /// </summary>
        public override string Name => throw new NotImplementedException();

        /// <summary>
        /// 設定用Viewを持つかどうか
        /// </summary>
        public override bool HasSettingView => false;

        /// <summary>
        /// 設定View (WPFのUserControl)
        /// </summary>
        public override object SettingView => throw new NotImplementedException();


        bool isCached = false;
        string[] speakers = [];
        public bool IsCached { get => isCached; set => Set(ref isCached, value); }
        public string[] Speakers { get => speakers; set => Set(ref speakers, value); }

        /// <summary>
        /// 設定の読み込み後に呼ばれる
        /// </summary>
        public override void Initialize()
        {

        }

        /// <summary>
        /// 話者一覧を更新する
        /// </summary>

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