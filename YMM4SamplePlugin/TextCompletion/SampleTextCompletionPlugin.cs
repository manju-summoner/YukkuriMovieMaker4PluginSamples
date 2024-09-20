using YukkuriMovieMaker.Plugin.TextCompletion;

namespace YMM4SamplePlugin.TextCompletion
{
    public class SampleTextCompletionPlugin : ITextCompletionPlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプルAIテキスト補完プラグイン";

        /// <summary>
        /// 設定画面。WPFのUserControl等。
        /// </summary>
        public object? SettingsView => null;

        /// <summary>
        /// AIテキスト補完を行う
        /// </summary>
        /// <param name="systemPrompt">AIに指示する内容</param>
        /// <param name="text">補完対象のテキスト</param>
        /// <returns></returns>
        public Task<string> ProcessAsync(string systemPrompt, string text)
        {
            return Task.FromResult("補完結果");
        }
    }
}