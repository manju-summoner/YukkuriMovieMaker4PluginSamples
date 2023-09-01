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

namespace SampleVideoEffects.SampleD2DCustomEffect
{
    [VideoEffect("サンプルシェーダーエフェクト", new[] { "サンプル" }, new string[] { })]
    internal class SampleHLSLShaderVideoEffect : VideoEffectBase
    {
        public override string Label => "サンプルシェーダーエフェクト";

        [Display(Name = "強度", Description = "エフェクトの強度")]
        [AnimationSlider("F0", "%", 0, 100)]
        public Animation Value { get; set; } = new Animation(0, 0, 100);

        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            return Enumerable.Empty<string>();
        }

        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SampleHLSLShaderVideoEffectProcessor(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => new[] { Value };
    }
}
