using YukkuriMovieMaker.Player.Audio;
using YukkuriMovieMaker.Player.Audio.Effects;

namespace SampleAudioEffect
{
    internal class SampleAudioEffectProcessor : AudioEffectProcessorBase
    {
        readonly SampleAudioEffect item;
        readonly TimeSpan duration;

        public override int Hz => Input?.Hz ?? 0;

        public override long Duration => (long)(duration.TotalSeconds * Input?.Hz ?? 0) * 2;

        public SampleAudioEffectProcessor(SampleAudioEffect item, TimeSpan duration)
        {
            this.item = item;
            this.duration = duration;
        }

        protected override void seek(long position)
        {
            Input?.Seek(position);
        }

        protected override int read(float[] destBuffer, int offset, int count)
        {
            Input?.Read(destBuffer,offset,count);
            for (int i = 0; i < count; i+=2)
            {
                var volume = (float)item.Volume.GetValue((Position + i) / 2, Duration / 2, Hz);
                destBuffer[offset + i + 0] *= volume;
                destBuffer[offset + i + 1] *= volume;
            }
            return count;
        }
    }
}