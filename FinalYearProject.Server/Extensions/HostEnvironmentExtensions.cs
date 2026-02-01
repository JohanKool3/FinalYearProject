namespace FinalYearProject.Server.Extensions
{
    public static class HostEnvironmentExtensions
    {
        public static bool IsTest(this IHostEnvironment hostEnvironment)
        {
            return hostEnvironment == null
                ? throw new ArgumentNullException(nameof(hostEnvironment))
                : hostEnvironment.EnvironmentName == "Test";
        }
    }
}
