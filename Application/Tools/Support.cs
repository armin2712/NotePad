using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{
    /// <summary>
    /// Provides Support Methods 
    /// </summary>
    public static class Support:System.Object
    {
        /// <summary>
        /// Returns the text supplemented by 
        /// any existing language folder
        /// </summary>
        /// <param name="base">The Path, that needs to be
        /// checked, if a localized subfolder for the 
        /// current culture exists</param>
        /// <returns></returns>
        public static string GetLocalization(this string @base)
        {
            //Get Culture
            var Culture = System.Globalization.CultureInfo
                .CurrentCulture.Name;

            //Check if in the Base an Folder
            //with this Culture exists 
            while (!System.IO.Directory.Exists(
                System.IO.Path.Combine(@base, Culture))
                && Culture.Length > 0)
            {
                //If not get rid of the Subculture
                var LastHyphen = Culture.LastIndexOf('-');
                if (LastHyphen == -1)
                {
                    Culture = string.Empty;
                }
                else
                {
                    Culture = Culture.Substring(0, LastHyphen);
                }

            }
                //If all Cultures are checked return Original
                return System.IO.Path .Combine(@base,Culture);
        }
    }
}
