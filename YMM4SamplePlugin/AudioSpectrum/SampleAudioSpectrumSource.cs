using Vortice.Direct2D1;
using Vortice.Mathematics;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;
using YukkuriMovieMaker.Plugin.Shape;

namespace YMM4SamplePlugin.AudioSpectrum
{
    internal class SampleAudioSpectrumSource : IAudioSpectrumSource
    {
        readonly IGraphicsDevicesAndContext devices;
        readonly SampleAudioSpectrumParameter item;

        public ID2D1Image Output => output ?? throw new NullReferenceException("先にUpdateを呼ぶ必要があります");

        ID2D1CommandList? output;
        readonly ID2D1SolidColorBrush brush;

        float actualSize = 0;

        public SampleAudioSpectrumSource(IGraphicsDevicesAndContext devices, SampleAudioSpectrumParameter item)
        {
            this.devices = devices;
            this.item = item;
            brush = devices.DeviceContext.CreateSolidColorBrush(new Color4(1, 1, 1, 1));
        }

        public void Update(TimelineItemSourceDescription desc, float[] spectrum)
        {
            var frame = desc.ItemPosition.Frame;
            var length = desc.ItemDuration.Frame;
            var fps = desc.FPS;

            var size = (float)item.Size.GetValue(frame, length, fps);
            var value = (float)spectrum.Average();
            var actualSize = value * size / 100;

            if (output != null && this.actualSize == size)
                return;

            var dc = devices.DeviceContext;

            output?.Dispose();
            output = dc.CreateCommandList();

            dc.Target = output;
            dc.BeginDraw();
            dc.Clear(null);

            dc.FillRectangle(new Rect(-actualSize / 2, -actualSize / 2, actualSize, actualSize), brush);

            dc.EndDraw();
            dc.Target = null;
            output.Close();

            this.actualSize = actualSize;
        }

        #region IDisposable Support
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // マネージド状態を破棄します (マネージド オブジェクト)
                }
                output?.Dispose();
                brush?.Dispose();

                // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~SampleAudioSpectrumSource()
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