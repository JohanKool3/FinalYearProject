using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// Defines a component that loads audio files
    /// </summary>
    public interface IAudioReader
    {

        public List<float> ReadAudioFile(string filepath);
    }
}
