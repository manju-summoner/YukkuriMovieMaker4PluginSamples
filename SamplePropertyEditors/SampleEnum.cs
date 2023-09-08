using System.ComponentModel.DataAnnotations;

namespace SamplePropertyEditors
{
    public enum SampleEnum
    {
        /// <summary>
        /// Display属性を設定すると、EnumComboBoxに表示される名前を変更できます。
        /// </summary>
        [Display(Name = "A", Description = "Aの説明")]
        A,
        [Display(Name = "B", Description = "Bの説明")]
        B,
        [Display(Name = "C", Description = "Cの説明")]
        C,
    }
}