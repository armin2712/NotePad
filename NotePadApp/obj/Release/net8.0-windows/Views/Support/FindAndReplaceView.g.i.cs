﻿#pragma checksum "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "60E97DFE99BA9AF41FE6B883AC7D8EA35A18C5BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using NotePadApp.Assets;
using NotePadApp.ViewModels;
using NotePadApp.Views;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace NotePadApp.Views.Support {
    
    
    /// <summary>
    /// FindAndReplaceView
    /// </summary>
    public partial class FindAndReplaceView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 47 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border WindowBorder;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchTextBox;
        
        #line default
        #line hidden
        
        
        #line 206 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FindButton;
        
        #line default
        #line hidden
        
        
        #line 305 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ReplaceRowContent;
        
        #line default
        #line hidden
        
        
        #line 340 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ReplaceTextBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/NotePadApp;V2024.1.0.0;component/views/support/findandreplaceview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.3.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.WindowBorder = ((System.Windows.Controls.Border)(target));
            return;
            case 2:
            this.searchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 144 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
            this.searchTextBox.GotFocus += new System.Windows.RoutedEventHandler(this.Element_GotFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.FindButton = ((System.Windows.Controls.Button)(target));
            
            #line 217 "..\..\..\..\..\Views\Support\FindAndReplaceView.xaml"
            this.FindButton.GotFocus += new System.Windows.RoutedEventHandler(this.Element_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ReplaceRowContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.ReplaceTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

