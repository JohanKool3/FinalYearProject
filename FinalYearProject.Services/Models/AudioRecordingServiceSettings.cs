using FinalYearProject.Services.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.Services.Models
{
    /// <summary>
    /// Holds settings related to the Input and Output IDs for
    /// Audio Recording Service
    /// </summary>
    public class AudioRecordingServiceSettings
    {
        /// <summary>
        /// The ID of the Input Device
        /// </summary>
        public string InputDeviceId { get; set; } = string.Empty;

        /// <summary>
        /// The ID of the Output Device
        /// </summary>
        public string OutputDeviceId { get; set; } = string.Empty;

        /// <summary>
        /// The Sample Rate of the Recording (Higher is more precise
        /// but slower)
        /// </summary>
        public SampleRate SampleRate { get; set; } = SampleRate.Standard;
    }
}
