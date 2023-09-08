using SpeechLib;
using YukkuriMovieMaker.Plugin.Voice;

namespace SampleSAPI5VoicePlugin
{
    public class SAPI5VoiceSpeaker : IVoiceSpeaker
    {
        //同時実行数に制限のあるAPIを使用する場合はsemaphoreを使って同時実行数を制御する必要がある。
        //他の話者も含めて同時実行数を制限するため、staticにする。
        static readonly SemaphoreSlim semaphore = new(1);

        /// <summary>
        /// 音声合成エンジンの名前（表示用）
        /// </summary>
        public string EngineName => "SAPI5 Sample";

        /// <summary>
        /// 話者の名前（表示用）
        /// </summary>
        public string SpeakerName => ID;

        /// <summary>
        /// 音声合成エンジンの識別子。他のプラグインと重複しないようにする。
        /// </summary>
        public string API => "SAPI5Sample";

        /// <summary>
        /// 話者の識別子。
        /// 同じAPI内で重複しないようにする。
        /// </summary>
        public string ID { get; }

        /// <summary>
        /// 生成した音声データをキャッシュする必要があるかどうか。
        /// 有料のAPIを使用して音声を生成する場合は必ずtrueにする。
        /// </summary>
        public bool IsVoiceDataCachingRequired => false;

        /// <summary>
        /// サポートしているセリフの形式（英語のみ、AquesTalk形式のみ等）
        /// </summary>
        public SupportedTextFormat Format => SupportedTextFormat.Text;

        /// <summary>
        /// 音声合成前に利用規約に同意する必要がある場合はここにインスタンスを設定する
        /// </summary>
        public IVoiceLicense? License => null;

        /// <summary>
        /// 音声合成前に追加のリソースファイルをダウンロードする必要がある場合にここにインスタンスを設定する
        /// </summary>
        public IVoiceResource? Resource => null;

        public SAPI5VoiceSpeaker(string speaker) => ID = speaker;

        /// <summary>
        /// APIとIDがこの話者と一致するかどうか。
        /// 
        /// 通常は
        /// `return API == api && ID == id;`
        /// 
        /// 開発を続けていくうちにIDが変わってしまった場合、
        /// `return API == api && (ID == id || "古いID" == id);`
        /// 等として、古いIDでも一致するようにする。
        /// </summary>
        /// <param name="api">API</param>
        /// <param name="id">ID</param>
        /// <returns>一致したらtrue</returns>
        public bool IsMatch(string api, string id)
        {
            return api == API && id == ID;
        }

        /// <summary>
        /// VoiceParameterを作成する
        /// </summary>
        /// <returns>新しいIVoiceParameter</returns>
        public IVoiceParameter CreateVoiceParameter()
        {
            return new SAPI5VoiceParameter();
        }

        /// <summary>
        /// プロジェクトファイルの読み込み時やキャラクターの声質の変更時に呼ばれる。
        /// 現在の話者で利用できないIVoiceParameterが渡された場合はCreateVoiceParameter()を呼んで新しく作り直す。
        /// 利用できる場合は渡されたcurrentParameterをそのまま返す。
        /// 必要に応じてcurrentParameterの中身を変更しても良い。
        /// </summary>
        /// <param name="currentParameter"></param>
        /// <returns></returns>
        public IVoiceParameter MigrateParameter(IVoiceParameter currentParameter)
        {
            if (currentParameter is not SAPI5VoiceParameter)
                return CreateVoiceParameter();
            return currentParameter;
        }

        /// <summary>
        /// FormatでCustomが指定されている場合に呼ばれる。音声合成エンジン側の漢字読み変換機能を利用する。
        /// FormatがCustom以外の場合は実装しない。
        /// </summary>
        /// <param name="text">漢字や英語を含む文章</param>
        /// <returns>発音</returns>
        /// <param name="voiceParameter">パラメーター</param>
        public Task<string> ConvertKanjiToYomiAsync(string text, IVoiceParameter voiceParameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 音声ファイルを生成する
        /// </summary>
        /// <param name="text">読み上げるテキスト</param>
        /// <param name="pronounce">抑揚</param>
        /// <param name="parameter">パラメーター</param>
        /// <param name="filePath">ファイルの出力先</param>
        /// <returns>音声の生成によって得られた新しい抑揚</returns>
        public async Task<IVoicePronounce?> CreateVoiceAsync(string text, IVoicePronounce? pronounce, IVoiceParameter? parameter, string filePath)
        {
            //同時実行数に制限のあるAPIを呼び出す場合はsemaphoreを使って制限する
            //これがないと、台本読み込み時等、大量の音声を生成しようとした際に音声の生成に失敗する
            await semaphore.WaitAsync();
            try
            {
                await Task.Run(() =>
                {
                    var spFileStream = new SpFileStream();
                    try
                    {
                        var spVoice = new SpVoice();
                        var voice =
                            spVoice
                            .GetVoices()
                            .Cast<SpObjectToken>()
                            .FirstOrDefault(x => x.GetAttribute("Name") == ID);
                        if (voice is null)
                            return;

                        var param = parameter as SAPI5VoiceParameter ?? (SAPI5VoiceParameter)CreateVoiceParameter();
                        spFileStream.Open(filePath, SpeechStreamFileMode.SSFMCreateForWrite);
                        spVoice.AudioOutputStream = spFileStream;
                        spVoice.Volume = 100;
                        spVoice.Rate = (int)param.Speed;
                        spVoice.Voice = voice;
                        spVoice.Speak(text);
                    }
                    finally
                    {
                        spFileStream.Close();
                    }
                });
            }
            finally
            {
                semaphore.Release();
            }
            return null;
        }
    }
}