﻿#pragma checksum "..\..\..\Main\wndMain.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "72234B4B1904654E1FF407F4B3E6F60F237D3672E1CD85767B5E4CEE6B411555"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupProject;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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


namespace GroupProject {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Menu Menu;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem itemSearch;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem itemItems;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem itemsClose;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtbxTotalCost;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddItem;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lstbxItemsAdded;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRemoveItem;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditInvoice;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnNewInvoice;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Main\wndMain.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteInvoice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/GroupProject;component/main/wndmain.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Main\wndMain.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Menu = ((System.Windows.Controls.Menu)(target));
            return;
            case 2:
            this.itemSearch = ((System.Windows.Controls.MenuItem)(target));
            
            #line 11 "..\..\..\Main\wndMain.xaml"
            this.itemSearch.Click += new System.Windows.RoutedEventHandler(this.itemSearch_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.itemItems = ((System.Windows.Controls.MenuItem)(target));
            
            #line 12 "..\..\..\Main\wndMain.xaml"
            this.itemItems.Click += new System.Windows.RoutedEventHandler(this.itemItems_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.itemsClose = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\..\Main\wndMain.xaml"
            this.itemsClose.Click += new System.Windows.RoutedEventHandler(this.itemClose_Cllick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtbxTotalCost = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.btnAddItem = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.lstbxItemsAdded = ((System.Windows.Controls.ListBox)(target));
            return;
            case 8:
            this.btnRemoveItem = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnEditInvoice = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.btnNewInvoice = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.btnDeleteInvoice = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

