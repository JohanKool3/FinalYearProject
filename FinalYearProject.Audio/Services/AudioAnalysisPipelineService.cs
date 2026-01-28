using FinalYearProject.Audio.AudioAnalysis.Fft;
using FinalYearProject.Audio.Exceptions;
using FinalYearProject.Audio.Interfaces;
using FinalYearProject.Audio.Models;

namespace FinalYearProject.Audio.Services
{
    /// <summary>
    /// Service responsible for orchestrating the audio analysis pipeline
    /// </summary>
    /// <param name="reader">The component that will read audio data from a file</param>
    /// <param name="windower">The component that will split full audio stream into chunks</param>
    /// <param name="frequencyConstructor">The component that will create a frequency, magnitude over time representation</param>
    /// <param name="noteConstructor">The component that will create a note over time representation</param>
    /// <param name="noteDetector">The component that will detect notes from frequency set</param>
    /// <param name="tuningScheme">The tuning scheme for the current session (e.g. A4 = 440)</param>
    /// <param name="settings">Settings that determine how sensitive note detection is</param>
    public class AudioAnalysisPipelineService(
        IAudioReader reader,
        IWindower windower,
        IFrequencyTimelineConstructor frequencyConstructor,
        INoteTimelineConstuctor noteConstructor,
        INoteDetector noteDetector,
        TuningScheme tuningScheme,
        DetectionSettings settings)
    {
        #region Dependencies

        public IAudioReader Reader { get; } = reader;
        
        public IWindower Windower { get; } = windower;
        
        public IFrequencyTimelineConstructor FrequencyConstructor { get; } = frequencyConstructor;
        
        public INoteTimelineConstuctor NoteConstructor { get; } = noteConstructor;
        
        public INoteDetector NoteDetector { get; } = noteDetector;
        
        public TuningScheme TuningScheme { get; } = tuningScheme;
        
        public DetectionSettings Settings { get; } = settings;

        #endregion

        /// <summary>
        /// Takes a file path to an audio file, and runs it through the analysis pipeline
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="AudioAnalysisPipelineException"></exception>
        public NoteTimeline AnalyzeAudioFile(string filePath)
        {
            // 1. Read audio data from file
            var audioData = Reader.ReadAudioFile(filePath)
                ?? throw new AudioAnalysisPipelineException(1,
                $"Unable to load data from {filePath}");

            var fileMetadata = Reader.ReadAudioFileMetadata(filePath) 
                ?? throw new AudioAnalysisPipelineException(1, 
                $"Unable to read audio file metadata from {filePath}");

            // 2. Window the audio data
            var windows = Windower.ConvertPCMStreamToWindows(
                audioData,
                Settings.WindowSize, 
                Settings.HopSize,
                fileMetadata.SampleRate)
                ?? throw new AudioAnalysisPipelineException(2,
                "Failed to convert PCM Stream (Audio Data) to windows");

            // 3. Run DSP over windows
            var fftOutput = FftAnalyzer.BatchConvertToFrequencyDomain(
                windows,
                fileMetadata.SampleRate) 
                ?? throw new AudioAnalysisPipelineException(3,
                "FFT analysis failed. Couldn't convert windows to Frequency Domain");

            // 4. Construct frequency timeline
            var frequencyTimeline = FrequencyConstructor.GenerateTimeline(fftOutput)
                ?? throw new AudioAnalysisPipelineException(4,
                "Frequency Timeline Construction failed.") ;

            // 5. Construct note timeline
            var noteTimeline = NoteConstructor.GenerateTimeline(
                frequencyTimeline,
                Settings.NoteDetectionThreshold)
                ?? throw new AudioAnalysisPipelineException(5,
                "Note Timeline Construction failed.");

            return noteTimeline;
        }
    }
}
