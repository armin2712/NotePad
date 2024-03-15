namespace NotePadApp.ViewModels.FindService
{
    /// <summary>
    /// Represents data used for searching
    /// within text content in the NotePad application.
    /// </summary>
    public class SearchData : WPF.Window.Support.BaseViewModel
    {
        /// <summary>
        /// True if the Next command is executed, 
        /// false if the Previous command is executed.
        /// </summary>
        public bool IsNext { get; set; } = false;

        /// <summary>
        /// Gets or sets a value indicating whether the search is case-sensitive.
        /// </summary>
        public bool IsMatchCase
        {
            get => Properties.Settings.Default.IsMatchCase; 
            set
            {
                Properties.Settings.Default.IsMatchCase = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating 
        /// whether the search should wrap around the text.
        /// </summary>
        public bool IsWrapAround
        {
            get => Properties.Settings.Default.IsWrapping;
            set
            {
                Properties.Settings.Default.IsWrapping = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the search index.
        /// </summary>
        public int SearchIndex { get; set; } = 0;

        /// <summary>
        /// Gets or sets the index from where to start the search.
        /// </summary>
        public int SearchStartIndex { get; set; } = 0;

        /// <summary>
        /// Internal Field
        /// </summary>
        private StringComparison _Comparison;

        /// <summary>
        /// Gets the StringComparison value 
        /// based on the IsMatchCase property.
        /// </summary>
        public StringComparison Comparison
        {
            get
            {
                if (IsMatchCase)
                {
                    _Comparison = StringComparison.Ordinal;
                }
                else
                {
                    _Comparison = StringComparison.OrdinalIgnoreCase;
                }
                return _Comparison;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private string _SearchQuery = string.Empty;

        /// <summary>
        /// Gets or sets the text being searched.
        /// </summary>
        public string SearchQuery
        {
            get => this._SearchQuery;

            set
            {
                this._SearchQuery = value;
                if(!string.IsNullOrEmpty(this._SearchQuery))
                {
                    this.HasTextToSearch = true;
                }
                else
                {
                    this.HasTextToSearch = false;
                }
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private bool _HasTextToSearch = false;

        /// <summary>
        /// True if there is text to search for
        /// </summary>
        public bool HasTextToSearch
        {
            get=>this._HasTextToSearch;
            set{
                this._HasTextToSearch= value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private string _ReplaceText = string.Empty;

        /// <summary>
        /// Gets or sets the text that will replace the searched text
        /// </summary>
        public string ReplaceText
        {
            get => this._ReplaceText;

            set
            {
                this._ReplaceText = value;
                this.OnPropertyChanged();
            }
        }


    }
}
