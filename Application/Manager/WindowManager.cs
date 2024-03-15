using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    /// <summary>
    /// Service for Window Management
    /// </summary>
    public class WindowManager:AppObject
    {
        #region Win32 API Wrapper

        private enum SystemMetricsInfo : int
        {
            /// <summary>
            /// SM_CMONITORS
            /// </summary>
            MonitorCount = 80,
            /// <summary>
            /// SM_CXSCREEN
            /// </summary>
            XScreen = 0,
            /// <summary>
            /// SM_CYSCREEN
            /// </summary>
            YScreen = 1
        }

        /// <summary>
        /// Gets the Information about the window
        /// </summary>
        /// <param name="info">Integer type,what kind of info about the Window
        /// is wanted </param>
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int GetSystemMetrics(SystemMetricsInfo info);

        /// <summary>
        /// Gets a Code, with which the current Monitor configuration
        /// can be distinguished
        /// </summary>
        protected string MonitorKey
            => $"M{WindowManager.GetSystemMetrics(SystemMetricsInfo.MonitorCount)}" +
            $"_{WindowManager.GetSystemMetrics(SystemMetricsInfo.XScreen)}" +
            $"x{WindowManager.GetSystemMetrics(SystemMetricsInfo.YScreen)}_";

        #endregion Win32 API Wrapper

        #region Window List

        /// <summary>
        /// Internal field
        /// </summary>
        private Data.WindowInformations _List = null!;

        /// <summary>
        /// Calls the listing of the Window data
        /// </summary>
        protected Data.WindowInformations List
        {
            get
            {
                if(this._List == null)
                {
                    this._List = this.Read();
                }
                return this._List;
            }
        }

        #endregion Window List

        #region Add and Get

        /// <summary>
        /// Adds or updates the Window data in the Manager
        /// </summary>
        /// <param name="window">WindowInformation
        /// Object</param>
        public void Deposit(Data.WindowInformation window)
        {
            var PresentInfo = this.Fetch(window.Name);

            //Add the Window
            if(PresentInfo == null) 
            {
                window.Name = this.MonitorKey + window.Name;
                this.List.Add(window);      
            }
            else
            {
                //else update

                //in any case the condition
                PresentInfo.Condition = window.Condition;

                //all other propertys, if some are provided
                //so the last ones are not lost

                if(window.Left != null)
                {
                    PresentInfo.Left = window.Left;
                }

                PresentInfo.Top
                    = window.Top.HasValue?
                    window.Top:PresentInfo.Top;

                PresentInfo.Width
                    =window.Width.HasValue?
                    window.Width:PresentInfo.Width;

                PresentInfo.Height
                    =window.Height.HasValue?
                    window.Height:PresentInfo.Height;
            }
        }

        /// <summary>
        /// Return WindowInformation Object for the whished Window
        /// </summary>
        /// <param name="windowName">Internal Window name
        /// as key</param>
        /// <returns>WindowInformation object with a name
        /// or null, if the Window is not yet registred</returns>
        public Data.WindowInformation? Fetch(string windowName)
        {
            return this.List
                .Find(f=>f.Name==this.MonitorKey+ windowName);
        }


        #endregion Add and Get

        #region Save and Read

        /// <summary>
        /// Internal Field
        /// </summary>
        private static string _StandardPath = null!;

        /// <summary>
        /// Calls the Save place path of the File
        /// with the managed Window
        /// </summary>
        public string StandardPath
        {
            get
            {
                if(WindowManager._StandardPath == null)
                {
                    const string File = "Window.xml";
                    WindowManager._StandardPath
                        =System.IO.Path.Combine
                        (this.LocalPath, File);
                }
                return WindowManager._StandardPath;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private Controller.WindowXmlController _Controller=null!;

        /// <summary>
        /// Calls the Service for serialization
        /// and deserialization of the managed Window
        /// </summary>
        private Controller.WindowXmlController Controller
        {
            get
            {
                if(this._Controller == null)
                {
                    this._Controller
                        = this.Context
                        .Produce<Controller.WindowXmlController>();
                }
                return this._Controller;
            }
        }

        /// <summary>
        /// Writes the List with the managed Window
        /// in the File of the Standard path
        /// </summary>
        public void Save()
        {
            try
            {
                this.Controller.Save(
                    this.StandardPath,
                    this.List);
            }
            catch (Exception ex)
            {
                this.OnErrorOccured(
                    new ErrorOccurredEventArgs(ex));
            }

        }

        /// <summary>
        /// Returns a List with saved WindowInformations
        /// Objects from the File in the StandardPath
        /// </summary>
        protected Data.WindowInformations Read()
        {
            try
            {
                return this.Controller.Read(this.StandardPath);
            }
            catch (System.Exception ex) 
            {
                this.OnErrorOccured(
                    new ErrorOccurredEventArgs(ex));
                //In case there's an error,
                //it won't try to load it again
                return new Data.WindowInformations();
            }
        }

        #endregion Save and Read

        #region New Window

        /// <summary>
        /// Creates a new window of the app
        /// </summary>
        public static void CreateNewWindow()
        {
            System.Diagnostics.Process.Start
                (System.Diagnostics.Process.GetCurrentProcess()!.MainModule!.FileName);
        }
        #endregion New Window

    }
}
