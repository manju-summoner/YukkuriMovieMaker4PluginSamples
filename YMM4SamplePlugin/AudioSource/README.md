# SampleAudioSource
音声読み込みプラグインのサンプルです。  
`1khz.txt`という名前のファイルをサンプリングレート44kHz2chの1khzSin波として読み込みます。

# 主要クラス
## AudioSourcePluginクラス
プラグインの名前とAudioSourceのインスタンスを返すクラスです。  
`IAudioFileSourcePlugin`を実装したクラスを実装します。

## AudioSourceクラス
実際に音声を読み込む処理を実装するクラスです。  
`IAudioFileSource`を実装したクラスを実装します。  
読み出し音声は常に2chである必要があります。