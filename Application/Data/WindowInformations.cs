using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Data
{
    /// <summary>
    /// Provides an List of WindowInformation objects
    /// </summary>
    public class WindowInformations
        :System.Collections.Generic
        .List<WindowInformation>
    {
    }

    /// <summary>
    /// Provides the Information of an 
    /// Application Window, for example the Position,
    /// Size and Condition
    /// </summary>
    public class WindowInformation : System.Object
    {
        /// <summary>
        /// Calls the intern Description of a Window
        /// or sets it up
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Calls the Window Condition(Normal,Max,Min)
        /// or sets it up
        /// </summary>
        public int Condition { get; set; }

        /// <summary>
        /// Calls the left Position of the Window
        /// or sets it up
        /// </summary>
        public int? Left { get; set; } = null;

        /// <summary>
        /// Calls the right Position of the Window
        /// or sets it up
        /// </summary>
        public int? Right { get; set; }= null;

        /// <summary>
        /// Calls the top Position of the Window
        /// or sets it up
        /// </summary>
        public int? Top { get; set; }=null;

        /// <summary>
        /// Calls the Height of the Window or 
        /// sets it up
        /// </summary>
        public int? Height { get; set;} = null;

        /// <summary>
        /// Calls the Width of the Window or 
        /// sets it up
        /// </summary>
        public int? Width { get; set;}=null;


        /// <summary>
        /// Returns a Text that describes
        /// this WindowInformation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.GetType().Name}(Name=\"{this.Name}\")";
        }
    }
}
