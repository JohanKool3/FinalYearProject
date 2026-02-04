using FinalYearProject.Audio.Helpers;
using FinalYearProject.EfCore.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Server.Helpers
{
    public static class DisplayToLogicConverter
    {
        internal static ReferenceTabDto ConvertModelToTab(PieceModel piece)
        {
            var referenceTab = new ReferenceTabDto()
            {
            };

            var bars = piece
                .TabInformationModel
                .Bars;

            // Where the Note/Notes appear in relation to time
            var currentTime = 0f;

            foreach (var bar in bars)
            {
                // Fetch BPM and Time Signature Information
                var barBpm = bar.Bpm;
                var barTimeSignature = bar.TimeSignature;

                // Iterate over each Note Group within the bar
                foreach (var noteGroup in bar.NoteGroups)
                {
                    // Get the Notes and when they start and end
                    var startTime = currentTime;

                    var endTime = GetTime(noteGroup.TotalGroupBeatLength,
                        barBpm,
                        barTimeSignature,
                        currentTime);

                    var notes = GetNotes(noteGroup.Notes);

                    referenceTab.NoteGroups.Add(
                        new()
                        {
                            Chords = [],// TODO: Fix this to fetch the correct chords
                            Notes = notes,
                            StartTime = startTime,
                            EndTime = endTime,
                        });

                    currentTime = endTime;
                }
            }

            return referenceTab;
        }

        /// <summary>
        /// Converts a list of notes from Guitar form (string and fret) to midi
        /// note names
        /// </summary>
        /// <param name="notes"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static List<ExpectedNoteDto> GetNotes(List<NoteModel> notes)
        {
            List<ExpectedNoteDto> output = [];

            foreach (var note in notes)
            {
                output.Add(new ExpectedNoteDto()
                {
                    Name = GetMidiName(note),
                });
            }


            return output;
        }

        /// <summary>
        /// Converts String Number and Fret to Midi Name
        /// e.g. Fret 0 String 1 => E2
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static string GetMidiName(NoteModel note)
        {
            // Get the String name and get the midi index.
            // Add Semitones equal to the fret number
            var stringMidiDictionary = GetStringMidiDictionary();

            var stringMidiNumber = stringMidiDictionary[note.StringNumber];
            var noteMidiNumber = stringMidiNumber + note.FretNumber;

            return SemitonesToNoteHelper.ConvertToNoteName(noteMidiNumber);
        }

        /// <summary>
        /// Gets the Midi Numbers of the open strings on a Guitar
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static Dictionary<int, int> GetStringMidiDictionary()
        {
            //TODO: Extend this for Different tuning schemes
            return new()
            {
                { 1, 64 },
                { 2, 59 },
                { 3, 55 },
                { 4, 50 },
                { 5, 45 },
                { 6, 40 },
            };
        }

        /// <summary>
        /// Gets the time at which a note occurs in seconds
        /// </summary>
        /// <param name="barPercentage">Where in the bar this note takes place</param>
        /// <param name="barTimeSignature">The time signature of this bar</param>
        /// <param name="currentTime">Current Time (the end time of the last group)</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static float GetTime(double groupLength,
            int barBpm,
            TimeSignatureModel barTimeSignature,
            float currentTime)
        {
            // How long in seconds a Beat lasts
            float timeOfABeat = 60f / barBpm;

            var groupLengthInSeconds = timeOfABeat * groupLength;

            return currentTime + (float)groupLengthInSeconds;

        }
    }
}
