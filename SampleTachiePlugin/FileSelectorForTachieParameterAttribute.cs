using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using YukkuriMovieMaker.Controls;

namespace SampleTachiePlugin
{
    internal class FileSelectorForTachieParameterAttribute : YukkuriMovieMaker.Commons.PropertyEditorForTachieParameterAttribute
    {
        public override void ClearBindings(System.Windows.FrameworkElement control)
        {
            BindingOperations.ClearBinding(control, FileSelector.ValueProperty);
            BindingOperations.ClearBinding(control, FileSelector.DirectoryPathProperty);
        }

        public override System.Windows.FrameworkElement Create()
        {
            return new FileSelector();
        }

        public override void SetBindings(System.Windows.FrameworkElement control, object item, object propertyOwner, PropertyInfo propertyInfo)
        {
            var editor = (FileSelector)control;
            var cp = CharacterParameter as SampleTachieCharacterParameter;

            editor.FileType = YukkuriMovieMaker.Settings.FileType.画像;
            editor.ShowThumbnail = true;
            editor.IsDirectoryPathLocked = true;

            editor.SetBinding(FileSelector.DirectoryPathProperty, new Binding(nameof(cp.Directory)) { Source = cp });
            editor.SetBinding(FileSelector.ValueProperty, new Binding(propertyInfo.Name) { Source = propertyOwner });

        }
    }
}
