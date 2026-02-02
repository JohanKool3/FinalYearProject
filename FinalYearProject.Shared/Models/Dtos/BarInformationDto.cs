using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Shared.Models.Dtos
{
    public class BarInformationDto
    {
        /// <summary>
        /// The Beats Per Minute of this Bar
        /// </summary>
        public int Bpm { get; set; }

        /// <summary>
        /// The time signature of this bar
        /// </summary>
        public required TimeSignatureDto TimeSignature { get; set; }

        /// <summary>
        /// Holds Positional Information about this Bars place in the Tab
        /// as a whole
        /// </summary>
        public required PositionInTabDto Position { get; set; }

        /// <summary>
        /// The Note Groups that are a part of this Bar
        /// </summary>
        public required List<NoteGroupInformationDto> NoteGroups { get; set; }
    }
}
