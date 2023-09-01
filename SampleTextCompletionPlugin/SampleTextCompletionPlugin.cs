using YukkuriMovieMaker.Plugin.TextCompletion;

namespace SampleTextCompletionPlugin
{
    public class SampleTextCompletionPlugin : ITextCompletionPlugin
    {
        public string Name => "サンプルAIテキスト補完プラグイン";
        public object? SettingsView => null;


        public Task<string> ProcessAsync(string systemPrompt, string text)
        {
            return Task.FromResult("補完結果");
        }
    }
}