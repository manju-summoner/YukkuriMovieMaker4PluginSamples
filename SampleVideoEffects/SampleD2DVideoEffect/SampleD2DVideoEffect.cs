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

namespace SampleVideoEffects.SampleD2DEffect
{
    [VideoEffect("サンプルD2Dエフェクト", new[] { "サンプル" }, new string[] { })]
    internal class SampleD2DVideoEffect : VideoEffectBase
    {
        public override string Label => "サンプルD2Dエフェクト";

        [Display(Name = "ぼかし", Description = "ぼかしの強さ")]
        [AnimationSlider("F0", "", 0, 100)]
        public Animation Blur { get; } = new Animation(10, 0, 100);

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SampleD2DVideoEffectProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => new IAnimatable[] { Blur };
    }
}
