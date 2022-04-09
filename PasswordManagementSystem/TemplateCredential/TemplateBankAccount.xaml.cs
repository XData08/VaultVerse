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
    /// Interaction logic for TemplateBankAccount.xaml
    /// </summary>
    public partial class TemplateBankAccount : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplateBankAccount(MainWindow main, string databaseName, string purpose, string[] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                this.submit = new ButtonSubmitForm(this, main, databaseName, "CredentialBankAccount");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();
                TextBox[] boxes = { TitleBox, BankNameBox, AccountTypeBox, AccountNumberBox, PINBox, NoteBox };
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
                this.modify = new ButtonModifyForm(this, main, databaseName, "CredentialBankAccount");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.credentialBankAccount[i] = information[i];
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

        private void BankNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (BankNameBox.Text == "Bank Name")
            {
                BankNameBox.Text = "";
                BankNameBox.Foreground = Brushes.Black;
            }

            return;
        }


        private void AccountTypeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (AccountTypeBox.Text == "Account Type")
            {
                AccountTypeBox.Text = "";
                AccountTypeBox.Foreground = Brushes.Black;
            }

            return;
        }


        private void AccountNumberBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (AccountNumberBox.Text == "Account Number")
            {
                AccountNumberBox.Text = "";
                AccountNumberBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void PINBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (PINBox.Text == "PIN")
            {
                PINBox.Text = "";
                PINBox.Foreground = Brushes.Black;
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
                    this.submit.credentialBankAccount[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.credentialBankAccount[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.credentialBankAccount[1] = "Input Title Here";
                    }
                }
                
            }

            if (BankNameBox.Text == "")
            {
                BankNameBox.Text = "Bank Name";
                BankNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                
                if (this.purpose == "Add")
                {
                    this.submit.credentialBankAccount[2] = BankNameBox.Text;
                    if (BankNameBox.Text == "Bank Name")
                    {
                        this.submit.credentialBankAccount[2] = "";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[2] = BankNameBox.Text;
                    if (BankNameBox.Text == "Bank Name")
                    {
                        this.modify.credentialBankAccount[2] = "";
                    }
                }
                
            }

            if (AccountTypeBox.Text == "")
            {
                AccountTypeBox.Text = "Account Type";
                AccountTypeBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                
                if (this.purpose == "Add")
                {
                    this.submit.credentialBankAccount[3] = AccountTypeBox.Text;
                    if (AccountTypeBox.Text == "Account Type")
                    {
                        this.submit.credentialBankAccount[3] = "";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[3] = AccountTypeBox.Text;
                    if (AccountTypeBox.Text == "Account Type")
                    {
                        this.modify.credentialBankAccount[3] = "";
                    }
                }
                
            }

            if (AccountNumberBox.Text == "")
            {
                AccountNumberBox.Text = "Account Number";
                AccountNumberBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
            
                if (this.purpose == "Add")
                {
                    this.submit.credentialBankAccount[4] = AccountNumberBox.Text;
                    if (AccountNumberBox.Text == "Account Number")
                    {
                        this.submit.credentialBankAccount[4] = "";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[4] = AccountNumberBox.Text;
                    if (AccountNumberBox.Text == "Account Number")
                    {
                        this.modify.credentialBankAccount[4] = "";
                    }
                }
                
            }

            if (PINBox.Text == "")
            {
                PINBox.Text = "PIN";
                PINBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                
                if (this.purpose == "Add")
                {
                    this.submit.credentialBankAccount[5] = PINBox.Text;
                    if (PINBox.Text == "PIN")
                    {
                        this.submit.credentialBankAccount[5] = "";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[5] = PINBox.Text;
                    if (PINBox.Text == "PIN")
                    {
                        this.modify.credentialBankAccount[5] = "";
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
                    this.submit.credentialBankAccount[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.credentialBankAccount[6] = "";
                    }
                }
                else
                {
                    this.modify.credentialBankAccount[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.credentialBankAccount[6] = "";
                    }
                }
                
            }
            return;
        }
    }
}
