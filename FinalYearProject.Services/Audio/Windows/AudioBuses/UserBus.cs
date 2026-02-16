using FinalYearProject.Services.Audio.Windows.AudioSources;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Settings;
using FinalYearProject.Shared.Models;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class UserBus(UserSettings channelSettings,
        AudioServiceSettings audioSettings)
        : SubAudioBusBase<UserInputSource>(channelSettings)
        
    {
        public override string Name => "user-bus";

        public AudioServiceSettings AudioSettings { get; } = audioSettings;

        public override UserInputSource? Source { get; internal set; }
        = new UserInputSource(audioSettings);

        public override ISampleProvider? GetOutput()
        {
            if (!IsEnabled)
            {
                return null;
            }

            return Source?.GetOutput();
        }
    }
}
