using FinalYearProject.Audio.AudioAnalysis.FrequencyTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.NoteTimelineConstructors;
using FinalYearProject.Audio.AudioAnalysis.Readers;
using FinalYearProject.Audio.AudioAnalysis.Windowers;
using FinalYearProject.Audio.Enums;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FinalYearProject.Audio.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAudioAnalysisServices(this IServiceCollection services
            , ServiceType type)
        {
            switch (type)
            {
                case ServiceType.Simple:
                    LoadSimpleServices(services);
                    break;

                // By Default load Simple Services
                default:
                    LoadSimpleServices(services);
                    break;
            }

            // Add Audio Analysis Pipeline Service
            services.AddSingleton<AudioAnalysisPipelineService>();

            return services;
        }

        private static void LoadSimpleServices(IServiceCollection services)
        {
            services.AddSingleton<IAudioReader, WavFileReader>();
            services.AddSingleton<IWindower, SimpleWindower>();
            services.AddSingleton<IFrequencyTimelineConstructor, SimpleFrequencyTimelineConstructor>();
            services.AddSingleton<INoteTimelineConstuctor, SimpleNoteTimelineConstructor>();
        }
    }
}
