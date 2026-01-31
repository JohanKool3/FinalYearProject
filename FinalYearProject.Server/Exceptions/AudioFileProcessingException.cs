namespace FinalYearProject.Server.Exceptions
{
    public class AudioFileProcessingException : Exception
    {
        public AudioFileProcessingException()
        {
        }
        public AudioFileProcessingException(string message)
            : base(message)
        {
        }
    }
}
