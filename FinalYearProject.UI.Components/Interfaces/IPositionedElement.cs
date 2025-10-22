using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.UI.Components.Interfaces
{
    public interface IPositionedElement
    {
        /// <summary>
        /// Defines the position of the element within the bar as a percentage
        /// </summary>
        public int BarPercentage { get; set; }
    }
}
