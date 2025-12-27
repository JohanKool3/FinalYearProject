using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalYearProject.Audio.Helpers
{
    public static class FilepathHelper
    {
        /// <summary>
        /// Adds the current directory path to the given filename.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string GetCurrentDirectoryFilepath(string filename)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), filename);
        }
    }
}
