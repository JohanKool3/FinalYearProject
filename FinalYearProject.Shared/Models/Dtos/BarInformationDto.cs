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
    }
}
