

namespace Application
{
    /// <summary>
    /// Provides an Application context
    /// </summary>
    public class Infrastructure:System.Object
    {
        #region Object factory

        /// <summary>
        /// Returns an initialized application object with the context set
        /// </summary>
        /// <typeparam name="T">A class that extends the AppObject and owns a public parameterless constructor</typeparam>
        /// <returns>An AppObject with set context</returns>
        public T Produce<T>() where T : AppObject, new()
        {
            var NewObject=new T();

            //Give the actual Infrastructure to
            //the new Object
            NewObject.Context = this;

            //In case an Error occurres 
            NewObject.ErrorOccurred+= this.ReportException;

            System.Diagnostics.Debug.WriteLine(
                $"{NewObject} initialized...");

            return NewObject;

        }

        /// <summary>
        /// Sets in the Console of the Studio
        /// a Message that an Exception has been triggerd
        /// </summary>
        private void ReportException(object s, ErrorOccurredEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(
                $"Error! {s} triggers an Exception {e.Exception.Message}.");
        }


        #endregion Object factory

        #region Language Service

        /// <summary>
        /// Internal field
        /// </summary>
        private Manager.LanguageManager _Languages = null!;

        /// <summary>
        /// Calls the Service for managing the Application
        /// Language
        /// </summary>
        public Manager.LanguageManager Languages
        {
            get
            {
                if (this._Languages == null)
                {
                    this._Languages
                        =this.Produce<Manager.LanguageManager>();
                }
                return this._Languages;
            }
        }
        #endregion Language Service

        #region Window Service

        /// <summary>
        /// Internal field
        /// </summary>
        private Manager.WindowManager _Window=null!;

        /// <summary>
        /// Calls the Service for managing the Application
        /// Window
        /// </summary>
        public Manager.WindowManager Window
        {
            get
            {
                if (this._Window == null)
                {
                    this._Window 
                        = this.Produce<Manager.WindowManager>();
                }
                return this._Window;
            }

        }
        #endregion Window Service
    }
}
