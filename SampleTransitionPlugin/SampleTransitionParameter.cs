using System.ComponentModel.DataAnnotations;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Transition;
using YukkuriMovieMaker.Resources.Localization;

namespace SampleTransitionPlugin
{
    internal class SampleTransitionParameter : TransitionParameterBase
    {
        /// <summary>
        /// アイテム編集エリアに表示する音声の設定項目。
        /// [Display]と[AnimationSlider]等のアイテム編集コントロール属性の2つを設定する必要があります。
        /// [AnimationSlider]以外のアイテム編集コントロール属性の一覧はSamplePropertyEditorsプロジェクトを参照してください。
        /// </summary>
        [Display(Name = "緩急", Description = "緩急")]
        [EnumComboBox]
        public EasingType EasingType { get => easingType; set => Set(ref easingType, value); }
        EasingType easingType = EasingType.Expo;

        [Display(Name = "加減速", Description = "加減速")]
        [EnumComboBox]
        public EasingMode EasingMode { get => easingMode; set => Set(ref easingMode, value); }
        EasingMode easingMode = EasingMode.InOut;

        /// <summary>
        /// 場面切り替えソースを生成する。
        /// </summary>
        /// <param name="devices">デバイス</param>
        /// <param name="before">前の場面</param>
        /// <param name="after">後の場面</param>
        /// <returns>場面切り替えソース</returns>
        public override ITransitionSource CreateTransition(IGraphicsDevicesAndContext devices, ID2D1Image before, ID2D1Image after)
        {
            return new SampleTransitionSource(devices, before, after, this);
        }

        /// <summary>
        /// このクラス内のIAnimatableの一覧を返す。
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IAnimatable> GetAnimatables() => Enumerable.Empty<IAnimatable>();
    }
}