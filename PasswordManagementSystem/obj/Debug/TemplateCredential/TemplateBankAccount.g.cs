﻿#pragma checksum "..\..\..\TemplateCredential\TemplateBankAccount.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "06E7535A6C6FCF915A0018F2AA65A643AFB2F625F6EB5D2DECC78831D1E728FE"
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


namespace PasswordManagementSystem.TemplateCredential {
    
    
    /// <summary>
    /// TemplateBankAccount
    /// </summary>
    public partial class TemplateBankAccount : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 65 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TitleBox;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox BankNameBox;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AccountTypeBox;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AccountNumberBox;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PINBox;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NoteBox;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
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
            System.Uri resourceLocater = new System.Uri("/PasswordManagementSystem;component/templatecredential/templatebankaccount.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
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
            
            #line 27 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.MoveWindow);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 44 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.MinimizeWindow);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 52 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ExitWindow);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TitleBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 67 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.TitleBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.TitleBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 68 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.TitleBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.BankNameBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 74 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.BankNameBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.BankNameBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 75 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.BankNameBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.AccountTypeBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 81 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.AccountTypeBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.AccountTypeBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 82 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.AccountTypeBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 7:
            this.AccountNumberBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 88 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.AccountNumberBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.AccountNumberBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 89 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.AccountNumberBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PINBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 95 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.PINBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.PINBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 96 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.PINBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 9:
            this.NoteBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 104 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.NoteBox.KeyDown += new System.Windows.Input.KeyEventHandler(this.NoteBox_KeyDown);
            
            #line default
            #line hidden
            
            #line 105 "..\..\..\TemplateCredential\TemplateBankAccount.xaml"
            this.NoteBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 10:
            this.ButtonArea = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

