using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Plugin.Tachie;

namespace SampleTachiePlugin
{
    class SampleTachieFaceParameter : TachieFaceParameterBase
    {
        string? file;
        [Display(Name = "ファイル", Description = "立ち絵画像ファイル")]
        [FileSelectorForTachieParameter]
        public string? File { get => file; set => Set(ref file, value); }

        protected override IEnumerable<IAnimatable> GetAnimatables() => Enumerable.Empty<IAnimatable>();
    }
}