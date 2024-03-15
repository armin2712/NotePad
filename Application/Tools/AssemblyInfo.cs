using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tools
{

    /// <summary>
    /// Provides Extension Methods to retrive Methdata
    /// like App name
    /// </summary>
    public static class AssemblyInfo:System.Object
    {
        #region Application Name

        /// <summary>
        /// Gives from the Assembly, that was used for 
        /// the Startup of the App, the Setting of
        /// AssemlbyProductAttribute back.
        /// </summary>
        /// <param name="source">The object that needs 
        /// the Info
        /// </param>
        /// <returns>Gives the Setting back or and empty
        /// string if the Attribute is not set up</returns>
        public static string GetAppName(this object source)
        {
            object[] Settings
                = System.Reflection.Assembly.GetEntryAssembly()!
                    .GetCustomAttributes(
                        typeof(System.Reflection
                            .AssemblyProductAttribute),
                        inherit: true);

            if(Settings.Length> 0)
            {
                return (Settings[0] as System.Reflection
                    .AssemblyProductAttribute)!.Product;
            }
            return string.Empty;


        }

        #endregion Application Name

        #region Assemlby Version

        /// <summary>
        /// Gives the Version from the Assembly
        /// </summary>
        /// <param name="source">The Object that
        /// needs the Info</param>
        /// <returns>Gives the App Major.Minor number
        /// back or an string.Empty if the Attribute
        /// is not set up</returns>
        public static string GetVersion(this object source)
        {
            var Version = System.Reflection.Assembly
                .GetEntryAssembly()!.GetName().Version!;

            return $"{Version.Major}.{Version.Minor}";
        }


        #endregion Assemlby Version

        #region Copyright

        /// <summary>
        /// Gives the AssemblyCopyrightAttribute
        /// of the Assembly back
        /// </summary>
        /// <param name="source">The Object that needs the
        /// Info</param>
        /// <returns>Gives an Setting back or
        /// string.Empty if the Attribute is not
        /// set up</returns>
        public static string GetCopyright(this object source)
        {
            object[] Settings
                = System.Reflection.Assembly.GetEntryAssembly()!
                    .GetCustomAttributes(
                        typeof(System.Reflection
                        .AssemblyCopyrightAttribute),
                        inherit: true);

            if (Settings.Length > 0)
            {
                return (Settings[0] as System.Reflection
                    .AssemblyCopyrightAttribute)!.Copyright;
            }
            return string.Empty;

        }

        #endregion Copyright
    }
}
