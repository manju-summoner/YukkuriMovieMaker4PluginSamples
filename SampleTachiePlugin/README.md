# SampleTachiePlugin
1枚の画像のみで構成されたシンプルな立ち絵プラグインです。

# 主要クラス
## TachiePluginクラス
立ち絵の読み込みクラス、各種パラメーターの生成機能を提供します。  
`ITachiePlugin`を実装します。

## TachieSourceクラス
立ち絵の読み込みクラスです。
`ITachieSource`を実装します。

## TachieCharacterParameterクラス
キャラクターに設定する立ち絵用パラメーターです。
`TachieCharacterParameterBase`を継承します。

## TachieItemParameterクラス
立ち絵アイテムに設定する立ち絵用パラメーターです。
`TachieItemParameterBase`を継承します。

## TachieFaceParameterクラス
ボイスアイテムまたは表情アイテムに設定する立ち絵用パラメーターです。
`TachieFaceParameterBase`を継承します。