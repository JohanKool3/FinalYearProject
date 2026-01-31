using FinalYearProject.Shared.Interfaces;

namespace FinalYearProject.Audio.Models
{
    public class DetectionSettings : ISetting
    {
        public int WindowSize { get; set; }
        
        public int HopSize { get; set; }

        public float NoteDetectionThreshold { get; set; }
    }
}