using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Recording;

namespace FinalYearProject.UI.Helpers
{
    public static class DefaultSettingsHelper
    {

        /// <summary>
        /// Set Default settings for the Audio Recording Service
        /// </summary>
        /// <param name="settings"></param>
        /// <param name="recordingService"></param>
        public static void SetDefaultAudioRecordingServiceSettings(
            AudioRecordingServiceSettings settings, 
            IAudioRecordingService recordingService)
        {
            var inputDevices = recordingService.GetInputDevices();

            var outputDevices = recordingService.GetOutputDevices();

            if (inputDevices is not null && inputDevices.Count > 0)
            {
                settings.InputDeviceId = inputDevices[0].Id;
            }

            if (outputDevices is not null && outputDevices.Count > 0)
            {
                settings.OutputDeviceId = outputDevices[0].Id;
            }
        }
    }
}
