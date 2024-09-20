# ゆっくりMovieMaker4 プラグインサンプル集

> [!NOTE]
> YMM v4.23.0.0で.NET7から.NET8に移行したため、プロジェクトの`<TargetFramework>`を`net7.0-windows10.0.19041.0`から`net8.0-windows10.0.19041.0`に変更する必要があります。
> 以前のバージョンの情報をもとにプラグインを作成していて、`"XXX" の異なるバージョン間で、解決できない競合が見つかりました。`という警告が表示されビルドできない場合、上記の変更を適用後、`ビルド(B) → ソリューションのクリーン(C)`を実行してください。
> 詳細は[こちら](./Migration.md)

## サンプルプラグインのビルド方法
1. `Directory.Build.props.sample`をコピーし、`Directory.Build.props`として保存する
1. `Directory.Build.props`をメモ帳で開き、`YMM4DirPath`にYMM4のインストールフォルダのパスを設定する。または`YMM4DirPath`に指定されているパスにYMM4をインストールする。
1. `YMM4SamplePlugin`をビルドする
1. YMM4を起動する

## サンプルプラグインのデバッグ方法
1. `YMM4SamplePlugin`プロジェクトを右クリックし、`スタートアッププロジェクトに設定`を選択する
1. `デバッグ(D)`→`YMM4SamplePlugin のデバッグ プロパティ`を選択する
1. ウィンドウ左上の`新しいプロファイルを作成します`ボタン→`実行可能ファイル`をクリックする
1. `実行可能ファイル`欄に、`Directory.Build.props`に設定しているYMM4フォルダ内の`YukkuriMovieMaker.exe`を指定する
1. デバッグ開始ボタン`▶ YMM4SamplePlugin`右側の`▼`ボタンをクリックし、`3.`で作成したプロファイル`プロファイル 1`を選択する
1. デバッグ開始ボタンが`▶ プロファイル 1`に変わるので、ボタンをクリックしてデバッグを開始する

## 開発者モードを有効にする（v4.33.0.0以降）
YMM4の開発者モードを有効にすると、未解放のDirectXオブジェクトを検出可能になります。
1. YMM4を起動する
1. `設定`→`開発者モード`→`開発者モードを有効にする（要再起動）`を有効にする
1. YMM4を終了する

## 参照の追加方法
1. プラグインの実装中に`CS0012: 型'T' は、参照されていないアセンブリに定義されています。アセンブリ 'アセンブリ名, Version=x.x.x.x, Culture=xxx, PublicKeyToken=xxx' に参照を追加する必要があります。`とエラーが表示された場合、必要に応じてYMM4フォルダ内にある`アセンブリ名.dll`を参照に追加する必要があります。
1. プロジェクト`YMM4SamplePlugin`をダブルクリックして開き、`<ItemGroup>`内に以下のようにして参照を追加してください。（例：YukkuriMovieMaker.Plugin.dllの場合。追加したいDLLの名前に合わせてIncludeとReferenceを変更する）
```xml
<Reference Include="YukkuriMovieMaker.Plugin">
	<HintPath>$(YMM4DirPath)YukkuriMovieMaker.Plugin.dll</HintPath>
</Reference>
```

## プラグインの読み込み
ビルド後、`YMM4フォルダ\user\plugin\`フォルダ内にプラグインのdllファイルがコピーされます。
プラグインが正常に読み込まれた場合、YMM4の`設定`→`プラグイン`→`プラグイン一覧`にプラグイン名が表示されます。

## プラグインの配布用パッケージ化
プラグインを`.ymme`形式で配布することにより、ワンクリックでプラグインをインストールできるようになります。
1. 作成したプラグインをzipで圧縮する
1. zipファイルの拡張子を`.ymme`に変更する
1. `.ymme`ファイルを配布する

## このプロジェクトを元にプラグインを新規開発する場合
1. このページ内の`サンプルプラグインのビルド方法`および`サンプルプラグインのデバッグ方法`の項目を実行する
1. YMM4SamplePluginのプロジェクトファイルを開き、`<!--ここから-->`～`<!--ここまで-->`の部分を削除する
1. 

## プラグインの種類一覧
- [作成可能なプラグインの一覧](./YMM4SamplePlugin/)

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
| 波形プラグイン | [ymm4-audio-spectrum](https://github.com/topics/ymm4-audio-spectrum) |
| 動画出力プラグイン | [ymm4-video-writer](https://github.com/topics/ymm4-video-writer) |
| 音声エフェクト | [ymm4-audio-effect](https://github.com/topics/ymm4-audio-effect) |
| 映像エフェクト | [ymm4-video-effect](https://github.com/topics/ymm4-video-effect) |
| 音声合成プラグイン | [ymm4-voice](https://github.com/topics/ymm4-voice) |
| AIテキスト補完プラグイン | [ymm4-text-completion](https://github.com/topics/ymm4-text-completion) |
| 場面切り替えプラグイン | [ymm4-transition](https://github.com/topics/ymm4-transition) |

## X（Twitter）ハッシュタグ
プラグインをTwitterで公開する場合、検索性向上のため以下のハッシュタグを設定することを推奨します。

| 種類 | ハッシュタグ |
| --- | --- |
| 共通 | [#YMM4Plugin](https://twitter.com/search?q=%23YMM4Plugin) |

## BOOTH タグ
プラグインをBOOTHで公開する場合、検索性向上のため以下のハッシュタグを設定することを推奨します。

| 種類 | タグ |
| --- | --- |
| 共通 | [#YMM4Plugin](https://booth.pm/ja/search/YMM4Plugin) |