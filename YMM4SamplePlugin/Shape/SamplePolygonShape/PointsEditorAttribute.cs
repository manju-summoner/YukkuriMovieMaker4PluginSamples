using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    internal class PointsEditorAttribute : PropertyEditorAttribute2
    {
        public override FrameworkElement Create()
        {
            return new PointsEditor();
        }

        public override void SetBindings(FrameworkElement control, ItemProperty[] itemProperties)
        {
            if (control is not PointsEditor editor)
                return;
            editor.DataContext = new PointsEditorViewModel(itemProperties);
        }
        public override void ClearBindings(FrameworkElement control)
        {
            if (control is not PointsEditor editor)
                return;
            var vm = editor.DataContext as PointsEditorViewModel;
            vm?.Dispose();
            editor.DataContext = null;
        }
    }
}
