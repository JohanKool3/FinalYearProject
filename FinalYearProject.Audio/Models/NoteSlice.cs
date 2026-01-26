using FinalYearProject.Audio.Helpers;

namespace FinalYearProject.Audio.Models
{
    /// <summary>
    /// Represents a slice in time containing note confidence data.
    /// </summary>
    public class NoteSlice
    {
        /// <summary>
        /// The Time Stamp in Seconds of this Note Slice
        /// </summary>
        public double Time { get; set; }

        /// <summary>
        /// List of NoteConfidence objects representing the confidence levels 
        /// for various notes at this time slice.
        /// </summary>
        public List<NoteConfidence> NoteConfidences { get; set; } = [];

        public NoteSlice(double time, TuningScheme scheme)
        { 
            Time = time;
            var noteSlice = this;

            // Create NoteConfidence for each Midi Note from A0 to C8
            // A0 is the 21st semitone in midi scale
            // C8 is the 127th semitone in midi scale
            for (int semiTone = 21; semiTone < 128; semiTone++)
            {
                var noteName = SemitonesToNoteHelper
                    .ConvertToNoteName(semiTone);

                noteSlice.NoteConfidences.Add(new NoteConfidence
                {
                    Name = noteName,
                    FundamentalFrequencyBounds = GetNoteBounds(semiTone, scheme),
                    Confidence = 0.0f
                });
            }
        }

        private static Tuple<float, float> GetNoteBounds(float semiTone, TuningScheme scheme)
           => new(
               FrequencyToNoteHelper.GetFrequencyFromSemiTones(semiTone - 0.5f,
                   scheme.A4),
               FrequencyToNoteHelper.GetFrequencyFromSemiTones(semiTone + 0.5f,
                   scheme.A4));
    }
}
