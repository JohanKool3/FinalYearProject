using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.Shared.Models;
using FinalYearProject.Shared.Services;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioEffects;
using FinalYearProject.UI.Components.Services.Audio.Windows.AudioSources;
using NAudio.Wave;

namespace FinalYearProject.UI.Components.Services.Audio.Windows.AudioBuses
{
    public class UserBus(UserSettings channelSettings,
        AudioServiceSettings audioSettings,
        PlaybackService playbackService)
        : SubAudioBusBase<UserInputSource>(channelSettings)
        
    {
        public override string Name => "user-bus";

        public AudioServiceSettings AudioSettings { get; } = audioSettings;

        public override UserInputSource? Source { get; internal set; }
        = new UserInputSource(audioSettings, playbackService);

        public override ISampleProvider? GetOutput()
        {
            if (!IsEnabled)
            {
                return null;
            }

            Effects.Clear();

            Effects.AddRange(GetUserEffectsChain());

            return base.GetOutput();
        }

        private IEnumerable<IAudioEffect> GetUserEffectsChain()
        {
            List<IAudioEffect> output = [];

            var preFXGain = new PreFXGainEffect()
            {
                GainPercentage = Settings.UserVolume,
            };

            output.Add(preFXGain);

            return output;
        }
    }
}
