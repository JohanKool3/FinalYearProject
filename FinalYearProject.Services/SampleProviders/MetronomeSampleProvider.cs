using NAudio.Wave;

namespace FinalYearProject.Services.SampleProviders
{
    public class MetronomeSampleProvider(int bpm, WaveFormat? waveFormat) : ISampleProvider
    {
        private readonly WaveFormat? _waveFormat = waveFormat;
        private int _sample;
        private readonly int _samplesPerBeat = ((waveFormat?.SampleRate ?? 1) * 60) / (bpm / 2);
        private readonly float _frequency = 1000f;

        public WaveFormat? WaveFormat => _waveFormat;

        public int Read(float[] buffer, int offset, int count)
        {
            if(_waveFormat is null)
            {
                // TODO: Log this exception
                return 0;
            }

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
