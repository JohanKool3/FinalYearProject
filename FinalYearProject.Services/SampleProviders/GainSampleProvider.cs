using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.SampleProviders
{
    using NAudio.Wave;

    public class GainSampleProvider(ISampleProvider source) : ISampleProvider
    {
        private readonly ISampleProvider _source = source;

        public float Gain { get; set; } = 1.0f;

        public WaveFormat WaveFormat 
            => _source.WaveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            int samplesRead = _source.Read(buffer, offset, count);

            for (int n = 0; n < samplesRead; n++)
            {
                buffer[offset + n] *= Gain;
            }

            return samplesRead;
        }
    }
}
