﻿#pragma checksum "..\..\..\TemplateGallery\TemplateVideo.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "856EE7E54DBC9532D7E9CABC748CF3C283101BC348CB96C733AEADA58AF17CBD"
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


namespace PasswordManagementSystem.TemplateGallery {
    
    
    /// <summary>
    /// TemplateVideo
    /// </summary>
    public partial class TemplateVideo : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\TemplateGallery\TemplateVideo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleBox;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\TemplateGallery\TemplateVideo.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoteBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\TemplateGallery\TemplateVideo.xaml"
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
            System.Uri resourceLocater = new System.Uri("/PasswordManagementSystem;component/templategallery/templatevideo.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TemplateGallery\TemplateVideo.xaml"
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
            
            #line 27 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            this.TitleBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TitleBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            this.TitleBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NoteBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 76 "..\..\..\TemplateGallery\TemplateVideo.xaml"
            this.NoteBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.NoteBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 77 "..\..\..\TemplateGallery\TemplateVideo.xaml"
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

