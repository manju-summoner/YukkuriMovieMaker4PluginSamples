using YukkuriMovieMaker.Plugin.Transition;

namespace SampleTransitionPlugin
{
    public class SampleTransitionPlugin : ITransitionPlugin
    {
        /// <summary>
        /// 場面切り替えの名前
        /// </summary>
        public string Name => "サンプル場面切り替え";

        /// <summary>
        /// 場面切り替えパラメーターを生成する
        /// </summary>
        /// <returns>場面切り替えパラメーター</returns>
        public ITransitionParameter CreateTransitionParameter()
        {
            return new SampleTransitionParameter();
        }
    }
}