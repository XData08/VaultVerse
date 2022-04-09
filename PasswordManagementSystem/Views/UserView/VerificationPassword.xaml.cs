using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManagementSystem.Views.UserView
{
    /// <summary>
    /// Interaction logic for VerificationPassword.xaml
    /// </summary>
    public partial class VerificationPassword : UserControl
    {
        public VerificationPassword()
        {
            InitializeComponent();
        }

        private void VerificationCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (VerificationCode.Text == "PIN Code")
            {
                VerificationCode.Text = "";
                VerificationCode.Foreground = Brushes.Black;
            }
            return;
        }
        
        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            var br = new BrushConverter();
            if (VerificationCode.Text == "")
            {
                VerificationCode.Text = "PIN Code";
                VerificationCode.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            return;
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {

            return;
        }
    }
}
