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
using PasswordManagementSystem.TemplateDocument;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for SubDocumentView.xaml
    /// </summary>
    public partial class SubDocumentView : UserControl
    {
        public string DatabaseName;
        public MainWindow main;
        public SubDocumentView()
        {
            InitializeComponent();
        }

        private void AddZip(object sender, RoutedEventArgs e)
        {
            
            TemplateZip zip = new TemplateZip(this.main, this.DatabaseName, "Add", null);

            zip.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddFile(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            TemplateFile file = new TemplateFile(this.main, this.DatabaseName, "Add", null);

            file.Show();
            myWindow.WindowState = WindowState.Minimized;

        }

        private void AddFolder(object sender, RoutedEventArgs e)
        {
            var myWindow = Window.GetWindow(this);
            TemplateFolder folder = new TemplateFolder(this.main, this.DatabaseName, "Add", null);

            folder.Show();
            this.main.WindowState = WindowState.Minimized;

        }
    }
}
