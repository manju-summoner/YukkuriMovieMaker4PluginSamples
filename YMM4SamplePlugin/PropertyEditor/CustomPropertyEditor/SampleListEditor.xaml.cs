using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using YukkuriMovieMaker.Commons;

namespace YMM4SamplePlugin.PropertyEditor.CustomPropertyEditor
{
    /// <summary>
    /// 複数選択できるリストの編集画面。
    ///
    /// Undo/Redo で選択が付いてくる仕組み:
    /// - 編集は常に「同じインスタンスを並べ替えた新しい ImmutableList」でプロパティを丸ごと差し替える
    /// - YMM4 の Undo/Redo は、そのプロパティに編集前（後）のリストを丸ごと戻す
    /// - ListBox は ItemsSource が差し替わっても、新しいリストに残っているインスタンスの選択を保つ
    /// このため、選択を移す処理は書いていない。
    /// </summary>
    public partial class SampleListEditor : UserControl, IPropertyEditorControl2
    {
        public event EventHandler? BeginEdit;
        public event EventHandler? EndEdit;

        /// <summary>タイムラインで選択中のアイテムごとのプロパティ。複数のアイテムを同時に編集するときは2つ以上になる。</summary>
        public ItemProperty[]? ItemProperties { get; set; }

        public ImmutableList<SampleEntry> Entries
        {
            get => (ImmutableList<SampleEntry>)GetValue(EntriesProperty);
            set => SetValue(EntriesProperty, value);
        }
        public static readonly DependencyProperty EntriesProperty =
            DependencyProperty.Register(
                nameof(Entries),
                typeof(ImmutableList<SampleEntry>),
                typeof(SampleListEditor),
                new PropertyMetadata(ImmutableList<SampleEntry>.Empty, (d, e) => ((SampleListEditor)d).UpdateButtons()));

        public SampleListEditor()
        {
            InitializeComponent();
            UpdateButtons();
        }

        public void SetEditorInfo(IEditorInfo? info)
        {
        }

        /// <summary>選択中の項目の位置を昇順で返す。SelectedItems は選択した順に並んでいるので並べ替える。</summary>
        List<int> GetSelectedIndices()
        {
            var entries = Entries;
            return listBox.SelectedItems
                .OfType<SampleEntry>()
                .Select(entry => entries.IndexOf(entry))
                .Where(index => index >= 0)
                .Order()
                .ToList();
        }

        /// <summary>
        /// 選択中のアイテムすべてのリストを編集する。BeginEdit～EndEdit の間の変更が1回の Undo にまとまる。
        /// edit が null を返したリストは変更しない（アイテムごとに項目数が違い、同じ位置を編集できないとき）。
        /// </summary>
        void EditAll(Func<ImmutableList<SampleEntry>, ImmutableList<SampleEntry>?> edit)
        {
            if (ItemProperties is null)
                return;

            BeginEdit?.Invoke(this, EventArgs.Empty);
            foreach (var itemProperty in ItemProperties)
            {
                var entries = itemProperty.GetValue<ImmutableList<SampleEntry>>();
                if (entries is null)
                    continue;
                var newEntries = edit(entries);
                if (newEntries is not null)
                    itemProperty.SetValue(newEntries);
            }
            EndEdit?.Invoke(this, EventArgs.Empty);
        }

        void MoveUpButton_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices();
            if (indices.Count == 0 || indices[0] == 0)
                return;

            EditAll(entries =>
            {
                if (entries.Count <= indices[^1])
                    return null;
                var builder = entries.ToBuilder();
                // 上の項目から順に1つずつ上げる。選択が飛び飛びでも、選択した項目どうしの順序は崩れない
                foreach (var index in indices)
                {
                    var entry = builder[index];
                    builder.RemoveAt(index);
                    builder.Insert(index - 1, entry);
                }
                return builder.ToImmutable();
            });
            // 選択はそのまま付いてくる。ここで SelectedItem 等を設定すると、複数選択が1つに戻ってしまう
            UpdateButtons();
        }

        void MoveDownButton_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices();
            if (indices.Count == 0 || indices[^1] == Entries.Count - 1)
                return;

            EditAll(entries =>
            {
                if (entries.Count - 1 <= indices[^1])
                    return null;
                var builder = entries.ToBuilder();
                // 下の項目から順に1つずつ下げる
                foreach (var index in Enumerable.Reverse(indices))
                {
                    var entry = builder[index];
                    builder.RemoveAt(index);
                    builder.Insert(index + 1, entry);
                }
                return builder.ToImmutable();
            });
            UpdateButtons();
        }

        void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices();
            var insertIndex = indices.Count == 0 ? Entries.Count : indices[^1] + 1;

            EditAll(entries =>
            {
                if (entries.Count < insertIndex)
                    return null;
                // アイテムごとに別のインスタンスを入れる。同じインスタンスを複数のアイテムで共有しない
                return entries.Insert(insertIndex, new SampleEntry { Name = $"項目 {DateTime.Now:HH:mm:ss}" });
            });

            // 追加した項目だけを選択する（新しい項目を選ぶのは追加の操作の意図なので、ここでは明示的に選択する）
            if (insertIndex < Entries.Count)
                listBox.SelectedItem = Entries[insertIndex];
            UpdateButtons();
        }

        void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var indices = GetSelectedIndices();
            if (indices.Count == 0)
                return;

            EditAll(entries =>
            {
                if (entries.Count <= indices[^1])
                    return null;
                var builder = entries.ToBuilder();
                foreach (var index in Enumerable.Reverse(indices))
                    builder.RemoveAt(index);
                return builder.ToImmutable();
            });

            // 削除した位置の項目を選択し直す
            var nextIndex = Math.Min(indices[0], Entries.Count - 1);
            if (nextIndex >= 0)
                listBox.SelectedItem = Entries[nextIndex];
            UpdateButtons();
        }

        void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateButtons();
        }

        void UpdateButtons()
        {
            if (listBox is null)
                return;
            var indices = GetSelectedIndices();
            removeButton.IsEnabled = indices.Count > 0;
            moveUpButton.IsEnabled = indices.Count > 0 && indices[0] > 0;
            moveDownButton.IsEnabled = indices.Count > 0 && indices[^1] < Entries.Count - 1;
        }
    }
}
