using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controller
{
    /// <summary>
    /// Provides an Service for serialisation in Xml form
    /// </summary>
    public class XmlController<T>:Application.AppObject where T : class
    {

        /// <summary>
        /// Serializes the list in Xml Format into the file
        /// </summary>
        /// <param name="path">The Path of the file</param>
        /// <param name="data">the list with data for 
        /// serialisation</param>
        /// /// <exception cref="System.Exception">
        /// if an error occurs while the procces is ongoing
        /// </exception>
        public void Save(string path, T data)
        {
            using var Writer=
                new System.IO.StreamWriter
               (path,append:false,System.Text.Encoding.UTF8);

            var Serializator=
                new System.Xml.Serialization
                .XmlSerializer(data!.GetType());

            Serializator.Serialize(Writer, data);
        }

        /// <summary>
        /// Returns the list with deserialized data
        /// </summary>
        /// <param name="path">Path of the Xml file</param>
        /// /// <exception cref="System.Exception">
        /// if an error occurs while the procces is ongoing
        /// </exception>
        public T Read(string path)
        {
            using var Reader
                =new System.IO.StreamReader
                (path,System.Text.Encoding .UTF8);

            var Serializator
                =new System.Xml.Serialization
                .XmlSerializer(typeof(T));

            return (Serializator.Deserialize(Reader) as T)!;

        }


    }
}
