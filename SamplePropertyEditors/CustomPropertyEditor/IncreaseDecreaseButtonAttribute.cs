using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Views.Converters;

namespace SamplePropertyEditors.CustomPropertyEditor
{
    internal class IncreaseDecreaseButtonAttribute : PropertyEditorAttribute2
    {
        /// <summary>
        /// コントロールを作成する
        /// ここで返すコントロールはIPropertyEditorControlを実装している必要がある
        /// </summary>
        /// <returns></returns>
        public override FrameworkElement Create()
        {
            return new IncreaseDecreaseButton();
        }

        /// <summary>
        /// コントロールにバインディングを設定する（複数編集対応版）
        /// </summary>
        /// <param name="control">Create()で作成したコントロール</param>
        /// <param name="itemProperties">編集対象のプロパティ</param>
        public override void SetBindings(FrameworkElement control, ItemProperty[] itemProperties)
        {
            var editor = (IncreaseDecreaseButton)control;
            editor.SetBinding(IncreaseDecreaseButton.ValueProperty, ItemPropertiesBinding.Create(itemProperties));
        }

        /// <summary>
        /// バインディングを解除する
        /// </summary>
        /// <param name="control"></param>
        public override void ClearBindings(FrameworkElement control)
        {
            BindingOperations.ClearBinding(control, IncreaseDecreaseButton.ValueProperty);
        }

    }
}
