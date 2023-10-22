# SampleTransitionPlugin
場面切り替えのサンプルプラグインです

# 主要クラス
## TransitionPluginクラス
`ITransitionParameter`を生成するクラスです。  
`ITransitionPlugin`を実装します。

## ITransitionParameterクラス
場面切り替えの設定を保持するクラスです。  
`TransitionParameterBase`を継承します。

## ITransitionSourceクラス
場面切り替えの描画を行うクラスです。
`ITransitionSource`を実装します。