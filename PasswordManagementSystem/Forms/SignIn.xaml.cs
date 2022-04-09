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
    /// Interaction logic for SignIn.xaml
    /// </summary>
    public partial class SignIn : Window
    {
        private DatabaseAdmin connection;
        public SignIn()
        {
            this.connection = new DatabaseAdmin("vaultverse_schema");
            this.connection.deleteNonVerifiedUsers();
            InitializeComponent();
            return;
        }

        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
            return; 
        }

        private void TextBoxEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (TextBoxEmail.Text == "Email" || TextBoxEmail.Text == "Invalid Input")
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
            return;
        }

        private void Form_ForgotPassword(object sender, RoutedEventArgs e)
        {
            if (TextBoxEmail.Text != "Email")
            {
                DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
                EmailVerification cv = new EmailVerification();
                Hash hash = new Hash();
                string[] information = new string[4];

                if (adminConnection.isEmailExist(TextBoxEmail.Text))
                {
                    adminConnection.getVerifiedUser(information, TextBoxEmail.Text);
                    cv.sendVerificationCode(information[2], information[1]);

                    SignInForm_Container_1.Visibility = Visibility.Collapsed;
                    SignInForm_Container_2.Visibility = Visibility.Visible;

                    SignInForgot.PrivateCode = cv.GetCode();
                    SignInForgot.Email = information[2];
                    SignInForgot.Visibility = Visibility.Visible;
                }   
            }
            else
            {
                TextBoxEmail.Text = "Invalid Input";
                TextBoxEmail.Foreground = Brushes.Red;
            }
            
            
            return;
        }

        private void Form_SignIn(object sender, RoutedEventArgs e)
        {
            DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
            Hash hash = new Hash();
            string[] information = new string[4];

            if (TextBoxEmail.Text == "Email")
            {
                TextBoxEmail.Text = "Invalid Input";
                TextBoxEmail.Foreground = Brushes.Red;
            }

            if (TextBoxPassword.Text == "Password")
            {
                TextBoxPassword.Text = "Invalid_Input";
                TextBoxPassword.Foreground = Brushes.Red;
            }

            if (adminConnection.isEmailExist(TextBoxEmail.Text))
            {
                adminConnection.getVerifiedUser(information, TextBoxEmail.Text);
                if (information[2] == TextBoxEmail.Text && information[3] == hash.Encrypt(TextBoxPassword.Text))
                {
                
                    EmailVerification cv = new EmailVerification();

                    cv.sendVerificationCode(information[2], information[1]);

                    SignInForm_Container_1.Visibility = Visibility.Collapsed;
                    SignInForm_Container_2.Visibility = Visibility.Visible;

                    SignInVerfication.PrivateCode = cv.GetCode();
                    SignInVerfication.Email = information[2];
                    SignInVerfication.Visibility = Visibility.Visible;
                }
            } 
            return;
        }

        private void Form_SignUp(object sender, RoutedEventArgs e)
        { 
            SignUp signup = new SignUp();
            this.Hide();
            signup.Show();
            this.Close();
            return;
        }
    }
}
