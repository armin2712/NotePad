using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    /// <summary>
    /// Provides an Service for Language handling
    /// </summary>
    public class LanguageManager:AppObject
    {
        #region Controller
        /// <summary>
        /// Internal Field for the property
        /// </summary>
        private Controller.LanguageXmlController
            _Controller = null!;

        /// <summary>
        /// Calls the Service for reading and writing
        /// of the Languages
        /// </summary>
        private Controller.LanguageXmlController Controller
        {
            get
            {
                if(this._Controller == null)
                {
                    this._Controller
                        = this.Context.Produce
                        <Application.Controller.LanguageXmlController>();
                }
                return this._Controller;

            }
        }
        #endregion Controller

        #region Supported Languages
        /// <summary>
        /// Internal field for supported languages
        /// </summary>
        private Data.Languages _List=null!;

        /// <summary>
        /// Calls the List of the Supported Languages
        /// </summary>
        public Data.Languages List
        {
            get
            {
                if( this._List == null)
                {
                    try
                    {
                        var LinqQuery
                            = from s in this.Controller
                              .GetFromRessource()
                              orderby s.Name select s;
                        this._List = new Data.Languages();
                        this._List.AddRange(LinqQuery);
                    }
                    catch (System.Exception ex) 
                    {
                        this.OnErrorOccured(
                            new ErrorOccurredEventArgs(ex));
                        //Is there so the falsy Ressource won't
                        //be readed again
                        this._List=new Data.Languages();
                    }
                   
                }
                return this._List;
            }
        }
        #endregion Supported Languages

        #region Current Language

        /// <summary>
        /// Sets a language as the current language
        /// </summary>
        /// <param name="code">Iso2Code of the language
        /// that will be set as the current language</param>
        public void Determine(string code)
        {
            var NewLanguage
                = this.List.Find
                    (
                    s => code.Equals(
                        s.Code, 
                        StringComparison
                        .CurrentCultureIgnoreCase)
                    );
            if (NewLanguage !=null)
            {
                this.CurrentLanguage = NewLanguage;
            }
            else
            {
                this.CurrentLanguage
                    =this.List.Find(
                        s=>s.Code.Equals(
                        "en",
                        StringComparison
                        .CurrentCultureIgnoreCase))!;      
            }

        }

        /// <summary>
        /// Internal field 
        /// </summary>
        public Data.Language _CurrentLanguage = null!;

        /// <summary>
        /// Calls the Current Language or sets it up
        /// </summary>
        public Data.Language CurrentLanguage
        {
            get
            {
                if( this._CurrentLanguage == null)
                {
                    var Iso2Code = System.Globalization
                        .CultureInfo.CurrentUICulture
                        .TwoLetterISOLanguageName;

                    this._CurrentLanguage
                        = this.List
                        .Find(s => string.Compare(
                            s.Code, Iso2Code,
                            ignoreCase: true
                            ) == 0)!;

                    //If the System Language is not found
                    //use English
                    if( this._CurrentLanguage == null )
                    {
                        this._CurrentLanguage
                            =this.List.Find(
                                s=>string.Compare(
                                    ignoreCase:true,
                                    strA:s.Code,
                                    strB:"En")==0)!;
                    }
                }
                return this._CurrentLanguage;
            }
            set => this._CurrentLanguage = value;
        }
        #endregion Current Language

    }
}
