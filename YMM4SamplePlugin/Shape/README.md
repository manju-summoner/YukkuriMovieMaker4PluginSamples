# SampleShapePlugin
図形のサンプルプラグインです。  
四角形の描画をサポートします。

# SamplePolygonShapePlugin
図形のサンプルプラグインです。  
多角形の描画をサポートします。  
以下の機能を実装しています
- 制御点を使用してプレビューエリアから直接頂点の位置を編集
- 頂点の追加、削除

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