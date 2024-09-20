# エフェクト一覧
## SampleSimpleVideoEffect
移動・回転等の基本的なアニメーションのみを提供するシンプルなエフェクトです。

## SampleD2DVideoEffect
Direct2Dの組み込みエフェクトを利用したエフェクトです。

## SampleHLSLShaderVideoEffect
HLSLシェーダーを利用した、より高度な映像処理を提供するエフェクトです。

# 主要クラス
## VideoEffectクラス
エフェクトの設定項目を保存するクラスです。  
`[VideoEffect]`属性の付いた`VideoEffectBase`を継承したクラスを作成します。  

各種設定項目には`[Display]`属性と、`[PropertyEditorAttribute]`を継承した編集用コントロール生成属性を追加する必要があります。

## VideoEffectProcessorクラス
エフェクトの処理を行うクラスです。  
`IVideoEffectProcessor`を実装します。

## CustomEffectクラス
HLSLを用いたエフェクトを作成する場合に実装します。  
`D2D1CustomShaderEffectBase`を継承します。
