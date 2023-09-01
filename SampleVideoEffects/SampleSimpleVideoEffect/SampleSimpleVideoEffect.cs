using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Effects;

namespace SampleVideoEffects.SampleSimpleEffect
{
    [VideoEffect("サンプルシンプルエフェクト", new[] { "サンプル" }, new string[] { })]
    internal class SampleSimpleVideoEffect : VideoEffectBase
    {
        public override string Label => "サンプルシンプルエフェクト";

        [Display(Name = "X", Description = "X")]
        [AnimationSlider("F0", "px", -100, 100)]
        public Animation X { get; } = new Animation(0, -10000, 10000);
        [Display(Name = "Y", Description = "Y")]
        [AnimationSlider("F0", "px", -100, 100)]
        public Animation Y { get; } = new Animation(0, -10000, 10000);

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SampleSimpleVideoEffectProcessor(this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => new[] { X, Y };
    }
}
