using FinalYearProject.Services.Interfaces;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio.Windows.AudioSources
{
    public class BackingTrackSource : IAudioSource
    {
        public bool IsEnabled => throw new NotImplementedException();

        public string Name => "backing-track-source";

        public ISampleProvider? SampleProvider => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISampleProvider GetOutput()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
