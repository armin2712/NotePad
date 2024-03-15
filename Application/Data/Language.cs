using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    /// <summary>
    /// Provides a list of Application Languages
    /// </summary>
    public class Languages : System.Collections.Generic.List<Language>
    {

    }

    /// <summary>
    /// Describes an Application Language
    /// </summary>
    public class Language : System.Object
    {
        /// <summary>
        /// Calls the 2-place code for CultureInfo
        /// or sets it up
        /// </summary>
        public string Code { get; set; } = string.Empty;

        /// <summary>
        /// Calls the Name of the Language or
        /// sets it up
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Calls a Text with the Description 
        /// of this Language
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}(" +
                $"Code=\"{this.Code}\"," +
                $"Name=\"{this.Name}\")";
        }
    }
}
