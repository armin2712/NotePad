using Application.Tools;

namespace Application
{
    /// <summary>
    /// Supports Application objects with the basic
    /// infrastructure
    /// </summary>
    public abstract class AppObject:System.Object
    {
        /// <summary>
        /// Calls the Infrastructure of the Application
        /// or sets it up
        /// </summary>
        public Infrastructure Context { get; set; } = null!;

        #region ErrorOccured Event

        /// <summary>
        /// Triggers on Exception occurence
        /// </summary>
        public event ErrorOccurredEventHandler ErrorOccurred = null!;

        /// <summary>
        /// Triggers on Error
        /// </summary>
        protected virtual void OnErrorOccured(ErrorOccurredEventArgs e)
        {
            //It's there so the Garbage Collection
            //doesn't delete the Object with the Handler
            var HandlerCopy = this.ErrorOccurred;

            if(HandlerCopy != null)
            {
                HandlerCopy(this, e);
            }
        }

        #endregion ErrorOccured Event

        #region Data Path

        /// <summary>
        /// Internal field for the Property
        /// </summary>
        private static string _LocalPath = null!;

        /// <summary>
        /// Gets the Path for Saving in the local
        /// AppData Folder of the User
        /// </summary>
        public string LocalPath
        {
            get
            {
                if(AppObject._LocalPath == null)
                {
                    AppObject._LocalPath
                        = System.IO.Path.Combine(
                            System.Environment
                        .GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 
                        this.GetAppName(), 
                        this.GetVersion()
                        );
                }

                System.IO.Directory
                    .CreateDirectory( AppObject._LocalPath );

                return AppObject._LocalPath;
            }
        }

        /// <summary>
        /// Internal field for the Property
        /// </summary>
        private static string _RoamingPath=null!;

        /// <summary>
        /// Gets the Path for Saving in the roaming folder
        /// of the User
        /// </summary>
        public string RoamingPath
        {
            get
            {
                if(AppObject._RoamingPath == null)
                {
                    AppObject._RoamingPath
                        = System.IO.Path.Combine
                        (
                            System.Environment
                            .GetFolderPath(
                                Environment.SpecialFolder
                                .ApplicationData),

                            this.GetAppName(),
                            this.GetVersion()

                         );
                }

                System.IO.Directory
                    .CreateDirectory( AppObject._RoamingPath );

                return AppObject._RoamingPath;
            }
        }

        #endregion Data Path

        #region Application Path
        /// <summary>
        /// Internal field for the Property
        /// </summary>
        private static string _AppPath=null!;

        /// <summary>
        /// Gets the Application Folder
        /// </summary>
        public string AppPath
        {
            get
            {
                if(AppObject._AppPath == null)
                {
                    AppObject._AppPath
                        = System.IO.Path.GetDirectoryName(
                            System.Reflection.Assembly
                            .GetEntryAssembly()!.Location)!;
                }
                return AppObject._AppPath;
            }

        }

        #endregion Application Path

    }
}
