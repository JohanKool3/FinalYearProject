namespace FinalYearProject.Shared.Models.AudioRepresentation
{
    /// <summary>
    /// Holds information from a Fast Fourier Transform operation
    /// </summary>
    public class FftResult
    {
        public double[] Magnitudes { get; set; } = [];

        public double[] Frequencies { get; set; } = [];
    }
}
