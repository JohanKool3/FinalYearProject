using FinalYearProject.Services.Interfaces;
using NAudio.Wave;

namespace FinalYearProject.Services.Audio.Windows.AudioSources
{
    public class UserInputSource : IAudioSource
    {
        public bool IsEnabled => throw new NotImplementedException();

        public string Name => "user-input-source";

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public ISampleProvider GetOutput()
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
