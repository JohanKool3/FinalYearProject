using FinalYearProject.Services.Interfaces;
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
            services.AddSingleton<AudioRecordingServiceSettings>();


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
            // TODO: Add Relevent services
        }
    }
}
