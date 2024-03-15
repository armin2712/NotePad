using Microsoft.Win32;
using System.IO;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Markup;
using System.Windows;

namespace NotePadApp.ViewModels
{
    /// <summary>
    /// Provides functionalities for managing tabs in the application,
    /// such as opening files, saving files, exporting tab contents,
    /// printing tab contents, and managing print settings.
    /// </summary>
    public class TabController:WPF.Window.Support.BaseViewModel
    {
        /// <summary>
        /// Opens a file dialog so the User can chose which
        /// file to open in a new tab
        /// </summary>
        public Tab OpenFile()
        {
            OpenFileDialog openFileDialog = new();

            var tab = new Tab();

            openFileDialog.ShowDialog();

            if (!String.IsNullOrEmpty(openFileDialog.FileName))
            {
                tab.Path = openFileDialog.FileName;
                tab.Name = System.IO.Path.GetFileNameWithoutExtension(openFileDialog.SafeFileName);
                // Read the contents of the selected file
                using (StreamReader streamReader = new StreamReader(tab.Path))
                {
                    tab.Content = streamReader.ReadToEnd();
                }
                tab.IsSaved = true;
                return tab;
            }
            else
            {
                return null!;
            }

        }

        /// <summary>
        /// Provides an StreamWriter for saving 
        /// a Tab
        /// </summary>
        public void SaveFile(Tab tab, string filename = null!)
        {
            if (!string.IsNullOrEmpty(tab.Path))
            {

                using (StreamWriter streamWriter = new StreamWriter(tab.Path))
                {
                    streamWriter.Write(tab.Content);
                }
                tab.IsSaved = true;
            }
            else if (string.IsNullOrEmpty(tab.Path))
            {
                Export(tab,filename);
            }

            

        }

        /// <summary>
        /// Provides an SaveFileDialog for saving the given Tab Content
        /// </summary>
        public void Export(Tab tab,string filename=null!)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter
                = $"{Assets.Info.TextFile} (*.txt)|*.txt|{Assets.Info.AllFiles} (*.*)|*.*";
            if (filename != null)
            {
                saveFileDialog.FileName = filename;
            }

            // Show the SaveFileDialog and check if the user saves the file
            bool? result = saveFileDialog.ShowDialog();

            if (result == true) // User clicked the Save button
            {
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName))
                {
                    streamWriter.Write(tab.Content);
                }
                // Update file
                tab.Path = saveFileDialog.FileName;
                tab.Name = System.IO.Path.GetFileNameWithoutExtension(saveFileDialog.SafeFileName);
                tab.IsSaved = true;
            }
        }

        /// <summary>
        /// Saves all tabs from a tab item list
        /// </summary>
        /// <param name="tabs">An Tabs list of tab items</param>
        public void SaveAll(Tabs tabs)
        {
            foreach (Tab tab in tabs)
            {
                this.SaveFile(tab);
            }
        }

        /// <summary>
        /// Opens a Print Dialog and stores the user setting
        /// </summary>
        public void OpenPageSetup(string content)
        {
            #region Helper
            void PrintDocument(PrintDialog printDialog, string s)
            {
                // Create a new FixedDocument
                FixedDocument document = new FixedDocument();
                PageContent pageContent = new PageContent();
                FixedPage fixedPage = new FixedPage();

                // Create a text block to hold the string
                TextBlock textBlock = new TextBlock();
                textBlock.Text = s;
                textBlock.Margin = new Thickness(50); // Add some margin

                // Add the text block to the fixed page
                fixedPage.Children.Add(textBlock);

                // Add the fixed page to the page content
                ((IAddChild)pageContent).AddChild(fixedPage);
                document.Pages.Add(pageContent);

                // Print the document
                printDialog.PrintDocument(document.DocumentPaginator, "Print Document");
            }
            #endregion Helper

            // Create a PrintDialog instance
            PrintDialog printDialog = new PrintDialog();

            // Show the Page Setup dialog
            if (printDialog.ShowDialog() == true)
            {
                // Optionally, you can access page setup settings from the printDialog object
                // PageSettings pageSettings = printDialog.PrintQueue.GetPrintCapabilities().PageImageableArea;
                // Use page setup settings as needed

                // Print the string
                PrintDocument(printDialog, content);
            }
        }
    }
}
