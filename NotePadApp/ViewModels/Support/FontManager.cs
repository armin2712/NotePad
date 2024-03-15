using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing.Text;
using System.Windows.Controls;
using System.Windows.Media;
using WPF.Window.Support;
using System.Collections.ObjectModel;
using static System.Net.Mime.MediaTypeNames;

namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// Provides a service for managing the Tab Content font
    /// </summary>
    internal class FontManager : BaseViewModel
    {
        #region Window Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private WindowController _Controller = null!;

        /// <summary>
        /// Provides the Service for handling Window management
        /// </summary>
        private WindowController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller = new WindowController(WindowType.FontWindow);

                }
                return this._Controller;
            }
        }

        #endregion Window Controller

        #region Window Management

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ShowFontWindow = null!;

        /// <summary>
        /// Opens the Window for interaction with the font properties
        /// </summary>
        public BaseCommand ShowFontWindow
        {
            get
            {
                if (this._ShowFontWindow == null)
                {
                    this._ShowFontWindow = new BaseCommand(d => this.OpenWindow(d));
                }
                return this._ShowFontWindow;
            }
        }

        /// <summary>
        /// Opens a new FontView Window
        /// </summary>
        /// <param name="p">System.Windows.Window that will be the Owner of the FontView</param>
        public void OpenWindow(object p)
        {
            if (p is System.Windows.Window callingWindow)
            {
                this.Controller.Display<Views.Support.FontView>(callingWindow);
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Close = null!;

        /// <summary>
        /// Closes the FontView window
        /// </summary>
        public BaseCommand Close
        {
            get
            {
                if (this._Close == null)
                {
                    this._Close = new BaseCommand(d => this.Controller.CloseWindow());
                }
                return this._Close;
            }
        }
        #endregion Window Management

        #region Font Styles

        /// <summary>
        /// Gets or sets the Font style of the Tab Content
        /// </summary>
        public string Style
        {
            get => Properties.Settings.Default.FontStyle;
            set
            {
                Properties.Settings.Default.FontStyle = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Provides a full list of all font styles
        /// </summary>
        private void GetStyles()
        {

            // Specify the font family
            FontFamily fontFamily = new FontFamily(this.Family);

            // Get the typeface for the specified font family
            Typeface typeface = new Typeface(fontFamily, System.Windows.FontStyles.Normal,
                System.Windows.FontWeights.Normal, FontStretches.Normal);

            // Get the available font styles for the font family
            FontStyle[] styles = typeface.FontFamily.GetTypefaces().Select(tf => tf.Style).Distinct().ToArray();

            this.FontStyles.Clear();
            foreach (FontStyle style in styles)
            {
                this.FontStyles.Add(style.ToString());
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private ObservableCollection<string> _FontStyles= null!;

        /// <summary>
        /// Provides a list with all available font styles
        /// </summary>
        public ObservableCollection<string> FontStyles
        {
            get
            {
                if (this._FontStyles == null)
                {
                    this._FontStyles = new ObservableCollection<string>();

                    this.GetStyles();

                }
                return this._FontStyles;
            }
        }

        #endregion Font Styles

        #region Font Weights

        /// <summary>
        /// Gets or sets the Tab Content fonr weight
        /// </summary>
        public string Weight
        {
            get => Properties.Settings.Default.FontWeight;
            set
            {
                Properties.Settings.Default.FontWeight = value;
                this.OnPropertyChanged();
            }
        }
        /// <summary>
        /// Provides a full list of all font weights 
        /// for the current font family
        /// </summary>
        private void GetFontWeights()
        {
            // Specify the font family
            FontFamily fontFamily = new FontFamily(this.Family);

            // Get the typeface for the specified font family
            Typeface typeface = new Typeface(fontFamily, System.Windows.FontStyles.Normal,
                System.Windows.FontWeights.Normal, FontStretches.Normal);

            // Get the available font weights for the font family
            FontWeight[] weights = typeface.FontFamily.GetTypefaces().Select(tf => tf.Weight).Distinct().ToArray();

            this.FontWeights.Clear();
            foreach (FontWeight weight in weights)
            {
                this.FontWeights.Add(weight.ToString());
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private ObservableCollection<string> _FontWeights = null!;

        /// <summary>
        /// Provides a list with all available font weights
        /// </summary>
        public ObservableCollection<string> FontWeights
        {
            get
            {
                if (this._FontWeights == null)
                {
                    this._FontWeights = new ObservableCollection<string>();
                    this.GetFontWeights();
                }
                return this._FontWeights;
            }
        }

        #endregion Font Weights

        #region Font Sizes

        /// <summary>
        /// Gets or sets the Tab Content font size
        /// </summary>
        public int Size
        {
            get => Properties.Settings.Default.FontSize;
            set
            {
                Properties.Settings.Default.FontSize = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private ObservableCollection<int> _FontSizes = null!;

        /// <summary>
        /// Gets a list of all available font sizes
        /// </summary>
        public ObservableCollection<int> FontSizes
        {
            get
            {
                if (this._FontSizes == null)
                {
                    this._FontSizes = new ObservableCollection<int>
                    {
                        8, 9, 10, 11, 12, 14, 16, 18, 20, 24, 28, 32, 36, 40, 48, 72
                    };
                }
                return this._FontSizes;
            }
        }

        #endregion Font Sizes

        #region Font Families

        /// <summary>
        /// Gets or sets the Tab Content font family
        /// </summary>
        public string Family
        {
            get => Properties.Settings.Default.FontFamily;
            set
            {
                Properties.Settings.Default.FontFamily = value;
                this.GetStyles(); //set the styles for the family
                this.Style = this.FontStyles.First();
                this.GetFontWeights(); //set the weights for the family
                this.Weight = this.FontWeights.First();
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private ObservableCollection<string> _FontFamilies = null!;

        /// <summary>
        /// Provides a list of all font families
        /// </summary>
        public ObservableCollection<string> FontFamilies
        {
            get
            {
                if (this._FontFamilies == null)
                {
                    this._FontFamilies = new ObservableCollection<string>();
                    foreach (var font in Fonts.SystemFontFamilies)
                    {
                        this._FontFamilies.Add(font.ToString());
                    }
                }
                return this._FontFamilies;
            }
        }


        #endregion Font Families


    }
}
