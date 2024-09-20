using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    /// <summary>
    /// PointsEditor.xaml の相互作用ロジック
    /// </summary>
    public partial class PointsEditor : UserControl, IPropertyEditorControl
    {
        public event EventHandler? BeginEdit;
        public event EventHandler? EndEdit;

        public PointsEditor()
        {
            InitializeComponent();
            DataContextChanged += PointsEditor_DataContextChanged;
        }

        private void PointsEditor_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue is PointsEditorViewModel oldVm)
            {
                oldVm.BeginEdit -= PropertiesEditor_BeginEdit;
                oldVm.EndEdit -= PropertiesEditor_EndEdit;
            }
            if (e.NewValue is PointsEditorViewModel newVm)
            {
                newVm.BeginEdit += PropertiesEditor_BeginEdit;
                newVm.EndEdit += PropertiesEditor_EndEdit;
            }
        }

        private void PropertiesEditor_BeginEdit(object? sender, EventArgs e)
        {
            BeginEdit?.Invoke(this, e);
        }

        private void PropertiesEditor_EndEdit(object? sender, EventArgs e)
        {
            //Point内のAnimationを変更した際にPointsを更新する
            //複数のアイテムを選択している場合にすべてのアイテムを更新するために必要
            var vm = DataContext as PointsEditorViewModel;
            vm?.CopyToOtherItems();
            EndEdit?.Invoke(this, e);
        }
    }
}
