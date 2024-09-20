using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    internal class PointsEditorViewModel : Bindable, IPropertyEditorControl, IDisposable
    {
        readonly INotifyPropertyChanged item;
        readonly ItemProperty[] properties;

        List<SamplePolygonShapePoint> points = [];

        public event EventHandler? BeginEdit;
        public event EventHandler? EndEdit;

        public List<SamplePolygonShapePoint> Points { get => points; set => Set(ref points, value); }
        public int SelectedIndex { get => selectedIndex; set => Set(ref selectedIndex, value); }
        int selectedIndex = 0;

        public ActionCommand AddCommand { get; }
        public ActionCommand RemoveCommand { get; }
        public ActionCommand MoveUpCommand { get; }
        public ActionCommand MoveDownCommand { get; }

        public PointsEditorViewModel(ItemProperty[] properties)
        {
            this.properties = properties;

            item = (INotifyPropertyChanged)properties[0].PropertyOwner;
            item.PropertyChanged += Item_PropertyChanged;

            AddCommand = new ActionCommand(
                _ => true,
                _ =>
                {
                    var tmpSelectedIndex = SelectedIndex;
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    var points = Points.ToList();
                    points.Insert(tmpSelectedIndex + 1, new SamplePolygonShapePoint(0, 0));
                    foreach (var property in properties)
                        property.SetValue(points.Select(x => new SamplePolygonShapePoint(x)).ToImmutableList());
                    EndEdit?.Invoke(this, EventArgs.Empty);
                    SelectedIndex = tmpSelectedIndex + 1;
                });
            RemoveCommand = new ActionCommand(
                _ => points.Count > 1,
                _ =>
                {
                    var tmpSelectedIndex = SelectedIndex;
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    var points = Points.ToList();
                    points.RemoveAt(SelectedIndex);
                    foreach (var property in properties)
                        property.SetValue(points.Select(x => new SamplePolygonShapePoint(x)).ToImmutableList());
                    EndEdit?.Invoke(this, EventArgs.Empty);
                    SelectedIndex = Math.Min(tmpSelectedIndex, points.Count - 1);
                });
            MoveUpCommand = new ActionCommand(
                _ => SelectedIndex > 0,
                _ =>
                {
                    var tmpSelectedIndex = SelectedIndex;
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    var points = Points.ToList();
                    var point = points[tmpSelectedIndex];
                    points.RemoveAt(tmpSelectedIndex);
                    points.Insert(tmpSelectedIndex - 1, point);
                    foreach (var property in properties)
                        property.SetValue(points.Select(x => new SamplePolygonShapePoint(x)).ToImmutableList());
                    EndEdit?.Invoke(this, EventArgs.Empty);
                    SelectedIndex = tmpSelectedIndex - 1;
                });
            MoveDownCommand = new ActionCommand(
                _ => SelectedIndex < points.Count - 1,
                _ =>
                {
                    var tmpSelectedIndex = SelectedIndex;
                    BeginEdit?.Invoke(this, EventArgs.Empty);
                    var points = Points.ToList();
                    var point = points[tmpSelectedIndex];
                    points.RemoveAt(tmpSelectedIndex);
                    points.Insert(tmpSelectedIndex + 1, point);
                    foreach (var property in properties)
                        property.SetValue(points.Select(x => new SamplePolygonShapePoint(x)).ToImmutableList());
                    EndEdit?.Invoke(this, EventArgs.Empty);
                    SelectedIndex = tmpSelectedIndex + 1;
                });

            UpdatePoints();
        }

        private void Item_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == properties[0].PropertyInfo.Name)
                UpdatePoints();
        }

        void UpdatePoints()
        {
            var values = properties[0].GetValue<ImmutableList<SamplePolygonShapePoint>>() ?? [];
            if (!Points.SequenceEqual(values))
            {
                Points = [.. values];
            }

            var commands = new[] { AddCommand, RemoveCommand, MoveUpCommand, MoveDownCommand };
            foreach (var command in commands)
                command.RaiseCanExecuteChanged();
        }

        public void CopyToOtherItems()
        {
            //現在のアイテムの内容を他のアイテムにコピーする
            var otherProperties = properties.Skip(1);
            foreach (var property in otherProperties)
                property.SetValue(Points.Select(x => new SamplePolygonShapePoint(x)).ToImmutableList());
        }


        public void Dispose()
        {
            item.PropertyChanged -= Item_PropertyChanged;
        }
    }
}
