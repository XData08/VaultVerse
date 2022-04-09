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
using PasswordManagementSystem.TemplateGallery;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for SubGalleryView.xaml
    /// </summary>
    public partial class SubGalleryView : UserControl
    {
        public MainWindow main;
        public string DatabaseName;
        public SubGalleryView()
        {
            InitializeComponent();
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            TemplateImages image = new TemplateImages(this.main, this.DatabaseName, "Add", null);

            image.Show();
            this.main.WindowState = WindowState.Minimized;

        }

        private void AddVideo(object sender, RoutedEventArgs e)
        {
            TemplateVideo video = new TemplateVideo(this.main, this.DatabaseName, "Add", null);

            video.Show();
            this.main.WindowState = WindowState.Minimized;

        }
    }
}
