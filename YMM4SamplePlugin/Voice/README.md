# SampleSAPI5VoicePlugin
SAPI5を用いた音声合成プラグインのサンプルです。

# 主要クラス
## VoicePluginクラス
声質一覧の列挙を行うためのクラスです。  
`IVoicePlugin`を実装します。

## VoiceParameterクラス
声質のパラメータを保持するクラスです。
`VoiceParameterBase`を継承したクラスを実装します。

## VoiceSpeakerクラス
音声合成処理を行うクラスです。
`IVoiceSpeaker`を実装します。