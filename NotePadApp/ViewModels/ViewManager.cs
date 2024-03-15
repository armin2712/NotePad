using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.Window.Support;

namespace NotePadApp.ViewModels
{
    /// <summary>
    /// Manages the view settings of the application.
    /// </summary>
    public class ViewManager : BaseViewModel
    {
        #region Zoom

        #region Data
        /// <summary>
        /// Internal field representing the zoom multiplicator.
        /// </summary>
        private double _Multiplicator = 1;

        /// <summary>
        /// Gets or sets the zoom multiplicator.
        /// </summary>
        public double Multiplicator
        {

            get => this._Multiplicator;
            set
            {
                if (this._Multiplicator != value)
                {
                    if (value >= 0.1 && value <= 50)
                    {
                        this._Multiplicator = value;
                        this.OnPropertyChanged(nameof(Zoom));
                        this.OnPropertyChanged(nameof(Multiplicator));
                    }
                }
            }
        }

        /// <summary>
        /// Gets the zoom multiplicator as a percentage (multiplicator * 100).
        /// </summary>
        public double Zoom => Math.Round(this._Multiplicator * 100);


        #endregion Data

        private BaseCommand _ZoomIn = null!;

        /// <summary>
        /// Gets the command to zoom in.
        /// </summary>
        public BaseCommand ZoomIn
        {
            get
            {
                if (this._ZoomIn == null)
                {
                    this._ZoomIn = new BaseCommand(d => this.Multiplicator += 0.1);
                }
                return this._ZoomIn;
            }
        }

        private BaseCommand _ZoomOut = null!;

        /// <summary>
        /// Gets the command to zoom out.
        /// </summary>
        public BaseCommand ZoomOut
        {
            get
            {
                if (this._ZoomOut == null)
                {
                    this._ZoomOut = new BaseCommand(d => this.Multiplicator -= 0.1);
                }
                return this._ZoomOut;
            }
        }

        private BaseCommand _RestoreView = null!;

        /// <summary>
        /// Gets the command to restore the view to default zoom.
        /// </summary>
        public BaseCommand RestoreView
        {
            get
            {
                if (this._RestoreView == null)
                {
                    this._RestoreView = new BaseCommand(d => this.Multiplicator = 1);
                }
                return this._RestoreView;
            }
        }


        #endregion Zoom

        #region Wrap and Footer

        /// <summary>
        /// Gets or sets whether the text can wrap.
        /// </summary>
        public bool IsWrapping
        {
            get => Properties.Settings.Default.IsWrapping;
            set
            {
                Properties.Settings.Default.IsWrapping = value;
                OnPropertyChanged();

            }
        }

        /// <summary>
        /// Gets or sets the visibility of the footer.
        /// </summary>
        public bool IsFooterVisible
        {
            get => Properties.Settings.Default.IsFooterVisible;
            set
            {
                Properties.Settings.Default.IsFooterVisible = value;
                OnPropertyChanged();

            }
        }
        #endregion Wrap and Footer

    }
}
