﻿#pragma checksum "..\..\..\TemplateRecord\TemplateList.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C7147AB29BE3B7A8D5952734BD4B9553085A9AA8A19BF75669EC9CC3E1A7BD84"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PasswordManagementSystem.Views.TemplateView;
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


namespace PasswordManagementSystem.TemplateRecord {
    
    
    /// <summary>
    /// TemplateList
    /// </summary>
    public partial class TemplateList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\TemplateRecord\TemplateList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\TemplateRecord\TemplateList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoteBox;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\TemplateRecord\TemplateList.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ButtonArea;
        
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
            System.Uri resourceLocater = new System.Uri("/PasswordManagementSystem;component/templaterecord/templatelist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TemplateRecord\TemplateList.xaml"
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
            
            #line 27 "..\..\..\TemplateRecord\TemplateList.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\TemplateRecord\TemplateList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\TemplateRecord\TemplateList.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\TemplateRecord\TemplateList.xaml"
            this.TitleBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TitleBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\TemplateRecord\TemplateList.xaml"
            this.TitleBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NoteBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\TemplateRecord\TemplateList.xaml"
            this.NoteBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.NoteBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\TemplateRecord\TemplateList.xaml"
            this.NoteBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.ButtonArea = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

