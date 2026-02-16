using FinalYearProject.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Shared.Models
{
    /// <summary>
    /// Holds Settings Related to the user
    /// <list type="number">
    /// <item>Active Slider - Which slider is being used, prevents others from being modified</item>>
    /// <item>User Input Channel - The channel that deals with audio input from the user</item>
    /// <item>Backing Track Channel - The channel that deals with audio from the backing track</item>
    /// <item>Metronome Channel - The channel that deals with audio from the metronome</item>
    /// </list>
    /// </summary>
    public class UserSettings
    {
        /// <summary>
        /// Holds which Channel is currently being modified (prevents
        /// overlapping UIs)
        /// </summary>
        public Slider? ActiveSlider { get; set; }

        /// <summary>
        /// The Percentage Multiplier for BPM
        /// </summary>
        public int BpmPercentage { get; set; } = 100;

        /// <summary>
        /// Volume Percentage of the User Channel, 0% -> 100%
        /// </summary>
        public int UserVolume { get; set; } = 100;

        /// <summary>
        /// Volume Percentage of the Backing Track Channel, 0% -> 100%
        /// </summary>
        public int BackingTrackVolume { get; set; } = 100;

        /// <summary>
        /// Volume percentage of the Metronome Channel, 0% -> 100%
        /// </summary>
        public int MetronomeVolume { get; set; } = 100;
    }
}
