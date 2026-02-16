using FinalYearProject.Services.Interfaces;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MainBus : IAudioBus
    {
        private List<IAudioSource> _audioSources = [];

        /// <summary>
        /// Whether Audio should be played or not
        /// </summary>
        public bool IsEnabled { get; private set; } = true;

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

        public void AdjustVolume(int volume)
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
            if (!IsEnabled)
            {
                return;
            }

            foreach (var source in _audioSources)
            {
                source.Start();
            }
        }

        public void Stop()
        {
            if (!IsEnabled)
            {
                return;
            }

            foreach (var source in _audioSources)
            {
                source.Stop();
            }
        }

        public void ToggleActive()
        {
            // Stop All Sources, then toggle
            Stop();
            IsEnabled = !IsEnabled;

        }
    }
}
