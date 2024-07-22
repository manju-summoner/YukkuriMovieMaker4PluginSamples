using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleShapePlugin.SampleShape
{
    public class SampleShapePlugin : IShapePlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプル四角形";

        /// <summary>
        /// 図形アイテムのexo出力に対応しているかどうか
        /// </summary>
        public bool IsExoShapeSupported => true;

        /// <summary>
        /// マスク系（図形切り抜きエフェクト、エフェクトアイテム）のexo出力に対応しているかどうか
        /// </summary>
        public bool IsExoMaskSupported => true;

        /// <summary>
        /// 図形パラメーターを作成する
        /// </summary>
        /// <param name="sharedData">共有データ。図形の種類を切り替えたときに元の設定項目を復元するために必要。</param>
        /// <returns>図形パラメータ</returns>
        public IShapeParameter CreateShapeParameter(SharedDataStore? sharedData)
        {
            return new SampleShapeParameter(sharedData);
        }
    }
}