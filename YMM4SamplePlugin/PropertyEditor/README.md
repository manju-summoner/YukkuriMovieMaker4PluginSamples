# コントロール一覧
| クラス | 用途 | 備考 |
| --- | --- | --- | 
| [AnimationSlider](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L17-L23) | アニメーション編集用のスライダー | | 
| [TextBoxSlider](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L25-L36) | 数値編集用のスライダー | `[DefaultValue]`属性でデフォルト値、 `[Range]` 属性で値の範囲を指定できます。 | 
| [ColorPicker](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L38-L44) | 色編集用のコントロール | | 
| [DirectorySelector](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L46-L52) | ディレクトリ選択用のコントロール | | 
| [FileSelector](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L54-L60) | ファイル選択用のコントロール | | 
| [EnumComboBox](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L62-L68) | 列挙型選択用のコントロール | 対象のenumの各要素に`[Display(Name = "項目名", Description = "項目の説明")]`属性を追加すると、列挙型の表示名を変更できます。 | 
| [FontComboBox](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L70-L76) | フォント選択用のコントロール | | 
| KeyGestureEditor | ショートカット編集用のコントロール | | 
| [TextEditor](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L88-L94) | テキスト編集用のコントロール | | 
| [ToggleSlider](https://github.com/manju-summoner/YukkuriMovieMaker4PluginSamples/blob/3bb6af470d2b41263ba2b6766b95ae35ca987cef/SamplePropertyEditors/SampleParameterClass.cs#L96-L102) | bool値編集用のコントロール | | 

# 子プロパティ内の設定項目を表示する方法
PropertyEditorAttributeを設定するかわりに、`[Display]`に`AutoGenerateField = true`を設定します。
```cs
[Display(AutoGenerateField = true)]
public InnerClass Value { get=>... set=>... }
```

# カスタムコントロールを作成する場合
YMM4に初期搭載されているコントロール以外を使用する場合、

- IPropertyEditorControlを実装したコントロール
- PropertyEditorAttribute2を継承したアイテム編集コントロール属性

の2つを実装する必要があります。