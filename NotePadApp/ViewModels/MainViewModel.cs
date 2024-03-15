using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.TextFormatting;
using NotePadApp.Models;
using NotePadApp.ViewModels.Support;
using WPF.Window.Support;

namespace NotePadApp.ViewModels
{
    /// <summary>
    /// Controlls the NotePaddApp
    /// </summary>
    internal class MainViewModel : BaseViewModel
    {
        #region MainView

        /// <summary>
        /// Gets or sets the restore button symbol
        /// </summary>
        public string RestoreButton
        {
            get => Properties.Settings.Default.RestorePath;
            set
            {
                Properties.Settings.Default.RestorePath=value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Restores the Restore symbol of the MainWindow
        /// </summary>
        protected void GetRestoreSymbol(
            System.Windows.Window window)
        {
            var OldState = this.Context.Window.Fetch(window.Name);

            if (OldState != null)
            {
                if (OldState.Condition
                    == (int)System.Windows.WindowState.Maximized)
                {
                    //Set the Restore Button path to max
                    this.RestoreButton = "\u2750";

                }
                else
                {

                    //Set the Restore Button path to normal
                    this.RestoreButton = "\u2b1c";
                }

            }

        }

        /// <summary>
        /// Prepares the Window for the App
        /// </summary>
        /// <param name="window">Window object</param>
        protected virtual void Initialize(
            System.Windows.Window window)
        {
            //Set the name as key
            window.Name = window.GetType().Name;
            window.Name += this.GetWindowNumber(window);


            this.RestoreState(window);
            this.GetRestoreSymbol(window);

            //save state on exit
            window.Closing += (s, e) =>
            {
                if (this.Tabs.List.Any(tab => tab.IsSaved == false))
                {
                    var result = CustomMessageBox.Show(Assets.Info.ExitQuestion, MessageType.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        Tabs.SaveAll.Execute(this);
                    }
                    if (result == MessageBoxResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
                this.StoreState(window);
            };
        }


        /// <summary>
        /// Opens the given Window as MainWindow
        /// </summary>
        /// <typeparam name="T">System.Windows.Window</typeparam>
        public void DisplayWindow<T>() where T :
            System.Windows.Window, new()
        {
            var Window = new T();
            this.MainWindowTyp = typeof(T);

            //Data binding, bind this ViewModel and the new View
            Window.DataContext = this;

            //Prepare the Window
            this.Initialize(Window);

            //and display it
            Window.Show();


        }


        /// <summary>
        /// Initialize with the MainWindowType a new Window
        /// and show it
        /// </summary>
        protected virtual void OpenNewWindow()
        {

            var NewWindow = (System.Activator
                .CreateInstance(this.MainWindowTyp)
                as System.Windows.Window)!;


            //The Window should be independent, and for that
            // it needs an ViewModel
            var NewViewModel = this.Context
                .Produce<ViewModels.MainViewModel>();

            //Give the ViewModel the Window type for
            //Display Window
            NewViewModel.MainWindowTyp
                = this.MainWindowTyp;

            // Connect the new window with the new ViewModel
            NewWindow.DataContext = NewViewModel;

            // Initialize the new window
            NewViewModel.Initialize(NewWindow);

            // Show the new window
            NewWindow.Show();

        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private BaseCommand _NewWindow = null!;

        /// <summary>
        /// Gets the Command for a new window
        /// </summary>
        public BaseCommand NewWindow
        {
            get
            {
                if (this._NewWindow == null)
                {
                    this._NewWindow = new BaseCommand(d => this.OpenNewWindow());
                }
                return this._NewWindow;
            }
        }

        /// <summary>
        /// Internal Field
        /// </summary>
        private BaseCommand _CloseAll = null!;

        /// <summary>
        /// Closes all open Windows if there is no command parameter set
        /// if the parameter is set close only the Window of the command caller
        /// </summary>
        public BaseCommand CloseAll
        {
            get
            {
                if (this._CloseAll == null)
                {
                    this._CloseAll = new BaseCommand(
                        p =>
                        {
                            foreach (System.Windows.Window w in App.Current.Windows)
                            {
                                //If no parameter close all
                                if (p == null)
                                {
                                    w.Close();
                                }
                                //else if there is an parameter close
                                //the window with that parameter
                                else if (w.DataContext == p)
                                {
                                    w.Close();
                                }
                            }
                        });
                }
                return this._CloseAll;
            }
        }

        /// <summary>
        /// Gets the Window type that's used
        /// on Window Show or sets it up
        /// </summary>
        private System.Type MainWindowTyp { get; set; } = null!;


        /// <summary>
        /// Gives the first free Number for the window key
        /// </summary>
        /// <param name="window">An WPF Window</param>
        protected virtual int GetWindowNumber(
                    System.Windows.Window window)
        {
            int Number = 1;

            //Checks, if in the open windows there's already the same
            //number, if so add one to the number
            var OpenWindowNames
                = new System.Collections.ArrayList(
                    App.Current.Windows.Count);
            foreach (System.Windows.Window w in App.Current.Windows)
            {
                OpenWindowNames.Add(w.Name);
            }

            while (OpenWindowNames.Contains(window.Name + Number))
            {
                Number++;
            }


            return Number;
        }

        #endregion MainView

        #region Tabs
        /// <summary>
        /// Internal field
        /// </summary>
        private TabsManager _Tabs = null!;

        /// <summary>
        /// Provides the Service for managing Tabs
        /// </summary>
        public TabsManager Tabs
        {
            get
            {
                if (this._Tabs == null)
                {
                    this._Tabs = this.Context.Produce<TabsManager>();
                    this._Tabs.List.CollectionChanged += Tabs_CollectionChanged;
                    this._Tabs.NewTab.Execute(this);
                    this._Tabs.SelectedTabItem = this._Tabs.List[0];
                }
                return this._Tabs;
            }
        }


        #region Collection Changed

        /// <summary>
        /// Handles the collection changed event for the tabs manager.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Tabs_CollectionChanged(object? sender, 
            System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Tab tab;
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    tab = (Tab)e.NewItems![0]!;
                    if (tab != null)
                    {
                        tab.CloseRequested += OnTabCloseRequested;

                    }

                    break;

                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    tab = (Tab)e.OldItems![0]!;
                    tab.CloseRequested -= OnTabCloseRequested;
                    break;

            }
        }

        /// <summary>
        /// Handles the close requested event for a tab.
        /// </summary>
        /// <param name="sender">The sender of the event.</param>
        /// <param name="e">The event arguments.</param>
        private void OnTabCloseRequested(object? sender, EventArgs e)
        {
            Tab tabItem = (Tab)sender!;

            #region Helper
            //Removes the SelectedTab from the Tabs list
            //and selects the next tab
            void RemoveTab(int index)
            {
                this.Tabs.List.Remove(Tabs.SelectedTabItem);
                if (index > 0)
                {
                    this.Tabs.SelectedTabItem = this.Tabs.List[index - 1];
                }
            }
            #endregion Helper

            //index of the removed tab
            int currentIndex = this.Tabs.List.IndexOf(tabItem);

            if (tabItem.IsSaved != true)
            {
                this.Tabs.SelectedTabItem = tabItem;
                MessageBoxResult result;
                if (string.IsNullOrEmpty(tabItem.Path))
                {
                    result = CustomMessageBox.Show($"{Assets.Info.YesNoPartOne} " +
                         $"{tabItem.Name} {Assets.Info.YesNoPartTwo}", MessageType.YesNo);
                }
                else
                {
                    result = CustomMessageBox.Show($"{Assets.Info.YesNoPartOne} " +
                         $"{tabItem.Path} {Assets.Info.YesNoPartTwo}", MessageType.YesNo);
                }
                if (result == MessageBoxResult.Yes)
                {

                    this.Tabs.SaveWithSuggestion();
                    RemoveTab(currentIndex);
                
                }
                else if (result == MessageBoxResult.No)
                {
                    RemoveTab(currentIndex);
                }
            }
            else
            {
                RemoveTab(currentIndex);
            }

            if (this.Tabs.List.Count == 0)
            {
                System.Windows.Application.Current.Shutdown();
            }

        }

        #endregion Collection Changed

        #endregion Tabs

        #region ThemaManager

        /// <summary>
        /// Internal Field 
        /// </summary>
        private Models.ThemeManager _Theme = null!;

        /// <summary>
        /// Provides the functionalty to changes between Themes
        /// </summary>
        public Models.ThemeManager Theme
        {
            get
            {
                if (this._Theme == null)
                {
                    this._Theme = this.Context.Produce<Models.ThemeManager>();
                }
                return this._Theme;
            }
        }


        private BaseCommand _DarkTheme = null!;

        public BaseCommand DarkTheme
        {
            get
            {
                if (this._DarkTheme == null)
                {
                    this._DarkTheme = new BaseCommand(d => this.Theme.SetDarkTheme());
                }
                return this._DarkTheme;
            }
        }

        private BaseCommand _LightTheme = null!;

        public BaseCommand LightTheme
        {
            get
            {
                if (this._LightTheme == null)
                {
                    this._LightTheme = new BaseCommand(d => this.Theme.SetLightTheme());
                }
                return this._LightTheme;
            }
        }

        #endregion ThemaManager

        #region View Manager
        /// <summary>
        /// Internal field
        /// </summary>
        private ViewManager _View = null!;

        /// <summary>
        /// Provides the Service for managing the View settings
        /// </summary>
        public ViewManager View
        {
            get
            {
                if (this._View == null)
                {
                    this._View = this.Context.Produce<ViewManager>();
                }
                return this._View;
            }
        }

        #endregion View Manager

        #region GoTo Service

        /// <summary>
        /// Internal field
        /// </summary>
        private Support.LineNavigation _Navigation = null!;

        /// <summary>
        /// Provides the Service for navigating through 
        /// the lines of the Tab Content
        /// </summary>
        public Support.LineNavigation Navigation
        {
            get
            {
                if (this._Navigation == null)
                {
                    this._Navigation = this.Context.Produce<Support.LineNavigation>();
                }
                return this._Navigation;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _GoTo = null!;

        /// <summary>
        /// Opens the Navigation Window
        /// </summary>
        public BaseCommand GoTo
        {
            get
            {
                if (this._GoTo == null)
                {
                    this._GoTo = new BaseCommand(d =>
                    {

                        this.Navigation.Window.OpenNavigationWindow(d);

                    });
                }
                return this._GoTo;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _GoToLine = null!;

        /// <summary>
        /// Moves the Tab Caret to the index from the Navigation service
        /// </summary>
        public BaseCommand GoToLine
        {
            get
            {
                if (this._GoToLine == null)
                {
                    this._GoToLine = new BaseCommand(d => this.Navigation.SetLine(this.Tabs.SelectedTabItem,d));
                }
                return this._GoToLine;
            }
        }

        #endregion GoTo Service

        #region Font Manager

        /// <summary>
        /// Internal field
        /// </summary>
        private Support.FontManager _Font = null!;

        /// <summary>
        /// Provides the service for handling the Font settings
        /// </summary>
        public Support.FontManager Font
        {
            get
            {
                if (this._Font == null)
                {
                    this._Font = this.Context.Produce<Support.FontManager>();
                }
                return this._Font;
            }
        }

        #endregion Font Manager

        #region Font MenuItems

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _FindNext = null!;

        /// <summary>
        /// Provides the Find next command of the Tab service to the Menu
        /// </summary>
        public BaseCommand FindNext
        {
            get
            {
                if (this._FindNext == null)
                {
                    this._FindNext = new BaseCommand(d =>
                    {
                        //if there is no text to find open the window
                        if (string.IsNullOrEmpty(this.Tabs.Find.Data.SearchQuery))
                        {
                            this.Tabs.ShowFindDialog.Execute(d);
                        }
                        else
                        {
                            //if there is a text just execute the command 
                            this.Tabs.FindNext.Execute(d);
                        }
                    }, d => !string.IsNullOrEmpty(this.Tabs.SelectedTabItem.Content)

                    );
                }
                return this._FindNext;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _FindPrevious = null!;

        /// <summary>
        /// Provides the Find previous command of the Tab service to the Menu
        /// </summary>
        public BaseCommand FindPrevious
        {
            get
            {
                if (this._FindPrevious == null)
                {
                    this._FindPrevious = new BaseCommand(d =>
                    {
                        if (string.IsNullOrEmpty(this.Tabs.Find.Data.SearchQuery))
                        {
                            //if there is no text to look up
                            this.Tabs.ShowFindDialog.Execute(d);
                        }
                        else
                        {
                            //if there is already an window made and the text to search for is given
                            this.Tabs.FindPrevious.Execute(d);
                        }
                    }, d => !string.IsNullOrEmpty(this.Tabs.SelectedTabItem.Content)

                    );
                }
                return this._FindPrevious;
            }
        }

        #endregion Font MenuItems

    }
}
