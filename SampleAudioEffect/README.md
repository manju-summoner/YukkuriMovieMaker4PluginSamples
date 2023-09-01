# SampleAudioEffect
音声エフェクトのサンプルです。  
音量調整機能を提供します。

# 主要クラス
## AudioEffectクラス
エフェクトの設定項目を保存するクラスです。  
`[AudioEffect]`属性の付いた`AudioEffectBase`を継承したクラスを作成します。  

各種設定項目には`[Display]`属性と、`[PropertyEditorAttribute]`を継承した編集用コントロール生成属性を追加する必要があります。

## AudioEffectProcessorクラス
実際に波形を加工する処理を実装するクラスです。  
`AudioEffectProcessorBase`を継承したクラスを作成します。  