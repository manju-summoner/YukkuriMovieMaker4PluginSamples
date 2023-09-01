using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Plugin.FileWriter;
using YukkuriMovieMaker.Project;

namespace SampleVideoFileWriterPlugin
{
    public class SampleVideoFileWriterPlugin : IVideoFileWriterPlugin
    {
        public string Name => "サンプル動画出力プラグイン";
        public VideoFileWriterOutputPath OutputPathMode => VideoFileWriterOutputPath.File;


        public IVideoFileWriter CreateVideoFileWriter(string path, VideoInfo videoInfo)
        {
            return new SampleVideoFileWriter(path, videoInfo);
        }


        public string GetFileExtention()
        {
            return ".mp4";
        }

        public System.Windows.UIElement GetVideoConfigView(string projectName, VideoInfo videoInfo, int length)
        {
            return new System.Windows.Controls.Control();
        }
        public bool NeedDownloadResources()
        {
            return false;
        }
        public Task DownloadResources(ProgressMessage progress, CancellationToken token)
        {
            return Task.CompletedTask;
        }
    }
}