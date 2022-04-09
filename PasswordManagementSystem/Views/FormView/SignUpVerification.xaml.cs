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
using PasswordManagementSystem.Models;


namespace PasswordManagementSystem.Views.FormView
{
    /// <summary>
    /// Interaction logic for SignUpVerification.xaml
    /// </summary>
    public partial class SignUpVerification : UserControl
    {
        public string PrivateCode;

        public SignUpVerification()
        {
            this.PrivateCode = "";
            InitializeComponent();
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
            if (TextBoxPinCode.Text == "" || TextBoxPinCode.Text == "Invalid Code")
            {
                TextBoxPinCode.Text = "PIN Code";
                TextBoxPinCode.Foreground = (Brush)br.ConvertFrom("#707070");
            } 
            return;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (TextBoxPinCode.Text != this.PrivateCode)
            {
                TextBoxPinCode.Text = "Invalid Code";
                TextBoxPinCode.Foreground = Brushes.Red;
            } 
            else
            {
                string[] information = new string[4];
                DatabaseAdmin adminConnection = new DatabaseAdmin("vaultverse_schema");
                adminConnection.getNonVerifiedUser(information);
                adminConnection.updateVerifiedUsers();

                DatabaseUser userConnection = new DatabaseUser();
                string databaseName = userConnection.createNewUser(information);

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
