﻿#pragma checksum "..\..\..\TemplateRecord\TemplateCollaboration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EC4695D5322A7ACF11978068616364F069F38F61AC6A2E77BD794B1EEDEF532E"
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
    /// TemplateCollaboration
    /// </summary>
    public partial class TemplateCollaboration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SubjectBox;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoteBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
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
            System.Uri resourceLocater = new System.Uri("/PasswordManagementSystem;component/templaterecord/templatecollaboration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
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
            
            #line 27 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.TitleBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TitleBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.TitleBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SubjectBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 74 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.SubjectBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.SubjectBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.SubjectBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.NoteBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 83 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.NoteBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.NoteBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 84 "..\..\..\TemplateRecord\TemplateCollaboration.xaml"
            this.NoteBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ButtonArea = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

