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
    /// <summary>
    /// 映像エフェクト
    /// 映像エフェクトには必ず[VideoEffect]属性を設定してください。
    /// </summary>
    [VideoEffect("サンプルD2Dエフェクト", new[] { "サンプル" }, new string[] { })]
    internal class SampleD2DVideoEffect : VideoEffectBase
    {
        /// <summary>
        /// エフェクトの名前
        /// </summary>
        public override string Label => "サンプルD2Dエフェクト";

        /// <summary>
        /// アイテム編集エリアに表示するエフェクトの設定項目。
        /// [Display]と[AnimationSlider]等のアイテム編集コントロール属性の2つを設定する必要があります。
        /// [AnimationSlider]以外のアイテム編集コントロール属性の一覧はSamplePropertyEditorsプロジェクトを参照してください。
        /// </summary>
        [Display(Name = "ぼかし", Description = "ぼかしの強さ")]
        [AnimationSlider("F0", "", 0, 100)]
        public Animation Blur { get; } = new Animation(10, 0, 100);

        /// <summary>
        /// ExoFilterを作成する
        /// </summary>
        /// <param name="keyFrameIndex">キーフレーム番号</param>
        /// <param name="exoOutputDescription">exo出力に必要な各種パラメーター</param>
        /// <returns></returns>
        public override IEnumerable<string> CreateExoVideoFilters(int keyFrameIndex, ExoOutputDescription exoOutputDescription)
        {
            var fps = exoOutputDescription.VideoInfo.FPS;
            return new[] 
            {
                $"_name=ぼかし\r\n" +
                $"_disable={(IsEnabled ?1:0)}\r\n" +
                $"範囲={Blur.ToExoString(keyFrameIndex, "F0", fps)}\r\n" +
                $"縦横比=0.0\r\n" +
                $"光の強さ=0\r\n" +
                $"サイズ固定=0\r\n",
            };
        }

        /// <summary>
        /// 映像エフェクトを作成する
        /// </summary>
        /// <param name="devices">デバイス</param>
        /// <returns>映像エフェクト</returns>
        public override IVideoEffectProcessor CreateVideoEffect(IGraphicsDevicesAndContext devices)
        {
            return new SampleD2DVideoEffectProcessor(devices, this);
        }

        /// <summary>
        /// クラス内のIAnimatableの一覧を取得する
        /// </summary>
        /// <returns></returns>
        protected override IEnumerable<IAnimatable> GetAnimatables() => new IAnimatable[] { Blur };
    }
}
