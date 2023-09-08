# ゆっくりMovieMaker4 プラグインサンプル集
## プロジェクトの作成方法
.NET7用のクラスライブラリプロジェクトを作成してください。  
### プロジェクトの設定
プロジェクトの作成後、プロジェクトファイルの`<TargetFramework>`を`net7.0-windows10.0.19041.0`に変更し、その下に`<UseWPF>true</UseWPF>`を追加してください。
```xml
<PropertyGroup>
    <TargetFramework>net7.0-windows10.0.19041.0</TargetFramework>
    <UseWPF>true</UseWPF>

    ...省略...

</PropertyGroup>
```
### 参照の追加
1. ソリューションエクスプローラーから`依存関係`を右クリックし、`プロジェクト参照の追加(R)`をクリックします。
1. 参照マネージャーウィンドウ下部の`参照(B)`ボタンをクリックします。
1. YMM4をインストールしているフォルダ内にある`YukkuriMovieMaker.Plugin.dll`と`YukkuriMovieMaker.Controls.dll`を選択し、`OK`ボタンをクリックします。
1. `OK`ボタンをクリックし、参照マネージャーを閉じます。
1. プラグインの実装中に`CS0012: 型'T' は、参照されていないアセンブリに定義されています。アセンブリ 'アセンブリ名, Version=x.x.x.x, Culture=xxx, PublicKeyToken=xxx' に参照を追加する必要があります。`とエラーが表示された場合、必要に応じてYMM4フォルダ内にある`アセンブリ名.dll`を参照に追加してください。
## プラグインの読み込み
ビルド後、`YMM4フォルダ\user\plugin\`フォルダ内に`プラグイン名フォルダ`を作成し、`プラグイン名.dll`を保存してください。  
YMM4フォルダ内に存在しないdllを読み込んでいる場合、そのdllも一緒にコピーしてください。  

プラグインが正常に読み込まれた場合、YMM4の`設定`→`プラグイン`→`プラグイン一覧`にプラグイン名が表示されます。

## サンプル一覧
### 音声読み込みプラグイン
- [SampleAudioSourcePlugin](./SampleAudioSourcePlugin/)

### 映像読み込みプラグイン
- [SampleVideoSourcePlugin](./SampleVideoSourcePlugin/)

### 画像読み込みプラグイン
- [SampleWICImageSourcePlugin](./SampleWICImageSourcePlugin/)

### 立ち絵読み込みプラグイン
- [SampleTachiePlugin](./SampleTachiePlugin/)

### 図形プラグイン（未実装。2023/10/01リリース予定）
- [SampleShapePlugin](./SampleShapePlugin/)

### 動画書き出しプラグイン
- [SampleVideoWriterPlugin](./SampleVideoWriterPlugin/)

### 音声エフェクト
- [SampleAudioEffect](./SampleAudioEffect/)

### 映像エフェクト
- [SampleVideoEffects](./SampleVideoEffects/)

### 音声合成プラグイン
- [SampleSAPI5VoicePlugin](./SampleSAPI5VoicePlugin/)

### AIテキスト補完プラグイン
- [SampleTextCompletionPlugin](./SampleTextCompletionPlugin/)

### 多言語化プラグイン
- [SampleLocalizePlugin](./SampleLocalizePlugin/)

### コントロールの一覧とカスタムコントロール
- [SamplePropertyEditors](./SamplePropertyEditors/)

アイテム編集エリアで利用できるコントロールの一覧と、カスタムコントロールのサンプルです

## リポジトリのトピック
プラグインをGitHubで公開する場合、検索性向上のためリポジトリの[Topics欄](https://docs.github.com/ja/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/classifying-your-repository-with-topics)に以下のトピックを設定することを推奨します。

| 種類 | トピック |
| --- | --- |
| 共通 | [ymm4-plugin](https://github.com/topics/ymm4-plugin) |
| 音声読み込みプラグイン | [ymm4-audio-source](https://github.com/topics/ymm4-audio-source) |
| 映像読み込みプラグイン | [ymm4-video-source](https://github.com/topics/ymm4-video-source) |
| 画像読み込みプラグイン | [ymm4-image-source](https://github.com/topics/ymm4-image-source) |
| 立ち絵プラグイン | [ymm4-tachie](https://github.com/topics/ymm4-tachie) |
| 図形プラグイン | [ymm4-shape](https://github.com/topics/ymm4-shape) |
| 動画出力プラグイン | [ymm4-video-writer](https://github.com/topics/ymm4-video-writer) |
| 音声エフェクト | [ymm4-audio-effect](https://github.com/topics/ymm4-audio-effect) |
| 映像エフェクト | [ymm4-video-effect](https://github.com/topics/ymm4-video-effect) |
| 音声合成プラグイン | [ymm4-voice](https://github.com/topics/ymm4-voice) |
| AIテキスト補完プラグイン | [ymm4-text-completion](https://github.com/topics/ymm4-text-completion) |

## X（Twitter）ハッシュタグ
プラグインをTwitterで公開する場合、検索性向上のため以下のハッシュタグを設定することを推奨します。

| 種類 | ハッシュタグ |
| --- | --- |
| 共通 | [#YMM4Plugin](https://twitter.com/search?q=%23YMM4Plugin) |