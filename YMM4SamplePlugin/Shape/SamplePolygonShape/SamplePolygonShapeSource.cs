using System.Collections.Immutable;
using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace YMM4SamplePlugin.Shape.SamplePolygonShape
{
    internal class SamplePolygonShapeSource : IShapeSource2
    {
        readonly IGraphicsDevicesAndContext devices;
        readonly SamplePolygonShapeParameter samplePolygonShapeParameter;
        readonly DisposeCollector disposer = new();

        public IEnumerable<VideoController> Controllers { get; private set; } = [];
        public ID2D1Image Output => commandList ?? throw new InvalidOperationException("commandList is null");

        bool isFirst = true;
        ImmutableList<SamplePolygonShapePoint>? pointList;
        Vector2[] points = [];

        readonly ID2D1SolidColorBrush white;
        ID2D1PathGeometry? geometry;
        ID2D1CommandList? commandList;

        public SamplePolygonShapeSource(IGraphicsDevicesAndContext devices, SamplePolygonShapeParameter samplePolygonShapeParameter)
        {
            this.devices = devices;
            this.samplePolygonShapeParameter = samplePolygonShapeParameter;

            var dc = devices.DeviceContext;
            white = dc.CreateSolidColorBrush(new(1f, 1f, 1f, 1f));
            disposer.Collect(white);
        }


        public void Update(TimelineItemSourceDescription timelineItemSourceDescription)
        {
            var frame = timelineItemSourceDescription.ItemPosition.Frame;
            var length = timelineItemSourceDescription.ItemDuration.Frame;
            var fps = timelineItemSourceDescription.FPS;

            var pointList = samplePolygonShapeParameter.Points;
            var points =
                samplePolygonShapeParameter.Points
                .Select(p =>
                new Vector2(
                    (float)p.X.GetValue(frame, length, fps),
                    (float)p.Y.GetValue(frame, length, fps)))
                .ToArray();

            //変更がない場合は戻る
            if (!isFirst && this.pointList == pointList && this.points.SequenceEqual(points))
                return;

            //前回のUpdateで作成した図形を破棄して新しい図形を作成する
            if (geometry is not null)
                disposer.RemoveAndDispose(ref geometry);
            geometry = devices.D2D.Factory.CreatePathGeometry();
            disposer.Collect(geometry);

            using (var sink = geometry.Open())
            {
                sink.BeginFigure(points[0], FigureBegin.Filled);
                sink.AddLines(points[1..]);
                sink.EndFigure(FigureEnd.Closed);
                sink.Close();
            }

            //前回のUpdateで作成したコマンドリストを破棄して新しいコマンドリストを作成する
            if (commandList is not null)
                disposer.RemoveAndDispose(ref commandList);
            commandList = devices.DeviceContext.CreateCommandList();
            disposer.Collect(commandList);

            //図形を作成する
            var dc = devices.DeviceContext;
            dc.Target = commandList;
            dc.BeginDraw();
            dc.Clear(null);
            dc.FillGeometry(geometry, white);
            dc.EndDraw();
            dc.Target = null;
            commandList.Close();

            //制御点を作成する
            var controllerPoints =
                samplePolygonShapeParameter.Points
                .Select(p =>
                new ControllerPoint(
                    new(
                        (float)p.X.GetValue(frame, length, fps),
                        (float)p.Y.GetValue(frame, length, fps), 0),
                    (a) =>
                    {
                        p.X.AddToEachValues(a.Delta.X);
                        p.Y.AddToEachValues(a.Delta.Y);
                    }));
            var controller = new VideoController(controllerPoints)
            {
                Connection = VideoControllerPointConnection.None
            };
            Controllers = [controller];

            //キャッシュ用の情報を保存しておく
            isFirst = false;
            this.pointList = pointList;
            this.points = points;
        }

        public void Dispose()
        {
            disposer.DisposeAndClear();
        }
    }
}