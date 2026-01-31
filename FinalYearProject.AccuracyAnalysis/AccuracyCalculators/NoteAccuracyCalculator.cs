using FinalYearProject.Accuracy.Analysis.Interfaces;
using FinalYearProject.Accuracy.Analysis.Models;
using FinalYearProject.Audio.Helpers;
using FinalYearProject.Audio.Models;
using FinalYearProject.Shared.Models.Dtos;

namespace FinalYearProject.Accuracy.Analysis.AccuracyCalculators
{
    public class NoteAccuracyCalculator(AccuracySettings requiredConfidence) : IAccuracyCalculator
    {
        public float RequiredConfidence { get; set; } = requiredConfidence.RequiredNoteConfidence;

        /// <summary>
        /// Calculates the accuracy of the player's notes compared to the expected notes.
        /// </summary>
        /// <param name="playerTimeline"></param>
        /// <param name="expectedTimeline"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public float CalculateAccuracy(
            NoteTimeline playerTimeline, 
            ReferenceTabDto expectedTimeline)
        {
            // 1. Iterate over each NoteGroup in the expected timeline
            // 2. For each note in the note group, check if the player hit the note at the correct time
            // 3. Calculate accuracy based on timing and correctness of notes hit
            int totalNotes = 0;
            int correctNotes = 0;

            foreach(var noteGroup in expectedTimeline.NoteGroups)
            {
                var noteGroupStartTime = noteGroup.StartTime;

                // Get the notes at the start of the player's timeline
                var startTimeNotes = NoteTimelineHelper
                    .GetNotesAtTime(
                        playerTimeline,
                        noteGroupStartTime,
                        RequiredConfidence);

                if (startTimeNotes is null)
                {
                    // No Notes found, therefore all notes in this group are missed
                    totalNotes += noteGroup.Notes.Count;
                    continue;
                }

                // Check the difference in the amount of notes in the group vs played
                if(noteGroup.Notes.Count < startTimeNotes.Count)
                {
                    // More notes played than expected, penalize
                    correctNotes -= (startTimeNotes.Count - noteGroup.Notes.Count);
                }
                else if(noteGroup.Notes.Count > startTimeNotes.Count)
                {
                    // Less notes played than expected, penalize
                    correctNotes -= (noteGroup.Notes.Count - startTimeNotes.Count);
                }


                foreach (var note in noteGroup.Notes)
                    {
                        totalNotes++;

                        // Note was expected and played, reward
                        if (startTimeNotes.Contains(note.Name))
                        {
                            correctNotes++;
                        }

                        // Note was not expected but played, penalize
                        else
                        {
                            correctNotes--;
                        }
                    }
            }

            // Calculate accuracy as a percentage
            if(correctNotes < 0)
            {
                return 0f;
            }

            return (float)correctNotes / totalNotes;
        }
    }
}
