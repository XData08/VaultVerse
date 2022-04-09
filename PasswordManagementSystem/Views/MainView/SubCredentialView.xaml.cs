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
using PasswordManagementSystem.TemplateCredential;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for SubCredentialView.xaml
    /// </summary>
    public partial class SubCredentialView : UserControl
    {
        public string DatabaseName;
        public MainWindow main;
        public SubCredentialView()
        {
            InitializeComponent();
        }

        private void AddAccount(object sender, RoutedEventArgs e)
        {
            TemplateAccount account = new TemplateAccount(this.main, this.DatabaseName, "Add", null);

            account.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddPaymentCard(object sender, RoutedEventArgs e)
        {
            TemplatePaymentCard payment_card = new TemplatePaymentCard(this.main, this.DatabaseName, "Add", null);

            payment_card.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddBankAccount(object sender, RoutedEventArgs e)
        {
            TemplateBankAccount bank_account = new TemplateBankAccount(this.main, this.DatabaseName, "Add", null);

            bank_account.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddLicense(object sender, RoutedEventArgs e)
        {
            TemplateLicense license = new TemplateLicense(this.main, this.DatabaseName, "Add", null);

            license.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddAddress(object sender, RoutedEventArgs e)
        {
            TemplateAddress address = new TemplateAddress(this.main, this.DatabaseName, "Add", null);

            address.Show();
            this.main.WindowState = WindowState.Minimized;

        }


    }
}
