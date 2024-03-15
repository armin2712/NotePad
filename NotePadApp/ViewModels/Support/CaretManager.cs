namespace NotePadApp.ViewModels.Support
{
    /// <summary>
    /// Manages the caret position in a string,
    /// including index, line and column
    /// </summary>
    public class CaretManager : WPF.Window.Support.BaseViewModel
    {
        /// <summary>
        /// Gets or sets the text to monitor caret position
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Internal field
        /// </summary>
        private int _Index = 0;

        /// <summary>
        /// Gets or sets the curent position of the caret
        /// </summary>
        public int Index
        {
            get => _Index;

            set
            {
                _Index = value;
                UpdateCaretLineAndColumn(Text);
                OnPropertyChanged();

            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private int _Line = 1;

        /// <summary>
        /// Gets or sets the caret line
        /// </summary>
        public int Line
        {
            get => _Line;
            set
            {
                _Line = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private int _Column = 1;

        /// <summary>
        /// Gets or sets the caret column
        /// </summary>
        public int Column
        {
            get => _Column;
            set
            {
                _Column = value;
                OnPropertyChanged();
            }
        }


        /// <summary>
        /// Updates the caret position based on the current caret index,
        /// setting the caret line and column accordingly.
        /// </summary>
        private void UpdateCaretLineAndColumn(string text)
        {
            //TODO Change to Task
            var Thread
                   = new Thread(() =>
                   {
                       //check the text to the caret position
                       string textToCheck = text.Substring(0, Index);
                       //Split the text into a list of strings with ending '\n'
                       //easy way to count new lines
                       var lines = textToCheck.Split('\n');
                       //Line is number of new lines
                       Line = lines.Length;
                       //Column starts from 1 in new line
                       if (string.IsNullOrEmpty(text))
                       {
                           Column = lines[lines.Length - 1].Length + 1;
                       }
                       else
                       {
                           Column = lines[lines.Length - 1].Length + 1;
                       }
                   });
            //To end the thread on exit
            Thread.IsBackground = true;

            Thread.Start();
        }
    }
}
