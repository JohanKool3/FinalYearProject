using FinalYearProject.Services.Interfaces;
using FinalYearProject.Shared.Models;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioBuses
{
    public class UserBus(UserSettings channelSettings) 
        : SubAudioBusBase(channelSettings)
    {
        public override string Name => "user-bus";
    }
}
