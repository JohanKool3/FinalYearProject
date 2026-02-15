namespace FinalYearProject.Services.Settings
{
    /// <summary>
    /// Holds settings related to the Input and Output IDs for
    /// Audio Recording Service
    /// </summary>
    public class AudioServiceSettings
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
        /// The Percentage of the Input Volume, 0 -> 100%
        /// </summary>
        public int InputVolumePercent { get; set; } = 100;

        /// <summary>
        /// The Percentage of the Output Volume, 0 -> 100%
        /// </summary>
        public int OutputVolumePercent { get; set; } = 100;

        /// <summary>
        /// How much time to wait before an input (in ms)
        /// </summary>
        public int InputLatency { get; set; }

        /// <summary>
        /// How much time to wait before outputting audio (in ms)
        /// </summary>
        public int OutputLatency { get; set; }


        public int MaxLatency => 1024;
    }
}
