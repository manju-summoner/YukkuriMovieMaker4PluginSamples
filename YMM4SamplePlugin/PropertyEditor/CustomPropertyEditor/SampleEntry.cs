using System.Collections.Generic;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.PropertyEditor.CustomPropertyEditor
{
    /// <summary>
    /// リストの1項目。
    /// Undo/Redo の前後で同じインスタンスが使い回されることが、選択が付いてくるための前提になる。
    /// </summary>
    public class SampleEntry : Animatable
    {
        public string Name { get => name; set => Set(ref name, value); }
        string name = "";

        protected override IEnumerable<IAnimatable> GetAnimatables() => [];
    }
}
