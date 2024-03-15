using Application.Tools;
using NotePadApp.Models;
using NotePadApp.Views;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace NotePadApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        
  
        /// <summary>
        /// Triggers the Startup Event
        /// </summary>
        /// <param name="e">Additional data</param>
        /// <remarks>Replaces Main()</remarks>
        protected override void OnStartup(StartupEventArgs e)
        {
            //First: what always happens..
            base.OnStartup(e);

            this.Context = new Application.Infrastructure();

            //Set the App Language to the System Language
            this.Context.Languages.Determine(System.Globalization
                .CultureInfo.CurrentUICulture
                .TwoLetterISOLanguageName);


            var ViewModel = this.Context.Produce<ViewModels.MainViewModel>();

            ViewModel.DisplayWindow<Views.MainWindow>();

            
            //Get last used Theme 
            if (!string.IsNullOrEmpty(NotePadApp.Properties.Settings.Default.CurrentTheme))
            {
                //Apply the Theme to the ViewModel
                ViewModel.Theme.ChangeTheme
             (new Uri(NotePadApp.Properties.Settings.Default.CurrentTheme, UriKind.Relative));
            }
         
      
        }

        /// <summary>
        /// Triggers Exit event
        /// </summary>
        /// <param name="e">Additional data</param>
        protected override void OnExit(ExitEventArgs e)
        {
            NotePadApp.Properties.Settings.Default
                .CurrentLanguageCode=this.Context
                .Languages.CurrentLanguage.Code;

            //Store the Current Theme path in the Settings
            NotePadApp.Properties.Settings.Default.CurrentTheme = ThemeManager.GetCurrentTheme().ToString();


            NotePadApp.Properties.Settings.Default.Save();
            this.Context.Window.Save();


            base.OnExit(e);    
        }


        /// <summary>
        /// Calls the Infrastructure Object of the Application
        /// or sets it up
        /// </summary>
        protected Application.Infrastructure Context { get; set; }
        = null!;
    }

}
