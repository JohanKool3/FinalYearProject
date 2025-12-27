using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Models
{
    public class AudioFileMetadata
    {
        /// <summary>
        /// How many channels of audio
        /// </summary>
        public int Channels { get; set; }

        /// <summary>
        /// How many samples are captured per second
        /// </summary>
        public int SampleRate { get; set; }
    }
}
