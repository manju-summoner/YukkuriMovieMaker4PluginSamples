using YukkuriMovieMaker.Plugin.Voice;

namespace YMM4SamplePlugin.Voice
{
    public class SAPI5VoicePlugin : IVoicePlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプルSAPI5プラグイン";

        /// <summary>
        /// 声質一覧
        /// IVoiceSpeakerのインスタンスは毎回作成しても良い（キャッシュする必要はない）
        /// 呼び出しごとに増減しても良い
        /// </summary>
        public IEnumerable<IVoiceSpeaker> Voices => SAPI5VoiceSettings.Default.Speakers.Select(x => new SAPI5VoiceSpeaker(x));

        /// <summary>
        /// VoicesをUpdateVoicesAsync()で更新可能な場合はtrue。固定の場合はfalse。
        /// </summary>
        public bool CanUpdateVoices => true;

        /// <summary>
        /// Voicesのキャッシュが作成されている場合はtrue。作成されていない場合はfalse。
        /// falseの場合、YMM4起動時にUpdateVoicesAsync()が呼ばれる。
        /// </summary>
        public bool IsVoicesCached => SAPI5VoiceSettings.Default.IsCached;

        /// <summary>
        /// 音声一覧を再読込する。
        /// 再読込した結果は設定ファイルに保存し、キャッシュする必要がある。
        /// </summary>
        public Task UpdateVoicesAsync() => SAPI5VoiceSettings.Default.UpdateSpeakersAsync();
    }
}