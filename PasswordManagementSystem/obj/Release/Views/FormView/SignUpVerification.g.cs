#pragma checksum "..\..\..\..\Views\FormView\SignUpVerification.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "281680E0ABCF3778732B0DD53366EE3EEC28D59625F80725B7B32627BD76F724"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PasswordManagementSystem.Views.FormView;
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


namespace PasswordManagementSystem.Views.FormView {
    
    
    /// <summary>
    /// SignUpVerification
    /// </summary>
    public partial class SignUpVerification : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxPinCode;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SubmitButton;
        
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
            System.Uri resourceLocater = new System.Uri("/PasswordManagementSystem;component/views/formview/signupverification.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
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
            this.TextBoxPinCode = ((System.Windows.Controls.TextBox)(target));
            
            #line 34 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
            this.TextBoxPinCode.KeyDown += new System.Windows.Input.KeyEventHandler(this.TextBoxPinCode_KeyDown);
            
            #line default
            #line hidden
            
            #line 35 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
            this.TextBoxPinCode.KeyUp += new System.Windows.Input.KeyEventHandler(this.Reset_KeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.SubmitButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\..\Views\FormView\SignUpVerification.xaml"
            this.SubmitButton.Click += new System.Windows.RoutedEventHandler(this.SubmitButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

