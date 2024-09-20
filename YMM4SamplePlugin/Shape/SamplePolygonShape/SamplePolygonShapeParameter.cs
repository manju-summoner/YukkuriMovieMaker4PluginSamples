using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;
using YukkuriMovieMaker.UndoRedo;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    internal class SamplePolygonShapeParameter(SharedDataStore? sharedData) : ShapeParameterBase(sharedData)
    {
        [Display(GroupName = "サンプル多角形", Name = "")]
        [PointsEditor(PropertyEditorSize = PropertyEditorSize.FullWidth)]
        public ImmutableList<SamplePolygonShapePoint> Points { get => points; set => Set(ref points, value); }
        ImmutableList<SamplePolygonShapePoint> points =
            [
                new SamplePolygonShapePoint(-100,-100),
                new SamplePolygonShapePoint(100,-100),
                new SamplePolygonShapePoint(100,100),
                new SamplePolygonShapePoint(-100,100),
            ];

        public SamplePolygonShapeParameter() : this(null)
        {
        }

        public override IEnumerable<string> CreateMaskExoFilter(int keyFrameIndex, ExoOutputDescription desc, ShapeMaskExoOutputDescription shapeMaskParameters)
        {
            return [];
        }

        public override IEnumerable<string> CreateShapeItemExoFilter(int keyFrameIndex, ExoOutputDescription desc)
        {
            return [];
        }

        public override IShapeSource CreateShapeSource(IGraphicsDevicesAndContext devices)
        {
            return new SamplePolygonShapeSource(devices, this);
        }

        protected override IEnumerable<IAnimatable> GetAnimatables() => Points;

        protected override void LoadSharedData(SharedDataStore store)
        {
            var data = store.Load<SharedData>();
            if (data is null)
                return;
            data.CopyTo(this);
        }

        protected override void SaveSharedData(SharedDataStore store)
        {
            store.Save(new SharedData(this));
        }

        public class SharedData(SamplePolygonShapeParameter parameter)
        {
            public ImmutableList<SamplePolygonShapePoint> Points { get; } = [.. parameter.Points.Select(x => new SamplePolygonShapePoint(x))];

            public void CopyTo(SamplePolygonShapeParameter parameter)
            {
                parameter.Points = [.. Points.Select(x => new SamplePolygonShapePoint(x))];
            }
        }
    }
}