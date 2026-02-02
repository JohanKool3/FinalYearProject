using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Shared.Models.Dtos
{
    public class TimeSignatureDto
    {
        /// <summary>
        /// How Many Beats are in a Measure (e.g. 4 for 4/4 time)
        /// </summary>
        public int BeatsPerMeasure { get; set; }


        /// <summary>
        /// How Many Note Value Constitutes One Beat (e.g. 4 for Quarter Note in 4/4 time)
        /// </summary>
        public int BeatUnit { get; set; }
    }
}
