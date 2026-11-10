using System.Windows;
using System.Windows.Data;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.PropertyEditor.CustomPropertyEditor
{
    /// <summary>
    /// エフェクトの ImmutableList&lt;SampleEntry&gt; のプロパティに付ける。
    /// </summary>
    /// <example>
    /// [Display(Name = "リスト")]
    /// [SampleListEditor]
    /// public ImmutableList&lt;SampleEntry&gt; Entries { get => entries; set => Set(ref entries, value); }
    /// ImmutableList&lt;SampleEntry&gt; entries = [];
    /// </example>
    public sealed class SampleListEditorAttribute : PropertyEditorAttribute2
    {
        public SampleListEditorAttribute()
        {
            PropertyEditorSize = PropertyEditorSize.FullWidth;
        }

        public override FrameworkElement Create() => new SampleListEditor();

        public override void SetBindings(FrameworkElement control, ItemProperty[] itemProperties)
        {
            if (control is not SampleListEditor editor)
                return;

            editor.ItemProperties = itemProperties;

            // 表示するのは1つ目のアイテムの値。
            // Undo/Redo でプロパティに古いリストが戻されると、この Binding が新しいリストを Entries に流す。
            var first = itemProperties[0];
            editor.SetBinding(
                SampleListEditor.EntriesProperty,
                new Binding(first.PropertyInfo.Name) { Source = first.PropertyOwner, Mode = BindingMode.OneWay });
        }

        public override void ClearBindings(FrameworkElement control)
        {
            if (control is not SampleListEditor editor)
                return;

            BindingOperations.ClearBinding(editor, SampleListEditor.EntriesProperty);
            editor.ItemProperties = null;
        }
    }
}
