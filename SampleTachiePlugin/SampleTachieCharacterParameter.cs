using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Plugin.Tachie;
using YukkuriMovieMaker.UndoRedo;

namespace SampleTachiePlugin
{

    class SampleTachieCharacterParameter : TachieCharacterParameterBase
    {
        string? directory = null;
        [Display(Name = "フォルダ", Description = "立ち絵画像を保存しているフォルダ")]
        [DirectorySelector]
        public string? Directory { get => directory; set => Set(ref directory, value); }
    }
}