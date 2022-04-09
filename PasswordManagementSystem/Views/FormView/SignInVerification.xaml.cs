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
using PasswordManagementSystem;
using PasswordManagementSystem.Models;

namespace PasswordManagementSystem.Views.FormView
{
    /// <summary>
    /// Interaction logic for SignInVerification.xaml
    /// </summary>
    public partial class SignInVerification : UserControl
    {
        public string PrivateCode;
        public string Email;

        public SignInVerification()
        {
            this.PrivateCode = "";
            this.Email = "";
            InitializeComponent();
        }

        private void TextBoxPinCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxPinCode.Text == "PIN Code" || TextBoxPinCode.Text == "Invalid Code") 
            {
                TextBoxPinCode.Text = "";
                TextBoxPinCode.Foreground = Brushes.Black;
            }
            return;
        }
        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            var br = new BrushConverter();
            if (TextBoxPinCode.Text == "")
            {
                TextBoxPinCode.Text = "PIN Code";
                TextBoxPinCode.Foreground = (Brush)br.ConvertFrom("#707070");
            }
            return;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            string[] information = new string[4];
           
            if (TextBoxPinCode.Text != this.PrivateCode) 
            {
                TextBoxPinCode.Text = "Invalid Code";
                TextBoxPinCode.Foreground = Brushes.Red;
            } 
            else
            {
                DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
                Hash hash = new Hash();

                adminConnection.getVerifiedUser(information, this.Email);
                
                string databaseName = hash.Encrypt(information[1]);
                var main = Window.GetWindow(this);
                MainWindow newWindow = new MainWindow(databaseName);

                main.Hide();
                newWindow.Show();
                main.Close();
            }
            
            return;
        }
    }
}
