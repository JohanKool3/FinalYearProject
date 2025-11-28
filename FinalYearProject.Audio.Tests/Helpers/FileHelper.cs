
namespace FinalYearProject.Audio.Tests.Helpers
{
    internal static class FileHelper
    {
        /// <summary>
        /// Gets the full path to a test file located in the TestData directory.
        /// </summary>
        /// <param name="fileName">Full Filename for the test e.g. 'test.wav'</param>
        /// <returns></returns>
        internal static string GetTestFilePath(string fileName)
        {
            return Path.Combine(AppContext.BaseDirectory, "TestData", fileName);
        }
    }
}
