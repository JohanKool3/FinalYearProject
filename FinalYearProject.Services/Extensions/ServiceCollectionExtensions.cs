using FinalYearProject.Services.Audio;
using FinalYearProject.Services.Audio.Windows.AudioBuses;
using FinalYearProject.Services.Interfaces;
using FinalYearProject.Services.Models;
using FinalYearProject.Services.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui.Devices;

namespace FinalYearProject.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAudioServices(
            this IServiceCollection services,
            IDeviceInfo deviceInfo)
        {
            // Based on the Device Platform, add the relevant recording service.
            // At the moment, this will only support Windows but in the future,
            // this can be extended to include platforms such as MAC and Android

            // Register Settings as they are platform independent
            services.AddSingleton<AudioServiceSettings>();


            if (deviceInfo.Platform == DevicePlatform.WinUI)
            {
                RegisterWindowsServices(services);
            }

            else
            {
                throw new PlatformNotSupportedException("Platform is not currently supported");
            }

            return services;
        }

        private static void RegisterWindowsServices(IServiceCollection services)
        {
            // Register the 4 Busses
            // (so that they can be modified in the UI)
            services.AddSingleton<MainBus>();
            services.AddSingleton<UserBus>();
            services.AddSingleton<BackingTrackBus>();
            services.AddSingleton<MetronomeBus>();

            // Register main Service
            services.AddSingleton<IAudioService, WindowsAudioService>();
        }
    }
}
