﻿using YukkuriMovieMaker.Plugin.FileSource;

namespace SampleAudioSourcePlugin
{
    public class SampleAudioSource : IAudioFileSource
    {
        const int seconds = 1;
        const int hz = 44000;
        const int sampleCount = seconds * hz;

        /// <summary>
        /// 音声の長さ
        /// </summary>
        public TimeSpan Duration => TimeSpan.FromSeconds(1);

        /// <summary>
        /// サンプリングレート
        /// </summary>
        public int Hz => 44000;

        long position = 0;

        public int Read(float[] destBuffer, int offset, int count)
        {
            var maxCount = (int)Math.Max(0, (sampleCount - position) * 2);
            count = Math.Min(count, maxCount);

            for (int i = 0; i < count; i += 2)
            {
                var t = MathF.Sin(MathF.PI * 2 * (position + i) / Hz * 1000);
                destBuffer[offset + i] = MathF.Sin(t);
                destBuffer[offset + i + 1] = MathF.Sin(t);
            }
            position += count / 2;
            return count;
        }

        public void Seek(TimeSpan time)
        {
            position = (long)(Hz * time.TotalSeconds);
        }
        public void Dispose()
        {

        }
    }
}