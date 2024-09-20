using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Audio.Effects;
using YukkuriMovieMaker.Plugin.Effects;

namespace YMM4SamplePlugin.AudioEffect
{
    /// <summary>
    /// 音声エフェクト
    /// 音声エフェクトには必ず[AudioEffect]属性を設定してください。
    /// </summary>
    [AudioEffect("サンプル音声エフェクト", ["サンプル"], [])]
    public class SampleAudioEffect : AudioEffectBase
    {
        /// <summary>
        /// エフェクトの名前
        /// </summary>
        public override string Label => "サンプル音声エフェクト";

        /// <summary>
        /// アイテム編集エリアに表示するエフェクトの設定項目。
        /// [Display]と[AnimationSlider]等のアイテム編集コントロール属性の2つを設定する必要があります。
        /// [AnimationSlider]以外のアイテム編集コントロール属性の一覧はSamplePropertyEditorsプロジェクトを参照してください。
        /// </summary>
        [Display(GroupName = "サンプル", Name = "音量", Description = "音量を調整します")]
        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Volume { get; } = new Animation(100, 0, 100);

        /// <summary>
        /// 音声エフェクトを作成する
        /// </summary>
        /// <param name="duration">音声エフェクトの長さ</param>
        /// <returns>音声エフェクト</returns>
        public override IAudioEffectProcessor CreateAudioEffect(TimeSpan duration)
        {
            return new SampleAudioEffectProcessor(this, duration);
        }

        /// <summary>
        /// ExoFilterを作成する
        /// </summary>
        /// <param name="keyFrameIndex">キーフレーム番号</param>
        /// <param name="exoOutputDescription">exo出力に必要な各種項目</param>
        /// <returns>exoフィルタ</returns>
        public override IEnumerable<string> CreateExoAudioFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            //AviUtlに音量を設定するためのフィルタが存在しないため、以下のフィルタは正常に機能しません。例示用です。
            var fps = exoOutputDescription.VideoInfo.FPS;
            return
            [
                $"_name=音量\r\n" +
                $"_disable={(IsEnabled ?1:0)}\r\n" +
                $"音量={Volume.ToExoString(keyFrameIndex, "F1", fps)}\r\n"
            ];
        }

        /// <summary>
        /// IAnimatableを実装するプロパティを返す
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IAnimatable> GetAnimatables() => [Volume];
    }
}