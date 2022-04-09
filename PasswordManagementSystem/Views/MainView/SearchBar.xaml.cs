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
using PasswordManagementSystem.Views.MainView;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for SearchBar.xaml
    /// </summary>
    public partial class SearchBar : UserControl
    {
        public MainWindow main;
        public string menu;

        public MainCredentialView credential;
        public MainDocumentView document;
        public MainRecordView record;
        public MainGalleryView gallery;

        public SearchBar()
        {
            InitializeComponent();
        }

        private void MySearchBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (MySearchBar.Text == "Search")
            {
                MySearchBar.Text = "";
                MySearchBar.Foreground = Brushes.Black;
            }
            return;
        }

        private void Reset_KeyUp(object sender, KeyEventArgs e)
        {
            var br = new BrushConverter();
            if (MySearchBar.Text == "")
            {
                MySearchBar.Text = "Search";
                MySearchBar.Foreground = (Brush)br.ConvertFrom("#707070");
                this.main.ReloadAllListView();
            } else
            {
                if (this.menu == "Credential")
                {
                    this.credential.SearchTitle(MySearchBar.Text);
                }
                else if (this.menu == "Record")
                {
                    this.record.SearchTitle(MySearchBar.Text);
                }
                else if (this.menu == "Gallery")
                {
                    this.gallery.SearchTitle(MySearchBar.Text);
                }
                else
                {
                    this.document.SearchTitle(MySearchBar.Text);
                }
            }
            return;
        }

        private void RefreshButton(object sender, RoutedEventArgs e)
        {
            this.main.ReloadAllListView();
            return;
        }

        private void DarkModeButton(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
