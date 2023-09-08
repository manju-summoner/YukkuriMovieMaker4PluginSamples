# コントロール一覧
| クラス | 用途 | 備考 |
| --- | --- | --- | 
| AnimationSlider | アニメーション編集用のスライダー | | 
| TextBoxSlider | 数値編集用のスライダー | `[DefaultValue]`属性でデフォルト値、 `[Range]` 属性で値の範囲を指定できます。 | 
| ColorPicker | 色編集用のコントロール | | 
| DirectorySelector | ディレクトリ選択用のコントロール | | 
| FileSelector | ファイル選択用のコントロール | | 
| EnumComboBox | 列挙型選択用のコントロール | 対象のenumの各要素に`[Display(Name = "項目名", Description = "項目の説明")]`属性を追加すると、列挙型の表示名を変更できます。 | 
| FontComboBox | フォント選択用のコントロール | | 
| KeyGestureEditor | ショートカット編集用のコントロール | | 
| TextEditor | テキスト編集用のコントロール | | 
| ToggleSlider | bool値編集用のコントロール | | 

# 子プロパティ内の設定項目を表示する方法
PropertyEditorAttributeを設定するかわりに、`[Display]`に`AutoGenerateField = true`を設定します。
```cs
[Display(AutoGenerateField = true)]
public InnerClass Value { get=>... set=>... }
```

# カスタムコントロールを作成する場合
YMM4に初期搭載されているコントロール以外を使用する場合、
- IPropertyEditorControlを実装したコントロール
- PropertyEditorAttributeを継承したアイテム編集コントロール属性
の2つを実装する必要があります。