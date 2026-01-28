namespace FinalYearProject.Audio.Models
{
    public class DetectionSettings
    {
        public int WindowSize { get; set; }
        
        public int HopSize { get; set; }

        public float NoteDetectionThreshold { get; set; }
    }
}