using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileWriter;
using YukkuriMovieMaker.Project;

namespace SampleVideoFileWriterPlugin
{
    public class SampleVideoFileWriterPlugin : IVideoFileWriterPlugin
    {
        /// <summary>
        /// プラグインの名前
        /// </summary>
        public string Name => "サンプル動画出力プラグイン";

        /// <summary>
        /// プラグインがサポートする出力パスの形式（ファイル or フォルダ or なし）
        /// </summary>
        public VideoFileWriterOutputPath OutputPathMode => VideoFileWriterOutputPath.File;

        /// <summary>
        /// 動画出力クラスを作成する
        /// </summary>
        /// <param name="path">出力パス</param>
        /// <param name="videoInfo">動画サイズ等の情報</param>
        /// <returns>動画出力クラス</returns>
        public IVideoFileWriter CreateVideoFileWriter(string path, VideoInfo videoInfo)
        {
            return new SampleVideoFileWriter(path, videoInfo);
        }

        /// <summary>
        /// ファイルの拡張子
        /// OutputPathModeがFileの場合に呼ばれる
        /// </summary>
        /// <returns></returns>
        public string GetFileExtention()
        {
            return ".mp4";
        }

        /// <summary>
        /// 設定コントロールを取得する
        /// </summary>
        /// <param name="projectName">プロジェクトの名前</param>
        /// <param name="videoInfo">動画サイズ等の情報</param>
        /// <param name="length">動画の長さ（フレーム数）</param>
        /// <returns></returns>
        public System.Windows.UIElement GetVideoConfigView(string projectName, VideoInfo videoInfo, int length)
        {
            return new System.Windows.Controls.Control();
        }

        /// <summary>
        /// 動画の出力に必要なリソースファイルをダウンロードする必要があるかどうか
        /// </summary>
        /// <returns></returns>
        public bool NeedDownloadResources()
        {
            return false;
        }

        /// <summary>
        /// 動画の出力に必要なリソースファイルをダウンロードする
        /// </summary>
        /// <param name="progress">進捗状況の通知クラス</param>
        /// <param name="token">キャンセル用トークン</param>
        /// <returns></returns>
        public Task DownloadResources(ProgressMessage progress, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}