using NotePadApp.Models;
using NotePadApp.ViewModels.FindService;
using System.ComponentModel;
using System.Windows.Controls;
using WPF.Window.Support;

namespace NotePadApp.ViewModels
{

    /// <summary>
    /// Manages the tabs and their interactions.
    /// </summary>
    public class TabsManager : BaseViewModel
    {

        #region Current Tab

        /// <summary>
        /// Internal field
        /// </summary>
        private Tab _SelectedTabItem = null!;

        /// <summary>
        /// Gets or sets the currently selected tab.
        /// </summary>
        public Tab SelectedTabItem
        {
            get => this._SelectedTabItem;
            set
            {
                this._SelectedTabItem = value;
                this.OnPropertyChanged();

            }
        }


        #endregion Current Tab

        #region Tab Controller

        /// <summary>
        /// Internal field
        /// </summary>
        private TabController _Controller = null!;

        /// <summary>
        /// Provides the service for handling Tab related operations
        /// </summary>
        private TabController Controller
        {
            get
            {
                if (this._Controller == null)
                {
                    this._Controller=this.Context.Produce<TabController>();
                }
                return this._Controller;
            }
        }

        #endregion Tab Controller

        #region Data

        /// <summary>
        /// Internal field
        /// </summary>
        private Tabs _List = null!;

        /// <summary>
        /// Gets the list of tabs managed by the tabs manager.
        /// </summary>
        public Tabs List
        {
            get
            {
                if (this._List == null)
                {
                    this._List = new Tabs();
                }
                return this._List;

            }
        }
        #endregion Data

        #region New Tab

        /// <summary>
        /// Internal Field
        /// </summary>
        private BaseCommand _NewTab = null!;

        /// <summary>
        /// Gets the command to add a new tab.
        /// </summary>
        public BaseCommand NewTab
        {

            get
            {
                if (this._NewTab == null)
                {
                    this._NewTab = new BaseCommand(d =>
                    {
                        this.List.Add(new Tab());
                        this.SelectedTabItem=this.List.Last();
                    });
                }

                return this._NewTab;
            }
        }



        #endregion New Tab

        #region Open Tab

        /// <summary>
        /// Internal Field
        /// </summary>
        private BaseCommand _OpenTab = null!;

        /// <summary>
        /// Gets the command for opening a new tab
        /// </summary>
        public BaseCommand OpenTab
        {
            get
            {
                if (this._OpenTab == null)
                {
                    this._OpenTab = new BaseCommand(
                        d =>
                        {
                            var tab=this.Controller.OpenFile();
                            if (tab != null)
                            {
                                this.List.Add(tab);
                                this.SelectedTabItem = this.List.Last();
                            }
                        }
                        );
                }

                return this._OpenTab;
            }
        }

        #endregion Open Tab

        #region Save

        /// <summary>
        /// Provides the option the save a Tab with the suggestion if 
        /// there is no given save name of the Tab
        /// </summary>
        public void SaveWithSuggestion()
        {
            this.Controller.SaveFile(this.SelectedTabItem, this.SelectedTabItem.Name);
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Save = null!;

        /// <summary>
        /// Gets the command to save the current selected tab
        /// </summary>
        public BaseCommand Save
        {
            get
            {
                if (this._Save == null)
                {
                    this._Save = new BaseCommand(d =>
                    {
                        this.Controller.SaveFile(this.SelectedTabItem);
                    }
                    );
                }
                return this._Save;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _SaveAs = null!;

        /// <summary>
        /// Gets the command to save as the current selected tab
        /// </summary>
        public BaseCommand SaveAs
        {
            get
            {
                if (this._SaveAs == null)
                {
                    this._SaveAs = new BaseCommand(d =>
                    {
                        this.Controller.Export(this.SelectedTabItem);
                    }
                    );
                }
                return this._SaveAs;
            }
        }
        #endregion Save

        #region Save All

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _SaveAll = null!;

        /// <summary>
        /// Gets the command to save all open tabs
        /// </summary>
        public BaseCommand SaveAll
        {
            get
            {
                if (this._SaveAll == null)
                {
                    this._SaveAll = new BaseCommand(d => this.Controller.SaveAll(this.List));
                }
                return this._SaveAll;
            }
        }

        #endregion Save All 

        #region Print and Page setup

        /// <summary>
        /// Internal Field
        /// </summary>
        private WPF.Window.Support.BaseCommand _PageSetup = null!;

        /// <summary>
        /// Gets the command for opening Print dialog
        /// </summary>
        public WPF.Window.Support.BaseCommand PageSetup
        {
            get
            {
                if (this._PageSetup == null)
                {
                    this._PageSetup = new BaseCommand(d =>
                    this.Controller.OpenPageSetup(this.SelectedTabItem.Content));
                }
                return this._PageSetup;
            }
        }

        #endregion Print and Page setup

        #region Date

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Date = null!;

        /// <summary>
        /// Gets the command for adding Date to 
        /// the current position of the caret
        /// </summary>
        public BaseCommand Date
        {
            get
            {
                if (this._Date == null)
                {
                    this._Date = new BaseCommand(d =>
                    {
                        //get the current date and time
                        string currentDateTime = System.DateTime.Now.ToString();
                        this.SelectedTabItem.Content
                        = this.SelectedTabItem.Content.Insert(
                            this.SelectedTabItem.Caret.Index, currentDateTime); //look for the caret position and place the date
                        this.SelectedTabItem.Caret.Index //set the caret index after the date
                        = this.SelectedTabItem.Caret.Index + currentDateTime.Length;
                    });
                }
                return this._Date;
            }
        }

        #endregion Date

        #region Find 

        /// <summary>
        /// Internal field
        /// </summary>
        private FindManager _Find = null!;

        /// <summary>
        /// Provides the Service for searching in a Tab Content
        /// </summary>
        public FindManager Find
        {
            get
            {
                if(this._Find == null)
                {
                    this._Find=this.Context.Produce<FindManager>();
                }
                return this._Find;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _FindNext = null!;

        /// <summary>
        /// Finds the next occurence of the text provided in the Find Service
        /// in the current Tab
        /// </summary>
        public BaseCommand FindNext
        {
            get
            {
                if (this._FindNext == null)
                {
                    this._FindNext = new BaseCommand(d => this.Find.FindNext(this.SelectedTabItem,d));
                }
                return this._FindNext;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _FindPrevious = null!;

        /// <summary>
        /// Finds the previous occurence of the text provided in the Find Service
        /// in the current Tab
        /// </summary>
        public BaseCommand FindPrevious
        {
            get
            {
                if (this._FindPrevious == null)
                {
                    this._FindPrevious = new BaseCommand(d => this.Find.FindPrevious(this.SelectedTabItem,d));
                }
                return this._FindPrevious;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ShowReplaceDialog = null!;

        /// <summary>
        /// Opens the Find Service window with the Replace section activated
        /// </summary>
        public BaseCommand ShowReplaceDialog
        {
            get
            {
                if (this._ShowReplaceDialog == null)
                {
                    this._ShowReplaceDialog =
                        new BaseCommand(d =>
                        {
                            this.Find.Window.ToggleReplace.Execute(d);
                            this.Find.Window.OpenFindWindow(d);
                        },
                        d => !string.IsNullOrEmpty(this.SelectedTabItem.Content)
                        );
                }
                return this._ShowReplaceDialog;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ShowFindDialog = null!;

        /// <summary>
        /// Opens the Find Service window
        /// </summary>
        public BaseCommand ShowFindDialog
        {
            get
            {
                if (this._ShowFindDialog == null)
                {
                    this._ShowFindDialog = new BaseCommand(d => this.Find.Window.OpenFindWindow(d),
                        d => !string.IsNullOrEmpty(this.SelectedTabItem.Content)
                        );
                }
                return this._ShowFindDialog;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _Replace = null!;

        /// <summary>
        /// Replaces first occurence 
        /// the text found in the Tab Content with the text provided by the user
        /// </summary>
        public BaseCommand Replace
        {
            get
            {
                if(this._Replace == null)
                {
                    this._Replace = new BaseCommand(d =>
                    this.Find.Replace(this.SelectedTabItem, d));
                }
                return this._Replace;
            }
        }

        /// <summary>
        /// Internal field
        /// </summary>
        private BaseCommand _ReplaceAll = null!;

        /// <summary>
        /// Replaces all occurences
        /// the text found in the Tab Content with the text provided by the user
        /// </summary>
        public BaseCommand ReplaceAll
        {
            get
            {
                if(this._ReplaceAll == null)
                {
                    this._ReplaceAll = new BaseCommand(d =>
                    this.Find.ReplaceAll(this.SelectedTabItem, d));
                }
                return this._ReplaceAll;
            }
        }

        #endregion Find

    }

}
