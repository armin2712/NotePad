using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controller
{
    /// <summary>
    /// Provides an Service for Lanuguage 
    /// reading and writing
    /// in Xml-Format
    /// </summary>
    internal class LanguageXmlController:Application.Controller.XmlController<Data.Languages>
    {
        /// <summary>
        /// Returns a list with supported languages
        /// from the Assembly-Ressources
        /// </summary>
        /// <exception cref="System.Exception">
        /// if an error occurs while the procces is ongoing
        /// </exception>
        public Data.Languages GetFromRessource()
        {
            //Load the Ressource Language text
            //into an .Net XmlDocument
            var Xml=new System.Xml.XmlDocument();
            Xml.LoadXml(Application.Properties
                .Resources.Languages);

            //Initialize an Outcome list
            var Languages=new Data.Languages();

            //Mapp all Languages
            //found in the base element
            //into the Outcome list
            foreach(System.Xml.XmlNode s 
                in Xml.DocumentElement!.ChildNodes)
            {
                Languages.Add(new Data.Language
                {
                    Code = s.Attributes!["code"]!.Value,
                    Name = s.Attributes["name"]!.Value
                });
            }
            //Return the list
            return Languages;
        }
    }
}
