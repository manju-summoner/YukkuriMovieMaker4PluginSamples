# SampleAudioSpectrumPlugin
波形のサンプルプラグインです。
音声に合わせて四角形の大きさを変更して表示します。

# 主要クラス
## AudioSpectrumPluginクラス
`IAudioSpectrumParameter`を生成するクラスです。  
`IAudioSpectrumPlugin`を実装します。

## IAudioSpectrumParameterクラス
波形の設定を保持するクラスです。  
`AudioSpectrumParameterBase`を継承します。

## IAudioSpectrumSource
波形を描画するクラスです。
`IAudioSpectrumSource`を実装します。