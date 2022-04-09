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
using PasswordManagementSystem.Forms;
using PasswordManagementSystem.Models;

namespace PasswordManagementSystem.Views.FormView
{
    /// <summary>
    /// Interaction logic for SignInForgot.xaml
    /// </summary>
    public partial class SignInForgot : UserControl
    {
        public string PrivateCode;
        public string Email;
        public SignInForgot()
        {
            this.PrivateCode = "";
            this.Email = "";
            InitializeComponent();
        }
        private void TextBoxPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxPassword.Text == "Password" || TextBoxPassword.Text == "Invalid_Input")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.Foreground = Brushes.Black;
            }
            return;
        }

        private void TextBoxPinCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxPinCode.Text == "PIN Code")
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
            if (TextBoxPassword.Text == "")
            {
                TextBoxPassword.Text = "Password";
                TextBoxPassword.Foreground = (Brush)br.ConvertFrom("#707070");
            }
            return;
        }
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {


            if (TextBoxPassword.Text == "Password")
            {
                TextBoxPassword.Text = "Invalid_Input";
                TextBoxPassword.Foreground = Brushes.Red;
            }

            if (TextBoxPinCode.Text == "PIN Code")
            {
                TextBoxPinCode.Text = "Invalid Input";
                TextBoxPinCode.Foreground = Brushes.Red;
            }

            if (TextBoxPassword.Text != "Password" && TextBoxPinCode.Text == this.PrivateCode)
            {
                string[] information = new string[4];
                DataCryptography cypher = new DataCryptography();

                DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
                adminConnection.getVerifiedUser(information, this.Email);
                string oldPassword = information[2];

                information[3] = new Hash().Encrypt(TextBoxPassword.Text);
                adminConnection.updateUserInformation(information, this.Email);

                DatabaseUser userConnection = new DatabaseUser(cypher.Encrypt(information[1]));
                userConnection.updateUserInformation(oldPassword, information[3]);

                var main = Window.GetWindow(this);
                SignIn newWindow = new SignIn();

                main.Hide();
                newWindow.Show();
                main.Close();
            }
            
            return;
        }
    }
}
