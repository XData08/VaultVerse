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
using System.Windows.Shapes;
using PasswordManagementSystem.Models;

namespace PasswordManagementSystem.Forms
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
 
        public SignUp()
        {
            InitializeComponent();
        }
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            return;
        }

        private void Form_SignIn(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SignIn signin = new SignIn();
            signin.Show();
            this.Close();
        }

        private void TextBoxName_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxName.Text == "Name" || TextBoxName.Text == "Invalid Input")
            {
                TextBoxName.Text = "";
                TextBoxName.Foreground = Brushes.Black;
            }
            return;
        }

        private void TextBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxEmail.Text == "Email" || TextBoxEmail.Text == "Invalid Input"
                || TextBoxEmail.Text == "Invalid Email")
            {
                TextBoxEmail.Text = "";
                TextBoxEmail.Foreground = Brushes.Black;
            }
            return;
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

        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            var br = new BrushConverter();
            if (TextBoxPassword.Text == "")
            {
                TextBoxPassword.Text = "Password";
                TextBoxPassword.Foreground = (Brush)br.ConvertFrom("#707070");
            }
            if (TextBoxEmail.Text == "")
            {
                TextBoxEmail.Text = "Email";
                TextBoxEmail.Foreground = (Brush)br.ConvertFrom("#707070");
            }
            if (TextBoxName.Text == "")
            {
                TextBoxName.Text = "Name";
                TextBoxName.Foreground = (Brush)br.ConvertFrom("#707070");
            }
            return;
        }

        private void TermsCondition(object sender, RoutedEventArgs e)
        {
            TermsCondition terms = new TermsCondition(this);
            terms.Show();

            return;
        }

        private void Form_SignUp(object sender, RoutedEventArgs e)
        {

            DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
            bool isOkay = true;

            if (TextBoxName.Text == "Name")
            {
                TextBoxName.Foreground = Brushes.Red;
                TextBoxName.Text = "Invalid Input";
                isOkay = false;
            }

            if (TextBoxPassword.Text == "Password")
            {
                TextBoxPassword.Foreground = Brushes.Red;
                TextBoxPassword.Text = "Invalid_Input";
                isOkay = false;
            }

            if (TextBoxEmail.Text == "Email")
            {
                TextBoxEmail.Foreground = Brushes.Red;
                TextBoxEmail.Text = "Invalid Input";
                isOkay = false;
            } 
            else
            {
                string email = TextBoxEmail.Text;
                bool isExist = adminConnection.isEmailExist(email);

                if (!isExist)
                {
                    isOkay = true;
                } 
                else
                {
                    TextBoxEmail.Foreground = Brushes.Red;
                    TextBoxEmail.Text = "Invalid Email";
                    isOkay = false;
                }
            }
            

            if (isOkay && MyCheckBox.IsChecked == true)
            {

                Hash hash = new Hash();
               
                string[] userInformation =
                {
                    "0",
                    $"'{TextBoxName.Text}'",
                    $"'{TextBoxEmail.Text}'",
                    $"'{hash.Encrypt(TextBoxPassword.Text)}'"
                };

                if (adminConnection.addNewUser(userInformation))
                {
                    string[] information = new string[4];

                    SignUpForm_Container_1.Visibility = Visibility.Collapsed;
                    SignUpForm_Container_2.Visibility = Visibility.Visible;

                    EmailVerification cv = new EmailVerification();
                    DatabaseAdmin connect = new DatabaseAdmin("vaultverse_schema");

                    connect.getNonVerifiedUser(information);
                    cv.sendVerificationCode(information[2], information[1]);

                    SignUpVerification.PrivateCode = cv.GetCode();
                    SignUpVerification.Visibility = Visibility.Visible;
                    
                }
            }
            
            return;
        }

    }
}
