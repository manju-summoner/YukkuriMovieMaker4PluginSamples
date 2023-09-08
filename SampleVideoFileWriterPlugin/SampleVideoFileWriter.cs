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

        /// <summary>
        /// 音声を書き込む
        /// </summary>
        /// <param name="samples"></param>
        public void WriteAudio(float[] samples)
        {

        }

        /// <summary>
        /// 映像を書き込む
        /// </summary>
        /// <param name="frame"></param>
        public void WriteVideo(byte[] frame)
        {

        }
        public void Dispose()
        {

        }
    }
}