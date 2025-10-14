namespace FinalYearProject.Shared.Models.TabRepresentation
{
    /// <summary>
    /// A single note in a tablature representation
    /// </summary>
    public class MusicalNote
    {
        public MusicalNote(int stringNumber, int fretNumber, double startTime, double duration)
        {
            // TODO: Allow user to customize this to allow for 7 string guitars etc.
            // Most likely this will need to be done through DI and a settings service
            ValidateInput(stringNumber, fretNumber, startTime, duration);

            StringNumber = stringNumber;
            FretNumber = fretNumber;
            StartTime = startTime;
            Duration = duration;
        }

        /// <summary>
        /// // Check Validity of Inputs
        /// </summary>
        /// <param name="stringNumber">String where this note will be played</param>
        /// <param name="fretNumber">Fret where this note will be played</param>
        /// <param name="startTime">When the note started (in beats)</param>
        /// <param name="duration">How long this note will last</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static void ValidateInput(int stringNumber, int fretNumber, double startTime, double duration)
        {
            if (stringNumber <= 0 || stringNumber > 6)
            {
                throw new ArgumentOutOfRangeException(nameof(stringNumber),
                    "String number must be between 1 and 6, or null for a rest.");
            }

            if (fretNumber < 0 || fretNumber > 30)
            {
                throw new ArgumentOutOfRangeException(nameof(fretNumber),
                    "Fret number must be between 0 and 24.");
            }

            if (startTime < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(startTime),
                    "Start time must be greater than or equal to 0.");
            }

            if (duration <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(duration),
                    "Duration must be greater than 0.");
            }
        }

        /// <summary>
        /// 1 = high E, 6 = low E, If null then it is a rest
        /// </summary>
        public int StringNumber { get; private set; }

        /// <summary>
        /// The fret for this note
        /// </summary>
        public int FretNumber { get; private set; }

        /// <summary>
        /// When the note started in the unit of Beats
        /// </summary>
        /// <remarks>
        /// So for 4/4 [1, 2, 3, 4] are the whole beats
        /// For 6/8 [1, 2, 3, 4, 5, 6] are the whole beats
        /// </remarks>
        public double StartTime { get; private set; }

        /// <summary>
        /// How long the note will last in the lowest division
        /// </summary>
        /// <remarks>
        /// For 4 /4 this is a Crotchet (quarter note) = 1
        /// For 6/ 8 this is a Quaver (eighth note) = 1
        /// </remarks>
        public double Duration { get; private set; }

        //  TODO: Implement Articulation and Note Qualities
        //public required Articulation Articulation { get; set; }
    }
}
