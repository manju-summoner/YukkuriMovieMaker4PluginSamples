using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace SampleShapePlugin
{
    internal class SampleShapeSource : IShapeSource
    {
        readonly private IGraphicsDevicesAndContext devices;
        readonly private SampleShapeParameter sampleShapeParameter;

        double size;

        readonly ID2D1SolidColorBrush whiteBrush;
        ID2D1CommandList? commandList;

        /// <summary>
        /// 描画結果
        /// </summary>
        public ID2D1Image Output => commandList ?? throw new Exception($"{nameof(commandList)}がnullです。事前にUpdateを呼び出す必要があります。");

        public SampleShapeSource(IGraphicsDevicesAndContext devices, SampleShapeParameter sampleShapeParameter)
        {
            this.devices = devices;
            this.sampleShapeParameter = sampleShapeParameter;

            whiteBrush = devices.DeviceContext.CreateSolidColorBrush(new Vortice.Mathematics.Color4(1,1,1,1));
        }


        /// <summary>
        /// 図形を更新する
        /// </summary>
        /// <param name="timelineItemSourceDescription"></param>
        public void Update(TimelineItemSourceDescription timelineItemSourceDescription)
        {
            var fps = timelineItemSourceDescription.FPS;
            var frame = timelineItemSourceDescription.ItemPosition.Frame;
            var length = timelineItemSourceDescription.ItemDuration.Frame;

            var size = sampleShapeParameter.Size.GetValue(frame, length, fps);

            //サイズが変わっていない場合は何もしない
            if (commandList != null && this.size == size)
                return;

            var dc = devices.DeviceContext;

            commandList?.Dispose();//新規作成前に、前回のCommandListを必ず破棄する
            commandList = dc.CreateCommandList();
            
            dc.Target = commandList;
            dc.BeginDraw();
            dc.Clear(null);
            dc.FillRectangle(new Vortice.RawRectF((float)-size/2, (float)-size/2, (float)size /2, (float)size /2), whiteBrush);
            dc.EndDraw();
            dc.Target = null;//Targetは必ずnullに戻す。
            commandList.Close();//CommandListはEndDraw()の後に必ずClose()を呼んで閉じる必要がある

            this.size = size;

        }
        
        #region IDisposable
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // マネージド状態を破棄します (マネージド オブジェクト)
                    commandList?.Dispose();
                    whiteBrush?.Dispose();
                }

                // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~SampleShapeSource()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}