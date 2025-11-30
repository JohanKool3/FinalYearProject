namespace FinalYearProject.Shared.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Gets the full path to a test file located in the TestData directory.
        /// </summary>
        /// <param name="fileName">Full Filename for the test e.g. 'test.wav'</param>
        /// <returns></returns>
        public static string GetTestFilePath(string fileName, string folderName)
        {
            return Path.Combine(AppContext.BaseDirectory, folderName, fileName);
        }
    }
}
