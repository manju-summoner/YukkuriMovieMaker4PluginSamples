using System.ComponentModel.DataAnnotations;
using System.Windows.Ink;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;

namespace SampleShapePlugin
{
    internal class SampleShapeParameter : ShapeParameterBase
    {
        /// <summary>
        /// アイテム編集エリアに表示する音声の設定項目。
        /// [Display]と[AnimationSlider]等のアイテム編集コントロール属性の2つを設定する必要があります。
        /// [AnimationSlider]以外のアイテム編集コントロール属性の一覧はSamplePropertyEditorsプロジェクトを参照してください。
        /// </summary>
        [Display(Name = "サイズ")]
        [AnimationSlider("F0","px", 0, 100)]
        public Animation Size { get; } = new Animation(100, 0, 1000);

        //必ず引数なしのコンストラクタを定義してください。
        //これがないとプロジェクトファイルの読み込みに失敗します。
        public SampleShapeParameter():this(null)
        {

        }

        public SampleShapeParameter(SharedDataStore? sharedData) : base(sharedData)
        {

        }

        /// <summary>
        /// マスクのExoFilterを生成する。
        /// </summary>
        /// <param name="keyFrameIndex">キーフレーム番号</param>
        /// <param name="desc">exo出力に必要な各種パラメーター</param>
        /// <param name="shapeMaskParameters">マスクのexo出力に必要な各種パラメーター</param>
        /// <returns>exoフィルタ</returns>
        public override IEnumerable<string> CreateMaskExoFilter(int keyFrameIndex, ExoOutputDescription desc, ShapeMaskParameters shapeMaskParameters)
        {
            int fps = desc.VideoInfo.FPS;
            return new[]
            {
                $"_name=マスク\r\n" +
                $"_disable={(shapeMaskParameters.IsEnabled ? 0 : 1)}\r\n" +
                $"X={shapeMaskParameters.X.ToExoString(keyFrameIndex, "F1",fps)}\r\n" +
                $"Y={shapeMaskParameters.Y.ToExoString(keyFrameIndex, "F1",fps)}\r\n" +
                $"回転={shapeMaskParameters.Rotation.ToExoString(keyFrameIndex, "F2",fps)}\r\n" +
                $"サイズ=100\r\n" +
                $"縦横比=0\r\n" +
                $"ぼかし={shapeMaskParameters.Blur.ToExoString(keyFrameIndex, "F0",fps)}\r\n" +
                $"マスクの反転={(shapeMaskParameters.IsInverted?1:0):F0}\r\n" +
                $"元のサイズに合わせる=0\r\n" +
                $"type=0\r\n" +
                $"name=\r\n" +
                $"mode=0\r\n"
            };
        }

        /// <summary>
        /// 図形アイテムのExoFilterを生成する。
        /// </summary>
        /// <param name="keyFrameIndex">キーフレーム番号</param>
        /// <param name="desc">exo出力に必要な各種パラメーター</param>
        /// <returns>exoフィルタ</returns>
        public override IEnumerable<string> CreateShapeItemExoFilter(int keyFrameIndex, ExoOutputDescription desc)
        {
            var fps = desc.VideoInfo.FPS;
            return new[]
            {
                    $"_name=図形\r\n" +
                    $"サイズ={Size.ToExoString(keyFrameIndex, "F0", fps)}\r\n" +
                    $"縦横比=0\r\n" +
                    $"ライン幅=4000\r\n" +
                    $"type=0\r\n" +
                    $"color=FFFFFF\r\n" +
                    $"name=\r\n"
            };
        }

        /// <summary>
        /// 図形ソースを生成する。
        /// </summary>
        /// <param name="devices">デバイス</param>
        /// <returns>図形ソース</returns>
        public override IShapeSource CreateShapeSource(IGraphicsDevicesAndContext devices)
        {
            return new SampleShapeSource(devices, this);
        }

        /// <summary>
        /// このクラス内のIAnimatable一覧を返す。
        /// </summary>
        /// <returns>IAnimatable一覧</returns>
        protected override IEnumerable<IAnimatable> GetAnimatables() => new IAnimatable[] { Size };

        /// <summary>
        /// 設定を一時的に保存する。
        /// 図形の種類を切り替えたときに元の設定項目を復元するために必要。
        /// </summary>
        /// <param name="store"></param>
        protected override void LoadSharedData(SharedDataStore store)
        {
            var sharedData = store.Load<SharedData>();
            if (sharedData is null)
                return;

            sharedData.CopyTo(this);
        }

        /// <summary>
        /// 設定を復元する。
        /// 図形の種類を切り替えたときに元の設定項目を復元するために必要。
        /// </summary>
        /// <param name="store"></param>
        protected override void SaveSharedData(SharedDataStore store)
        {
            store.Save(new SharedData(this));
        }

        /// <summary>
        /// 設定の一時保存用クラス
        /// </summary>
        class SharedData
        {
            public Animation Size { get; } = new Animation(100, 0, 1000);
            public SharedData(SampleShapeParameter param)
            {
                Size.CopyFrom(param.Size);
            }
            public void CopyTo(SampleShapeParameter param)
            {
                param.Size.CopyFrom(Size);
            }
        }
    }
}