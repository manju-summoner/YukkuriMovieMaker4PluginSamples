using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using YukkuriMovieMaker.Commons;

namespace SamplePropertyEditors.CustomPropertyEditor
{
    internal class IncreaseDecreaseButtonAttribute : PropertyEditorAttribute
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
        /// コントロールにバインディングを設定する
        /// </summary>
        /// <param name="control">Create()で作成したコントロール</param>
        /// <param name="item">タイムライン上に配置されているアイテムのインスタンス</param>
        /// <param name="propertyOwner">プロパティを保持しているクラスのインスタンス</param>
        /// <param name="propertyInfo">この属性が適用されているプロパティの情報</param>
        public override void SetBindings(FrameworkElement control, object item, object propertyOwner, PropertyInfo propertyInfo)
        {
            var editor = (IncreaseDecreaseButton)control;
            editor.SetBinding(IncreaseDecreaseButton.ValueProperty, new Binding(propertyInfo.Name) { Source = propertyOwner });
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
