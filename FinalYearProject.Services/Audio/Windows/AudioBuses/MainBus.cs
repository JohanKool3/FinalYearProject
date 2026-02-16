using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Services;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class MainBus(PlaybackService playback)
    {
        private List<ISubAudioBus<IAudioSource>> _audioSources = [];

        /// <summary>
        /// Whether Audio should be played or not
        /// </summary>
        public bool IsEnabled { get; private set; } = true;

        public PlaybackService Playback { get; } = playback;

        public string Name => "main-bus";

        /// <summary>
        /// The Mixer for this Audio Bus
        /// </summary>
        private WaveFormat? _waveFormat;

        #region Add and Remove

        public void AddEffect(IAudioEffect effect)
        {
            throw new NotImplementedException();
        }

        public void AddSource(ISubAudioBus<IAudioSource> source)
        {
            if (source == null)
            {
                return;
            }

            _audioSources.Add(source);
        }

        public void RemoveEffect(IAudioEffect effect)
        {
            throw new NotImplementedException();
        }

        public void RemoveSource(IAudioSource source)
        {
            throw new NotImplementedException();
        }

        #endregion

        public ISampleProvider? GetOutput()
        {
            if(_waveFormat is null)
            {
                return null;
            }

            var mixer = new MixingSampleProvider(_waveFormat)
            {
                ReadFully = true
            };

            foreach (var input in _audioSources)
            {
              
                // Not Enabled, don't add output
                if (!input.IsEnabled)
                {
                    continue;
                }

                // Playback is not in process
                // User channel should always be playing if enabled
                if(!Playback.IsPlaying && input.Name != "user-bus")
                {
                    continue;
                }

                input.Start();
                var inputSampleProvider = input.GetOutput();

                // Cannot get output as it is null,
                // TODO: Log this
                if(inputSampleProvider is null)
                {
                    continue;
                }

                // Check that playback is happening 

                mixer.AddMixerInput(inputSampleProvider);
            }

            return mixer;
        }



        public void SetMixer(WaveFormat waveFormat)
        {
            // As the Main Bus needs to be dynamic (as to allow
            // for different waveformats to be consolidated into
            // a single one), we will set the mixer at the Get Output stage
            _waveFormat = waveFormat;

            // Notify Mixers of the Lower Level Busses to use the new 
            // wave format
            foreach(var source in _audioSources)
            {
                if(source.Name == "user-bus")
                {
                    // Needs to skip to use its own Wave Format
                    continue;
                }

                source.SetMixer(waveFormat);
            }
        }

        public void ToggleActive()
        {
            IsEnabled = !IsEnabled;
        }
    }
}
