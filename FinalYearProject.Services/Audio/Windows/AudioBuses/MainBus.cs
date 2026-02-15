using FinalYearProject.Services.Interfaces;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MainBus : IAudioBus
    {
        private List<IAudioSource> _audioSources = [];

        public void AddEffect(IAudioEffect effect)
        {
            throw new NotImplementedException();
        }

        public void AddSource(IAudioSource source)
        {
            if (source == null)
            {
                return;
            }
            _audioSources.Add(source);
        }

        public void AdjustVolume(double volume)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISampleProvider GetOutput()
        {
            throw new NotImplementedException();
        }

        public void RemoveEffect(IAudioEffect effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveSource(IAudioSource source)
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
