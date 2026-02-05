using FinalYearProject.Api.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalYearProject.UI.Components.Helpers
{
    internal static class ApiRequestHelper
    {
        /// <summary>
        /// Converts a set of parameters into a request model for Audio Accuracy Analysis
        /// </summary>
        /// <param name="pieceId"></param>
        /// <param name="filename"></param>
        /// <param name="audioData"></param>
        /// <returns></returns>
        internal static RequestAnalysisData GenerateAnalysisRequestData(
            Guid pieceId,
            string filename,
            Stream audioData)
            => new()
            {
                // TODO: Ensure that this data is valid before sending it
                PieceId = pieceId,
                FileName = filename,
                AudioData = audioData
            };
    }
}
