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
    /// Interaction logic for TemplatePaymentCard.xaml
    /// </summary>
    public partial class TemplatePaymentCard : Window
    {
        private MainWindow main;
        private string DatabaseName, purpose;

        private ButtonSubmitForm submit;
        private ButtonModifyForm modify;

        public TemplatePaymentCard(MainWindow main, string databaseName,string purpose, string[] information)
        {
            InitializeComponent();
            this.main = main;
            this.DatabaseName = databaseName;
            this.purpose = purpose;
            if (purpose == "Add")
            {
                submit = new ButtonSubmitForm(this, main, databaseName, "CredentialPaymentCard");
                ButtonArea.Children.Add(submit);
                Reset_KeyUp();
            }
            else
            {
                var br = new BrushConverter();

                TextBox[] boxes = { TitleBox, CardHolderNameBox, CardHolderAccountBox, CardHolderExpirationDateBox
                , CardHolderSecurityCodeBox, NoteBox};
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
                this.modify = new ButtonModifyForm(this, main, databaseName, "CredentialPaymentCard");
                this.modify.toChange = information[1];
                for (int i = 0; i < information.Length - 1; i++)
                {
                    this.modify.credentialPaymentCard[i] = information[i];
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

        private void CardHolderNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CardHolderNameBox.Text == "Cardholder Name")
            {
                CardHolderNameBox.Text = "";
                CardHolderNameBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void CardHolderAccountBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CardHolderAccountBox.Text == "Cardholder Account No.")
            {
                CardHolderAccountBox.Text = "";
                CardHolderAccountBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void CardHolderExpirationDateBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CardHolderExpirationDateBox.Text == "Cardholder Expiration Date")
            {
                CardHolderExpirationDateBox.Text = "";
                CardHolderExpirationDateBox.Foreground = Brushes.Black;
            }

            return;
        }

        private void CardHolderSecurityCodeBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (CardHolderSecurityCodeBox.Text == "Cardholder Security Code")
            {
                CardHolderSecurityCodeBox.Text = "";
                CardHolderSecurityCodeBox.Foreground = Brushes.Black;
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
                    this.submit.credentialPaymentCard[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.submit.credentialPaymentCard[1] = "Input Title Here";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[1] = TitleBox.Text;
                    if (TitleBox.Text == "Title")
                    {
                        this.modify.credentialPaymentCard[1] = "Input Title Here";
                    }
                }
            }

            if (CardHolderNameBox.Text == "")
            {
                CardHolderNameBox.Text = "Cardholder Name";
                CardHolderNameBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialPaymentCard[2] = CardHolderNameBox.Text;
                    if (CardHolderNameBox.Text == "Cardholder Name")
                    {
                        this.submit.credentialPaymentCard[2] = "";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[2] = CardHolderNameBox.Text;
                    if (CardHolderNameBox.Text == "Cardholder Name")
                    {
                        this.modify.credentialPaymentCard[2] = "";
                    }
                }
            }

            if (CardHolderAccountBox.Text == "")
            {
                CardHolderAccountBox.Text = "Cardholder Account No.";
                CardHolderAccountBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialPaymentCard[3] = CardHolderAccountBox.Text;
                    if (CardHolderAccountBox.Text == "Cardholder Account No.")
                    {
                        this.submit.credentialPaymentCard[3] = "";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[3] = CardHolderAccountBox.Text;
                    if (CardHolderAccountBox.Text == "Cardholder Account No.")
                    {
                        this.modify.credentialPaymentCard[3] = "";
                    }
                }
            }

            if (CardHolderExpirationDateBox.Text == "")
            {
                CardHolderExpirationDateBox.Text = "Cardholder Expiration Date";
                CardHolderExpirationDateBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialPaymentCard[4] = CardHolderExpirationDateBox.Text;
                    if (CardHolderExpirationDateBox.Text == "Cardholder Expiration Date")
                    {
                        this.submit.credentialPaymentCard[4] = "";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[4] = CardHolderExpirationDateBox.Text;
                    if (CardHolderExpirationDateBox.Text == "Cardholder Expiration Date")
                    {
                        this.modify.credentialPaymentCard[4] = "";
                    }
                }
            }

            if (CardHolderSecurityCodeBox.Text == "")
            {
                CardHolderSecurityCodeBox.Text = "Cardholder Security Code";
                CardHolderSecurityCodeBox.Foreground = (Brush)br.ConvertFrom("#ABABAB");
            }
            else
            {
                if (this.purpose == "Add")
                {
                    this.submit.credentialPaymentCard[5] = CardHolderSecurityCodeBox.Text;
                    if (CardHolderSecurityCodeBox.Text == "Cardholder Security Code")
                    {
                        this.submit.credentialPaymentCard[5] = "";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[5] = CardHolderSecurityCodeBox.Text;
                    if (CardHolderSecurityCodeBox.Text == "Cardholder Security Code")
                    {
                        this.modify.credentialPaymentCard[5] = "";
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
                    this.submit.credentialPaymentCard[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.submit.credentialPaymentCard[6] = "";
                    }
                }
                else
                {
                    this.modify.credentialPaymentCard[6] = NoteBox.Text;
                    if (NoteBox.Text == "Notes")
                    {
                        this.modify.credentialPaymentCard[6] = "";
                    }
                }
            }
            return;
        }
    }
}
