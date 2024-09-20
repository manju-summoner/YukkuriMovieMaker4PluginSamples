using System.Numerics;
using Vortice.Direct2D1;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Player.Video;

namespace YMM4SamplePlugin.Transition
{
    internal class SampleTransitionSource : ITransitionSource
    {
        readonly IGraphicsDevicesAndContext devices;
        readonly ID2D1Image before;
        readonly ID2D1Image after;
        readonly SampleTransitionParameter sampleTransitionParameter;

        /// <summary>
        /// 描画結果
        /// </summary>
        public ID2D1Image Output => commandList ?? throw new NullReferenceException($"{nameof(commandList)} is null");
        ID2D1CommandList? commandList;

        Vector2 delta;

        public SampleTransitionSource(IGraphicsDevicesAndContext devices, ID2D1Image before, ID2D1Image after, SampleTransitionParameter sampleTransitionParameter)
        {
            this.devices = devices;
            this.before = before;
            this.after = after;
            this.sampleTransitionParameter = sampleTransitionParameter;
        }

        /// <summary>
        /// 場面を更新する
        /// </summary>
        /// <param name="desc"></param>
        void ITransitionSource.Update(TimelineItemSourceDescription desc)
        {
            var frame = desc.ItemPosition.Frame;
            var length = desc.ItemDuration.Frame;

            var screen = desc.ScreenSize;
            var rate = (float)Easing.GetValue(sampleTransitionParameter.EasingType, sampleTransitionParameter.EasingMode, (double)frame / length);
            var delta = new Vector2(screen.Width * rate, 0f);

            if (commandList != null && this.delta == delta)
                return;

            commandList?.Dispose();
            var dc = devices.DeviceContext;
            commandList = dc.CreateCommandList();

            dc.Target = commandList;
            dc.BeginDraw();
            dc.Clear(null);

            dc.DrawImage(after);
            dc.DrawImage(before, delta);

            dc.EndDraw();
            dc.Target = null;
            commandList.Close();

            this.delta = delta;
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
                commandList?.Dispose();

                // アンマネージド リソース (アンマネージド オブジェクト) を解放し、ファイナライザーをオーバーライドします
                // 大きなフィールドを null に設定します
                disposedValue = true;
            }
        }

        // // 'Dispose(bool disposing)' にアンマネージド リソースを解放するコードが含まれる場合にのみ、ファイナライザーをオーバーライドします
        // ~SampleTransitionSource()
        // {
        //     // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
        //     Dispose(disposing: false);
        // }

        void IDisposable.Dispose()
        {
            // このコードを変更しないでください。クリーンアップ コードを 'Dispose(bool disposing)' メソッドに記述します
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}