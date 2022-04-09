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
    /// Interaction logic for TemplateLicense.xaml
    /// </summary>
    public partial class TemplateLicense : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateLicense(MainWindow main, string databaseName, string purpose, string [] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                submit = new ButtonSubmitForm(this, main , databaseName, "CredentialDriversLicense");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, FirstNameBox, MiddleNameBox, LastNameBox, NationalityBox, GenderBox 
                , DateOfBirthBox, HomeBox, ExpirationDateBox, LicenseBox, NoteBox};
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(information[i + 1]))
                    {
                        boxes[i].Text = information[i + 1];
                        boxes[i].Foreground = Brushes.Black;
                    }
                    else
                    {
                        boxes[i].Foreground = (Brush)br.ConvertFrom("#ABABAB");
                    }
                }
                this.modify = new ButtonModifyForm(this, main, databaseName, "CredentialDriversLicense");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.credentialDriversLicense[i] = information[i];
                }
                ButtonArea.Children.Add(modify);
            }
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

        private void FirstNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (FirstNameBox.Text == "First Name")
            {
                FirstNameBox.Text = "";
                FirstNameBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void MiddleNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (MiddleNameBox.Text == "Middle Name")
            {
                MiddleNameBox.Text = "";
                MiddleNameBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void LastNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (LastNameBox.Text == "Last Name")
            {
                LastNameBox.Text = "";
                LastNameBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void NationalityBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (NationalityBox.Text == "Nationality")
            {
                NationalityBox.Text = "";
                NationalityBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void GenderBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (GenderBox.Text == "Gender")
            {
                GenderBox.Text = "";
                GenderBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void DateOfBirthBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (DateOfBirthBox.Text == "Date of Birth")
            {
                DateOfBirthBox.Text = "";
                DateOfBirthBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void HomeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (HomeBox.Text == "Home Address")
            {
                HomeBox.Text = "";
                HomeBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void ExpirationDateBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (ExpirationDateBox.Text == "Expiration Date")
            {
                ExpirationDateBox.Text = "";
                ExpirationDateBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void LicenseBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (LicenseBox.Text == "License No.")
            {
                LicenseBox.Text = "";
                LicenseBox.Foreground = Brushes.Black;
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
            } else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.credentialDriversLicense[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.credentialDriversLicense[1] = "Input Title Here";
                    }
                }
            }

            if (FirstNameBox.Text == "")
            {
                FirstNameBox.Text = "First Name";
                FirstNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[2] = FirstNameBox.Text;
                    if (FirstNameBox.Text == "First Name")
                    {
                        this.submit.credentialDriversLicense[2] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[2] = FirstNameBox.Text;
                    if (FirstNameBox.Text == "First Name")
                    {
                        this.modify.credentialDriversLicense[2] = "";
                    }
                }
            }

            if (MiddleNameBox.Text == "")
            {
                MiddleNameBox.Text = "Middle Name";
                MiddleNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[3] = MiddleNameBox.Text;
                    if (MiddleNameBox.Text == "Middle Name")
                    {
                        this.submit.credentialDriversLicense[3] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[3] = MiddleNameBox.Text;
                    if (MiddleNameBox.Text == "Middle Name")
                    {
                        this.modify.credentialDriversLicense[3] = "";
                    }
                }
            }

            if (LastNameBox.Text == "")
            {
                LastNameBox.Text = "Last Name";
                LastNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[4] = LastNameBox.Text;
                    if (LastNameBox.Text == "Last Name")
                    {
                        this.submit.credentialDriversLicense[4] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[4] = LastNameBox.Text;
                    if (LastNameBox.Text == "Last Name")
                    {
                        this.modify.credentialDriversLicense[4] = "";
                    }
                }
            }

            if (NationalityBox.Text == "")
            {
                NationalityBox.Text = "Nationality";
                NationalityBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[5] = NationalityBox.Text;
                    if (NationalityBox.Text == "Nationality")
                    {
                        this.submit.credentialDriversLicense[5] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[5] = NationalityBox.Text;
                    if (NationalityBox.Text == "Nationality")
                    {
                        this.modify.credentialDriversLicense[5] = "";
                    }
                }
            }

            if (GenderBox.Text == "")
            {
                GenderBox.Text = "Gender";
                GenderBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[6] = GenderBox.Text;
                    if (GenderBox.Text == "Gender")
                    {
                        this.submit.credentialDriversLicense[6] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[6] = GenderBox.Text;
                    if (GenderBox.Text == "Gender")
                    {
                        this.modify.credentialDriversLicense[6] = "";
                    }
                }
            }

            if (DateOfBirthBox.Text == "")
            {
                DateOfBirthBox.Text = "Date of Birth";
                DateOfBirthBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[7] = DateOfBirthBox.Text;
                    if (DateOfBirthBox.Text == "Date of Birth")
                    {
                        this.submit.credentialDriversLicense[7] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[7] = DateOfBirthBox.Text;
                    if (DateOfBirthBox.Text == "Date of Birth")
                    {
                        this.modify.credentialDriversLicense[7] = "";
                    }
                }
            }

            if (HomeBox.Text == "")
            {
                HomeBox.Text = "Home Address";
                HomeBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[8] = HomeBox.Text;
                    if (HomeBox.Text == "Home Address")
                    {
                        this.submit.credentialDriversLicense[8] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[8] = HomeBox.Text;
                    if (HomeBox.Text == "Home Address")
                    {
                        this.modify.credentialDriversLicense[8] = "";
                    }
                }
            }

            if (ExpirationDateBox.Text == "")
            {
                ExpirationDateBox.Text = "Expiration Date";
                ExpirationDateBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[9] = ExpirationDateBox.Text;
                    if (ExpirationDateBox.Text == "Expiration Date")
                    {
                        this.submit.credentialDriversLicense[9] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[9] = ExpirationDateBox.Text;
                    if (ExpirationDateBox.Text == "Expiration Date")
                    {
                        this.modify.credentialDriversLicense[9] = "";
                    }
                }
            }

            if (LicenseBox.Text == "")
            {
                LicenseBox.Text = "License No.";
                LicenseBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialDriversLicense[10] = LicenseBox.Text;
                    if (LicenseBox.Text == "License No.")
                    {
                        this.submit.credentialDriversLicense[10] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[10] = LicenseBox.Text;
                    if (LicenseBox.Text == "License No.")
                    {
                        this.modify.credentialDriversLicense[10] = "";
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
                    this.submit.credentialDriversLicense[11] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.credentialDriversLicense[11] = "";
                    }
                }
                else
                {
                    this.modify.credentialDriversLicense[11] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.credentialDriversLicense[11] = "";
                    }
                }
            }
            return;
        }
    }
}
