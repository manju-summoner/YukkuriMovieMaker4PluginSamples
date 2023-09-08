using System.Globalization;
using YukkuriMovieMaker.Plugin;

namespace SampleLocalizePlugin
{
    public class SampleLocalizePlugin : ILocalizePlugin
    {
        //多言語対応する場合、resxで多言語化した上で、ILocalizePluginを実装する。
        //YMM4起動時にSetCultureが呼ばれるので、その中でResource.Cultureを設定する。
        public string Name => Resource.PluginName;

        /// <summary>
        /// 言語を切り替える
        /// </summary>
        /// <param name="cultureInfo">切り替える言語</param>
        public void SetCulture(CultureInfo cultureInfo)
        {
            Resource.Culture = cultureInfo;
        }
    }
}