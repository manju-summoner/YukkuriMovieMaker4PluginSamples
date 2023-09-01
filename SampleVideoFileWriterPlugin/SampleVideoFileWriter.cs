using YukkuriMovieMaker.Plugin.FileWriter;
using YukkuriMovieMaker.Project;

namespace SampleVideoFileWriterPlugin
{
    internal class SampleVideoFileWriter : IVideoFileWriter
    {
        private string path;
        private VideoInfo videoInfo;

        public SampleVideoFileWriter(string path, VideoInfo videoInfo)
        {
            this.path = path;
            this.videoInfo = videoInfo;
        }

        public VideoFileWriterSupportedStreams SupportedStreams => VideoFileWriterSupportedStreams.Audio | VideoFileWriterSupportedStreams.Video;


        public void WriteAudio(float[] samples)
        {

        }

        public void WriteVideo(byte[] frame)
        {

        }
        public void Dispose()
        {

        }
    }
}