using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Components.Interfaces
{
    /// <summary>
    /// Defines a component that fetches data
    /// </summary>
    /// <typeparam name="T">The Type of Data that will be returned</typeparam>
    public interface IDataManager<T>
    {
        /// <summary>
        /// Get all the data for this manager
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);
    }
}
