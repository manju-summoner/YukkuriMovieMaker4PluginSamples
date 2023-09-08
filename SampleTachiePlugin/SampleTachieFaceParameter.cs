using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Plugin.Tachie;

namespace SampleTachiePlugin
{
    class SampleTachieFaceParameter : TachieFaceParameterBase
    {  
        /// <summary>
        /// アイテム編集エリアに表示する表情の設定項目。
        /// [Display]と[TextBoxSlider]等のアイテム編集コントロール属性の2つを設定する必要があります。
        /// [TextBoxSlider]以外のアイテム編集コントロール属性の一覧はSamplePropertyEditorsプロジェクトを参照してください。
        /// </summary>
        [Display(Name = "ファイル", Description = "立ち絵画像ファイル")]
        [FileSelectorForTachieParameter]
        public string? File { get => file; set => Set(ref file, value); }
        string? file;

        protected override IEnumerable<IAnimatable> GetAnimatables() => Enumerable.Empty<IAnimatable>();
    }
}