using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Audio.Effects;
using YukkuriMovieMaker.Plugin.Effects;

namespace SampleAudioEffect
{
    [AudioEffect("サンプル音声エフェクト", new[] { "サンプル" }, new string[] { })]
    public class SampleAudioEffect : AudioEffectBase
    {
        public override string Label => "サンプル音声エフェクト";

        [Display(GroupName = "サンプル", Name = "音量", Description = "音量を調整します")]

        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Volume { get; } = new Animation(100, 0, 100);

        public override IAudioEffectProcessor CreateAudioEffect(TimeSpan duration)
        {
            return new SampleAudioEffectProcessor(this, duration);
        }

        public override IEnumerable<string> CreateExoAudioFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => new[] { Volume };
    }
}