using FinalYearProject.Server.Exceptions;
using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Server.Helpers
{
    public static class SettingsSubSectionHelper
    {
        /// <summary>
        /// Checks Configuration for a section and binds its 
        /// subsection to the specified settings type.
        /// </summary>
        /// <typeparam name="T">The Settings Type to be bound to</typeparam>
        /// <param name="configuration">The main Configuration container</param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static T GetSettingsSubSection<T>(
            this IConfiguration configuration)
            where T : ISetting
        {

            var section = configuration.GetSection(typeof(T).Name);

            var settings = section.Get<T>();

            return settings == null
                ? throw new ConfigurationFailureException($"Could not bind settings for {nameof(T)}")
                : settings;
        }
    }
}
