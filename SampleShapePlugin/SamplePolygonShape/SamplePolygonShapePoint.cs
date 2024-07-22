using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;

namespace SampleShapePlugin.SamplePolygonShape
{
    public class SamplePolygonShapePoint : Animatable
    {
        [Display(GroupName = "頂点", Name = "X")]
        [AnimationSlider("F1", "px", -500,500)]
        public Animation X { get; } = new Animation(0, -100000, 100000);

        [Display(GroupName = "頂点", Name = "Y")]
        [AnimationSlider("F1", "px", -500, 500)]
        public Animation Y { get; } = new Animation(0, -100000, 100000);

        public SamplePolygonShapePoint()
        {
        }

        public SamplePolygonShapePoint(double x, double y)
        {
            X.Values[0].Value = x;
            Y.Values[0].Value = y;
        }
        public SamplePolygonShapePoint(SamplePolygonShapePoint point)
        {
            X.CopyFrom(point.X);
            Y.CopyFrom(point.Y);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => [X, Y];
    }
}