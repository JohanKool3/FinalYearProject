using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.Exceptions
{
    public class AudioDataWriterNullException : Exception
    {
        public AudioDataWriterNullException()
        {
            
        }

        public AudioDataWriterNullException(string message): base(message)
        {
            
        }
    }
}
