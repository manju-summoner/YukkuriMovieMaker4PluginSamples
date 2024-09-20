using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Controls;

namespace YMM4SamplePlugin.Localization
{
    public class SampleClass
    {
        /// <summary>
        /// 多言語化する場合、ResourceTypeにはResourceの型を指定し、各項目にResourceのプロパティ名を指定する。
        /// </summary>
        [Display(Name = nameof(Resource.SamplePropertyName), Description = nameof(Resource.SamplePropertyDescription), ResourceType = typeof(Resource))]
        [TextBoxSlider("F0", nameof(Resource.SecUnit), -10, 10, ResourceType = typeof(Resource))]
        [DefaultValue(0)]
        [Range(0, 100)]
        public double SampleProperty { get; set; }
    }
}