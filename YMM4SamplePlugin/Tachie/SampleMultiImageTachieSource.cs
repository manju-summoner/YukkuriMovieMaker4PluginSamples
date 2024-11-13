using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin;
using YukkuriMovieMaker.Plugin.Tachie;

namespace YMM4SamplePlugin.Tachie
{
    internal class SampleMultiImageTachieSource : ITachieSource2
    {
        readonly IGraphicsDevicesAndContext devices;

        public ID2D1Image Output => output;

        ID2D1CommandList? commandList = null;
        IImageFileSource[] sources = [];
        readonly Vortice.Direct2D1.Effects.AffineTransform2D transformEffect;
        readonly ID2D1Image output;

        bool isFirst = true;
        string? file;

        public SampleMultiImageTachieSource(IGraphicsDevicesAndContext devices)
        {
            this.devices = devices;

            //Outputのインスタンスを固定するために、間にエフェクトを挟む
            transformEffect = new Vortice.Direct2D1.Effects.AffineTransform2D(devices.DeviceContext);
            output = transformEffect.Output;//EffectからgetしたOutputは必ずDisposeする必要がある。Effect側では開放されない。
        }

        /// <summary>
        /// 表示を更新する
        /// </summary>


        public void Update(TachieSourceDescription desc)
        {
            var ip = desc.Tachie?.ItemParameter as SampleTachieItemParameter;
            var fp = desc.Tachie?.Faces?.FirstOrDefault()?.FaceParameter as SampleTachieFaceParameter;

            var file = !string.IsNullOrEmpty(fp?.File) ? fp.File : ip?.File;
            if (isFirst || this.file != file)
            {
                if (this.sources != null)
                    foreach (var source in this.sources)
                    {
                        source?.Dispose();
                    }
                var sources = new List<IImageFileSource>();
                //指定されたファイルに加え、ファイル名_1.png, ファイル名_2.png, ... が存在するか確認し、存在する場合はそれらも読み込む
                for (int i = 0; ; i++)
                {
                    var dir = System.IO.Path.GetDirectoryName(file);
                    if (dir is null)
                        break;
                    var name = System.IO.Path.GetFileNameWithoutExtension(file);
                    var ext = System.IO.Path.GetExtension(file);
                    var path = i is 0 ? file : System.IO.Path.Combine(dir, $"{name}_{i}{ext}");
                    if (path is null)
                        break;
                    var source = ImageFileSourceFactory.Create(devices, path);
                    if (source is null)
                        break;
                    sources.Add(source);
                }
                this.sources = [.. sources];
            }

            commandList?.Dispose();//前回のUpdateで作成したCommandListを破棄する
            commandList = devices.DeviceContext.CreateCommandList();

            var dc = devices.DeviceContext;
            dc.Target = commandList;
            dc.BeginDraw();
            dc.Clear(null);

            foreach (var source in sources)
            {
                //通常や加算で描画する場合はDrawImage
                dc.DrawImage(source.Output, compositeMode: CompositeMode.SourceOver);
                //乗算やオーバーレイで描画する場合はBlendImageで描画する
                //dc.BlendImage(source.Output, BlendMode.Multiply, null, null, InterpolationMode.MultiSampleLinear);
            }
            dc.EndDraw();
            dc.Target = null;//Targetは必ずnullに戻す。
            commandList.Close();//CommandListはEndDraw()の後に必ずClose()を呼んで閉じる必要がある

            transformEffect.SetInput(0, commandList, true);

            isFirst = false;
            this.file = file;
        }

        public void Dispose()
        {
            //読み込んだ画像を破棄
            foreach (var source in sources)
                source?.Dispose();
            //最後のUpdateで作成したCommandListを破棄
            commandList?.Dispose();

            transformEffect.SetInput(0, null, true);//EffectのInputは必ずnullに戻す。
            output.Dispose();//EffectからgetしたOutputは必ずDisposeする必要がある。Effect側では開放されない。
            transformEffect.Dispose();
        }
    }
}