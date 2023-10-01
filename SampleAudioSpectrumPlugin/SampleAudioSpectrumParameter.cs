using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using YukkuriMovieMaker.Commons;
using YukkuriMovieMaker.Controls;
using YukkuriMovieMaker.Exo;
using YukkuriMovieMaker.Plugin.Shape;
using YukkuriMovieMaker.Project;
using YukkuriMovieMaker.UndoRedo;

namespace SampleAudioSpectrumPlugin
{
    internal class SampleAudioSpectrumParameter : AudioSpectrumParameterBase
    {
        [Display(Name = "サイズ", Description = "大きさ")]
        [AnimationSlider("F0", "px", 0, 100)]
        public Animation Size { get; } = new Animation(100, 0, 1000);


        public SampleAudioSpectrumParameter(SharedDataStore? sharedData) : base(sharedData)
        {

        }
        public override IAudioSpectrumSource CreateShapeSource(IGraphicsDevicesAndContext devices)
        {
            return new SampleAudioSpectrumSource(devices, this);
        }

        public override IEnumerable<string> CreateMaskExoFilter(int keyFrameIndex, ExoOutputDescription desc, ShapeMaskExoOutputDescription shapeMaskParameters, AudioSpectrumExoOutputDescription spectrumParameters)
        {
            return Enumerable.Empty<string>();
        }

        public override IEnumerable<string> CreateShapeItemExoFilter(int keyFrameIndex, ExoOutputDescription desc, AudioSpectrumExoOutputDescription spectrumParameters)
        {
            return Enumerable.Empty<string>();
        }


        protected override IEnumerable<IAnimatable> GetAnimatables() => new IAnimatable[] { Size };

        protected override void LoadSharedData(SharedDataStore store)
        {
            var data = store.Load<SharedData>();
            if (data is null)
                return;
            data.Apply(this);
        }

        protected override void SaveSharedData(SharedDataStore store)
        {
            store.Save(new SharedData(this));
        }

        class SharedData
        {
            Animation Size { get; } = new Animation(100, 0, 1000);
            public SharedData(SampleAudioSpectrumParameter parameter)
            {
                Size.CopyFrom(parameter.Size);
            }
            public void Apply(SampleAudioSpectrumParameter parameter)
            {
                parameter.Size.CopyFrom(Size);
            }
        }
    }
}