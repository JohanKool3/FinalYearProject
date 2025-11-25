namespace FinalYearProject.Audio.Interfaces
{
    /// <summary>
    /// Defines a Component that converts audio data into frames for analysis.
    /// </summary>
    public interface IAudioFrameProvider
    {
        bool TryGetFrame(float[] buffer);
    }
}
