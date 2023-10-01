# SampleShapePlugin
図形のサンプルプラグインです。
四角形の描画をサポートします。

# 主要クラス
## ShapePluginクラス
`IShapeParameter`を生成するクラスです。  
`IShapePlugin`を実装します。

## IShapeParameterクラス
図形の設定を保持するクラスです。  
`ShapeParameterBase`を継承します。

## IShapeSourceクラス
図形の描画を行うクラスです。
`IShapeSource`を実装します。