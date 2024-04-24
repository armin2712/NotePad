
using System.Windows;

namespace NotePadApp.ViewModels.FindService
{
    /// <summary>
    /// Controller class for finding text within a tab.
    /// </summary>
    internal class FindController : WPF.Window.Support.BaseViewModel
    {
        /// <summary>
        /// Determines the starting index for the search based on search settings and caret position.
        /// </summary>
        /// <param name="data">The search data containing search settings.</param>
        /// <param name="tab">The tab containing the text to search.</param>
        private void GetStartIndex(SearchData data, Tab tab)
        {
            var index = tab.Caret.Index + tab.SelectedText.Length;
            if (data.IsNext)
            {
                if (data.IsWrapAround)
                {
                    if (index >= tab.Content.Length)
                    {
                        data.SearchStartIndex = 0;
                    }
                    else
                    {
                        data.SearchStartIndex = index;
                    }
                }
                else
                {
                    data.SearchStartIndex = index;
                }
            }
            else
            {
                if (data.IsWrapAround)
                {
                    if (tab.Caret.Index == 0)
                    {
                        data.SearchStartIndex = tab.Content.Length;
                    }
                    else
                    {
                        data.SearchStartIndex = tab.Caret.Index;
                    }
                }
                else
                {
                    data.SearchStartIndex = tab.Caret.Index;
                }
            }
        }

        /// <summary>
        /// Finds the index of the nth occurrence of a string within the given text.
        /// </summary>
        /// <remarks>The IndexOfSearchText divides the content into two strings and then provides
        /// one part to IndexOfNthString for quicker search</remarks>
        /// <param name="text">The text to search within.</param>
        /// <param name="data">The search data containing search settings.</param>
        /// <param name="tab">The tab containing the text to search.</param>
        /// <returns>The index of the nth occurrence of the search string within the text.</returns>
        private int IndexOfNthString(string text, SearchData data, Tab tab)
        {
            int index = -1;
            int count = 0;
            int lastIndex = 0; // Adjust start index

            if (lastIndex > text.Length)
            {
                return -1;
            }

            if (data.IsNext)
            {
                while ((index = text.IndexOf(data.SearchQuery, lastIndex, data.Comparison)) != -1)
                {
                    if (count == data.SearchIndex)
                    {
                        return index;
                    }
                    count++;
                    lastIndex = index + 1;
                }
            }
            else if (!data.IsNext)
            {
                while ((index = text.LastIndexOf(data.SearchQuery, data.Comparison)) != -1)
                {
                    if (count == data.SearchIndex)
                    {
                        return index;
                    }
                    count++;
                    lastIndex = index - 1;
                }
            }

            data.SearchStartIndex = tab.Caret.Index;
            return -1; // searchString not found or searchIndex out of range
        }

        /// <summary>
        /// Finds the index of the search text within the tab's content.
        /// </summary>
        /// <param name="data">The search data containing search settings.</param>
        /// <param name="tab">The tab containing the text to search.</param>
        /// <returns>The index of the search text within the tab's content.</returns>
        private int IndexOfSearchText(SearchData data, Tab tab)
        {
            GetStartIndex(data, tab);
            //split the content into two strings, the left side is used for previous search
            //and the right for the next
            var firstPart = tab.Content.Substring(0, data.SearchStartIndex);
            var secondPart = tab.Content.Substring(data.SearchStartIndex);

            var indexOfSubstring = 0;

            if (data.IsNext)
            {
                indexOfSubstring = IndexOfNthString(secondPart, data, tab);

                if (indexOfSubstring == -1)
                {
                    return indexOfSubstring;
                }
                else
                {
                    return (firstPart.Length + indexOfSubstring);
                }
            }
            else
            {
                indexOfSubstring = IndexOfNthString(firstPart, data, tab);
                return indexOfSubstring;
            }
        }

        /// <summary>
        /// Finds the first occurrence of a string in the text and selects it.
        /// </summary>
        /// <param name="tab">The tab containing the text to search.</param>
        /// <param name="data">Search data containing search parameters.</param>
        /// <param name="p">The caller of the method.</param>
        public void FindInText(Tab tab, SearchData data, object p, string replace = null!)
        {
            if (tab.Content.Contains(data.SearchQuery, data.Comparison) && 
                !string.IsNullOrEmpty(data.SearchQuery))
            {
                // Find the occurrence of the string in the text.
                var index = IndexOfSearchText(data, tab);

                if (index < 0)
                {
                    if (p is System.Windows.Window w)
                    {

                        NotePadApp.ViewModels.Support.CustomMessageBox.Show(
                        $"\"" + $"{data.SearchQuery}" + "\" " + $"{NotePadApp.Assets.Info.FindMessage}",
                        Support.MessageType.Ok, w);
                    }
                }
                else
                {
                    // Store the text before removing.
                    var textToAdd = tab.Content.Substring(index, data.SearchQuery.Length);

                    // Remove string from the text. This is inevitable without code behind because
                    // the selected text is part of the text, and simply setting the selected
                    // text will result in adding to the text, thus duplicating the string we wanted to mark.
                    tab.Content = tab.Content.Remove(index, data.SearchQuery.Length);

                    // Set the caret position so the selection text knows where to put the selected text.
                    tab.Caret.Index = index;

                    // To display the found text.
                    tab.SelectedText = textToAdd;
                    if (replace != null)
                    {
                        tab.SelectedText = replace;
                    }

                    // Set focus to ensure selected text is visible.
                    GetFocus(p);
                }
            }
            else if (!tab.Content.Contains(data.SearchQuery, data.Comparison))
            {
                if (p is System.Windows.Window w)
                {
                    NotePadApp.ViewModels.Support.CustomMessageBox.Show(
                    $"\"" + $"{data.SearchQuery}" + "\" " + $"{NotePadApp.Assets.Info.FindMessage}", Support.MessageType.Ok,w);
                }
            }
        }

        public void Replace(Tab tab, SearchData data, object p)
        {
            tab.Content = tab.Content.Replace(data.SearchQuery, data.ReplaceText);
            GetFocus(p);
        }

        #region Focus Handler
        /// <summary>
        /// Sets focus on the FindService window to ensure the selected text is visible.
        /// </summary>
        /// <param name="p">The caller of the method.</param>
        private void GetFocus(object p)
        {
            // The find service's window steals focus from MainWindow,
            // making selected text invisible if MainWindow isn't focused.
            // Our View includes IsInactiveSelectionHighlightEnabled="True" to solve this,
            // but it requires the TextBox's Window to have been focused at least once to work.
            if (p is System.Windows.Window mainWindow)
            {
                //Find the FindWindow
                var FindWindow=
                    System.Windows.Application.
                    Current.Windows.OfType<Window>().FirstOrDefault(w=>w.Name.Contains("Support"));
                // Give focus to the MainWindow so we get the selected text.
                mainWindow.Focus();
                // Get the focus back on the FindService window.
                if (FindWindow != null)
                {
                    System.Windows.Application.Current.Windows
                        .OfType<Window>().FirstOrDefault(w => w.Name == FindWindow!.Name)!.Focus();
                }
            }
        }
        #endregion Focus Handler

    }
}
