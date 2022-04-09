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

namespace PasswordManagementSystem
{
    /// <summary>
    /// Interaction logic for UserMenu.xaml
    /// </summary>
    public partial class UserMenu : Window
    {
        private Window main;
        private string DatabaseName;
        public UserMenu(Window main, string databaseName)
        {
            this.main = main;
            this.DatabaseName = databaseName;
            InitializeComponent();
            setUserProfile();           
        }

        private void setUserProfile()
        {
            string[] information = new string[8];

            DatabaseUser user = new DatabaseUser(this.DatabaseName);
            user.getUserInformation(information);


            UserName.Content = information[0];
            UserEmail.Content = information[1];

            string imageProfile = "";
            switch (Convert.ToInt32(information[3]))
            {
                case 0: imageProfile = "profile_big_0.png"; break;
                case 1: imageProfile = "profile_big_1.png"; break;
                case 2: imageProfile = "profile_big_2.png"; break;
                case 3: imageProfile = "profile_big_3.png"; break;
                case 4: imageProfile = "profile_big_4.png"; break;
                case 5: imageProfile = "profile_big_5.png"; break;
                case 6: imageProfile = "profile_big_6.png"; break;
                case 7: imageProfile = "profile_big_7.png"; break;
            }

            UserProfile.Source = new BitmapImage(new Uri(imageProfile, UriKind.Relative));
            Credential_Count.Content = information[4];
            Record_Count.Content = information[5];
            Gallery_Count.Content = information[6];
            Document_Count.Content = information[7];
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

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
            return;
        }

        private void ExitWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.main.WindowState = WindowState.Normal;
            return;
        }

        private void SignOutButton(object sender, RoutedEventArgs e)
        {
            this.Close();
            this.main.Close();
            return;
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (EmailBox.Text == "Email")
            {
                EmailBox.Text = "";
                EmailBox.Foreground = Brushes.Black;
            }
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (PasswordBox.Text == "Password")
            {
                PasswordBox.Text = "";
                PasswordBox.Foreground = Brushes.Black;
            }
        }

        private void NewPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NewPasswordBox.Text == "New Password")
            {
                NewPasswordBox.Text = "";
                NewPasswordBox.Foreground = Brushes.Black;
            }
        }

        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            var br = new BrushConverter();
            if (EmailBox.Text == "")
            {
                EmailBox.Text = "Email";
                EmailBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }

            if (PasswordBox.Text == "")
            {
                PasswordBox.Text = "Password";
                PasswordBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }

            if (NewPasswordBox.Text == "")
            {
                NewPasswordBox.Text = "New Password";
                NewPasswordBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            MyGrid.Visibility = Visibility.Collapsed;
            VerificationPassword.Visibility = Visibility.Visible;
            return;
        }
    }
}
