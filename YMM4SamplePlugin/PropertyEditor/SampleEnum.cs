using System.ComponentModel.DataAnnotations;

namespace YMM4SamplePlugin.PropertyEditor
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