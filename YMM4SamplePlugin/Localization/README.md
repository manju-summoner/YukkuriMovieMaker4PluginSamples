# SampleLocalizePlugin
多言語対応プラグインのサンプルです。

# 主要クラス
## LocalizePluginクラス
プラグインの名前と`resx`の`SetCulture()`の呼び出し処理を実装します。  
`ILocalizePlugin`を実装したクラスを実装します。

## 多言語化する各種クラス
### 文字列を直接返すクラスの場合
```cs
public string Name => Resource.Name
```
### ResourceTypeを指定可能な属性の場合
```cs
[Display(Name = nameof(Resource.SamplePropertyName), Description = nameof(Resource.SamplePropertyDescription), ResourceType = typeof(Resource))]
```