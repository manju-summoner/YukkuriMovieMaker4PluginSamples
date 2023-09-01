using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Controls;

namespace SampleLocalizePlugin
{
    public class SampleClass
    {
        [Display(Name = nameof(Resource.SamplePropertyName), Description = nameof(Resource.SamplePropertyDescription), ResourceType = typeof(Resource))]
        [TextBoxSlider("F0", nameof(Resource.SecUnit), -10, 10, ResourceType = typeof(Resource))]
        [DefaultValue(0)]
        [Range(0,100)]
        public double SampleProperty { get; set; }
    }
}