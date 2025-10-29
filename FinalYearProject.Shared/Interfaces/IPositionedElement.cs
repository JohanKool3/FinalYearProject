namespace FinalYearProject.Shared.Interfaces
{
    public interface IPositionedElement
    {
        /// <summary>
        /// Defines the start position of the element within the bar as a percentage
        /// </summary>
        public double StartPercentage { get; set; }
    }
}
