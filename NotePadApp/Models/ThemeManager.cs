
using System.Windows.Media.TextFormatting;
using WPF.Window.Support;

namespace NotePadApp.Models
{
    /// <summary>
    /// Provides an service for handling the Application Theme
    /// </summary>
    public class ThemeManager : Application.AppObject
    {
        /// <summary>
        /// Get the Current Theme uri, or null if not present
        /// </summary>
        public static Uri GetCurrentTheme()
        {
            // Get the most recently added theme dictionary
            var currentThemeDictionary = System.Windows.Application.Current.Resources.MergedDictionaries.LastOrDefault();

            // Check if a theme dictionary was found
            if (currentThemeDictionary != null)
            {
                // Return the URI of the theme dictionary's source
                return currentThemeDictionary.Source;
            }
            else
            {
                // If no theme dictionary is found, return null or throw an exception, depending on your requirements
                return null!;
            }
        }

        /// <summary>
        /// Applies the specified theme dictionary to other resource dictionaries.
        /// </summary>
        /// <param name="themeDictionary">The theme dictionary to apply.</param>
        private void ApplyThemeToOther(System.Windows.ResourceDictionary themeDictionary)
        {
            // Merge the theme dictionary into each additional resource dictionary
            foreach (var resourceDictionary in System.Windows.Application.Current.Resources.MergedDictionaries)
            {
                if (resourceDictionary != themeDictionary)
                {
                    // Merge the theme dictionary
                    resourceDictionary.MergedDictionaries.Add(themeDictionary);
                }
            }
        }

        /// <summary>
        /// Changes the color template of the App
        /// </summary>
        /// <param name="theme">Uri of the theme</param>
        public void ChangeTheme(Uri theme)
        {
            //Creates a new Theme with the Theme from provided Uri
            System.Windows.ResourceDictionary Theme
               = new System.Windows.ResourceDictionary()
               {
                   Source = theme
               };

            //Sets the new Theme
            System.Windows.Application.Current.Resources.MergedDictionaries.Add(Theme);

            // Apply the theme to other resource dictionaries

            ApplyThemeToOther(Theme);
        }


        /// <summary>
        /// Sets the Application theme to Light
        /// </summary>
        public void SetLightTheme()
        {
            ChangeTheme(new Uri(Properties.Settings.Default.LightTheme, UriKind.Relative));
        }

        /// <summary>
        /// Sets the Application theme to Dark
        /// </summary>
        public void SetDarkTheme()
        {
            ChangeTheme(new Uri(Properties.Settings.Default.DarkTheme, UriKind.Relative));
        }


    }
}
