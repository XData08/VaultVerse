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
using PasswordManagementSystem.Views.TemplateView;

namespace PasswordManagementSystem.TemplateCredential
{
    /// <summary>
    /// Interaction logic for TemplateAccount.xaml
    /// </summary>
    public partial class TemplateAccount : Window
    {

        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateAccount(MainWindow main, string databaseName, string purpose, string[] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if(purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this,main, databaseName, "CredentialAccount");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            } 
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, ApplicationName, UserNameBox, EmailBox, PasswordBox, NoteBox };
                for ( int i=0; i<boxes.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(information[i + 1]))
                    {
                        boxes[i].Text = information[i + 1];
                        boxes[i].Foreground = Brushes.Black;
                    } else
                    {
                        boxes[i].Foreground = (Brush)br.ConvertFrom("#ABABAB");
                    }
                }
                this.modify = new ButtonModifyForm(this, main,databaseName, "CredentialAccount");
                this.modify.toChange = information[1];

                for (int i=0; i < information.Length-1;i++)
                {
                    this.modify.credentialAccount[i] = information[i];
                }
                ButtonArea.Children.Add(modify);
            }
      
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

        private void TitleBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (TitleBox.Text == "Title")
            {
                TitleBox.Text = "";
                TitleBox.Foreground = Brushes.Black;
            }
            return;
        }

        private void ApplicationNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (ApplicationName.Text == "Application Name")
            {
                ApplicationName.Text = "";
                ApplicationName.Foreground = Brushes.Black;
            }
            return;
        }

        private void UserNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (UserNameBox.Text == "Username")
            {
                UserNameBox.Text = "";
                UserNameBox.Foreground = Brushes.Black;
            }
            
            return;
        }

        private void EmailBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (EmailBox.Text == "Email Address")
            {
                EmailBox.Text = "";
                EmailBox.Foreground = Brushes.Black;
            }
            return;
        }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (PasswordBox.Text == "Password")
            {
                PasswordBox.Text = "";
                PasswordBox.Foreground = Brushes.Black;
            }
            return;
        }

        private void NoteBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NoteBox.Text == "Notes")
            {
                NoteBox.Text = "";
                NoteBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void Reset_KeyUp(object sender = null, KeyEventArgs e = null)
        {
            var br = new BrushConverter();

            if (TitleBox.Text == "")
            {
                TitleBox.Text = "Title";
                TitleBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            } 
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.credentialAccount[1] = "Input Title Here";
                    }
                } else
                {
                    this.modify.credentialAccount[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.credentialAccount[1] = "Input Title Here";
                    }
                }
            }

            if (ApplicationName.Text == "")
            {
                ApplicationName.Text = "Application Name";
                ApplicationName.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            } 
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[2] = ApplicationName.Text;
                    if (ApplicationName.Text == "Application Name")
                    {
                        this.submit.credentialAccount[2] = "";
                    }
                }
                else
                {
                    this.modify.credentialAccount[2] = ApplicationName.Text;
                    if (ApplicationName.Text == "Application Name")
                    {
                        this.modify.credentialAccount[2] = "";
                    }
                }
            }

            if (UserNameBox.Text == "")
            {
                UserNameBox.Text = "Username";
                UserNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            } 
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[3] = UserNameBox.Text;
                    if (UserNameBox.Text == "Username")
                    {
                        this.submit.credentialAccount[3] = "";
                    }
                }
                else
                {
                    this.modify.credentialAccount[3] = UserNameBox.Text;
                    if (UserNameBox.Text == "Username")
                    {
                        this.modify.credentialAccount[3] = "";
                    }
                }
            }

            if (EmailBox.Text == "")
            {
                EmailBox.Text = "Email Address";
                EmailBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[4] = EmailBox.Text;
                    if (EmailBox.Text == "Email Address")
                    {
                        this.submit.credentialAccount[4] = "";
                    }
                }
                else
                {
                    this.modify.credentialAccount[4] = EmailBox.Text;
                    if (UserNameBox.Text == "Email Address")
                    {
                        this.modify.credentialAccount[4] = "";
                    }
                }
            }

            if (PasswordBox.Text == "")
            {
                PasswordBox.Text = "Password";
                PasswordBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            } 
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[5] = PasswordBox.Text;
                    if (PasswordBox.Text == "Password")
                    {
                        this.submit.credentialAccount[5] = "";
                    }
                }
                else
                {
                    this.modify.credentialAccount[5] = PasswordBox.Text;
                    if (PasswordBox.Text == "Password")
                    {
                        this.modify.credentialAccount[5] = "";
                    }
                }
            }

            if (NoteBox.Text == "")
            {
                NoteBox.Text = "Notes";
                NoteBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            } 
            else
            {

                if (this.purpose == "Add")
                {
                    this.submit.credentialAccount[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.credentialAccount[6] = "";
                    }
                }
                else
                {
                    this.modify.credentialAccount[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.credentialAccount[6] = "";
                    }
                }
            }
            return;
        }
    }
}
