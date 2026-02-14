using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.SampleProviders
{
    public class MetronomeSampleProvider : ISampleProvider
    {
        private readonly WaveFormat _waveFormat;
        private int _sample;
        private readonly int _samplesPerBeat;
        private readonly float _frequency = 1000f;

        public MetronomeSampleProvider(int bpm, int sampleRate, WaveFormat waveFormat)
        {
            _waveFormat = waveFormat;

            // Divided by 2 as there are two channels (Left and Right)
            _samplesPerBeat = (sampleRate * 60) / (bpm / 2);
        }

        public WaveFormat WaveFormat => _waveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            for (int n = 0; n < count; n++)
            {
                if (_sample % _samplesPerBeat < 2000)
                {
                    buffer[offset + n] =
                        (float)Math.Sin(2 * Math.PI * _frequency * _sample / _waveFormat.SampleRate) * 0.5f;
                }
                else
                {
                    buffer[offset + n] = 0;
                }

                _sample++;
            }

            return count;
        }
    }
}
