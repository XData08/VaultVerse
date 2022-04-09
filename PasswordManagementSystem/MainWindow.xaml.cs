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
using PasswordManagementSystem.Views.MainView;

namespace PasswordManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string DatabaseName;
        public MainWindow(string databaseName)
        {
            this.DatabaseName = databaseName;
            InitializeComponent();
            setUserProfile();
            SearchBarView.main = this;
            MainHomeView.main = this;
            
        }

        private void setUserProfile()
        {
            string [] information = new string[8];
          
            DatabaseUser user = new DatabaseUser(this.DatabaseName);
            user.getUserInformation(information);
   

            GreetUser.Content += information[0] + "👋";
            string firstName = "";
            foreach (char x in information[0])
            {
                if (!char.IsWhiteSpace(x))
                {
                    firstName += Convert.ToString(x);
                } else
                {
                    break;
                }
            }
            UserFirstName.Content = firstName;

            string imageProfile = "";
            switch (Convert.ToInt32(information[3]))
            {
                case 0:  imageProfile = "profile_0.png"; break;
                case 1:  imageProfile = "profile_1.png"; break;
                case 2:  imageProfile = "profile_2.png"; break;
                case 3:  imageProfile = "profile_3.png"; break;
                case 4:  imageProfile = "profile_4.png"; break;
                case 5:  imageProfile = "profile_5.png"; break;
                case 6:  imageProfile = "profile_6.png"; break;
                case 7:  imageProfile = "profile_7.png"; break;
            }
            UserProfile.Source = new BitmapImage(new Uri(imageProfile, UriKind.Relative));

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

        private void ChangeView(UserControl main, UserControl sub)
        {

            UserControl[] MainViews = { 
                MainHomeView, MainCredentialView , MainRecordView,
                MainGalleryView, MainDocumentView, MainHelpView
            };

            UserControl[] SubViews =
            {
                SubHomeView, SubCredentialView , SubRecordView,
                SubGalleryView, SubDocumentView, SubHelpView
            };
        
            for (int i=0; i<MainViews.Length; i++)
            {
                MainViews[i].Visibility = Visibility.Collapsed;
                SubViews[i].Visibility = Visibility.Collapsed;
            }
          
            main.Visibility = Visibility.Visible;
            sub.Visibility = Visibility.Visible;
            return;
        }

        private void ChangeButton(Button button, Label label, Image image, string icon)
        {
            var br = new BrushConverter();
            Button[] menuBtn = { ViewHomeButton, ViewCredentialButton, ViewRecordButton
                                , ViewGalleryButton, ViewDocumentButton, ViewHelpButton};
            Label[] menuLbl = { ViewHomeLabel, ViewCredentialLabel, ViewRecordLabel 
                                , ViewGalleryLabel, ViewDocumentLabel, ViewHelpLabel}; 

            for (int i = 0; i < menuBtn.Length; i++)
            {
                menuBtn[i].Background = Brushes.White;
                menuLbl[i].Foreground = (Brush)br.ConvertFrom("#121212");
            }

            ViewHomeImage.Source = new BitmapImage(new Uri("icon_home.png", UriKind.Relative));
            ViewCredentialImage.Source = new BitmapImage(new Uri("icon_credentials.png", UriKind.Relative));
            ViewRecordImage.Source = new BitmapImage(new Uri("icon_records.png", UriKind.Relative));
            ViewGalleryImage.Source = new BitmapImage(new Uri("icon_image.png", UriKind.Relative));
            ViewDocumentImage.Source = new BitmapImage(new Uri("icon_document.png", UriKind.Relative));
            ViewHelpImage.Source = new BitmapImage(new Uri("icon_help.png", UriKind.Relative));

            image.Source = new BitmapImage(new Uri(icon, UriKind.Relative));
            button.Background = (Brush)br.ConvertFrom("#F05454");
            label.Foreground = (Brush)br.ConvertFrom("#F5F5F5");
            
            return;
        }

        private void ChangeViewHome(object sender, RoutedEventArgs e)
        {
            ChangeButton(ViewHomeButton, ViewHomeLabel, ViewHomeImage, "icon_whome.png");
            ChangeView(MainHomeView, SubHomeView);
            MainHomeView.DatabaseName = this.DatabaseName;
            MainHomeView.main = this;
            MainHomeView.ReloadListView();

            return;
        }

        public void ChangeViewCredential(object sender = null, RoutedEventArgs e = null)
        {
            ChangeButton(ViewCredentialButton, ViewCredentialLabel, ViewCredentialImage, "icon_wcredential.png");
            ChangeView(MainCredentialView, SubCredentialView);
            MainCredentialView.DatabaseName = this.DatabaseName;
            MainCredentialView.main = this;
            SubCredentialView.DatabaseName = this.DatabaseName;
            SubCredentialView.main = this;
            MainCredentialView.LoadList();

            SearchBarView.menu = "Credential";
            SearchBarView.credential = MainCredentialView;
            return;
        }

        public void ChangeViewRecord(object sender = null, RoutedEventArgs e = null)
        {
            ChangeButton(ViewRecordButton, ViewRecordLabel, ViewRecordImage, "icon_wrecord.png");
            ChangeView(MainRecordView, SubRecordView);
            MainRecordView.DatabaseName = this.DatabaseName;
            MainRecordView.main = this;
            SubRecordView.DatabaseName = this.DatabaseName;
            SubRecordView.main = this;
            MainRecordView.LoadList();

            SearchBarView.menu = "Record";
            SearchBarView.record = MainRecordView;
            return;
        }

        public void ChangeViewGallery(object sender = null, RoutedEventArgs e = null)
        {
            ChangeButton(ViewGalleryButton, ViewGalleryLabel, ViewGalleryImage, "icon_wgallery.png");
            ChangeView(MainGalleryView, SubGalleryView);
            MainGalleryView.DatabaseName = this.DatabaseName;
            MainGalleryView.main = this;
            SubGalleryView.DatabaseName = this.DatabaseName;
            SubGalleryView.main = this;
            MainGalleryView.LoadList();

            SearchBarView.menu = "Gallery";
            SearchBarView.gallery = MainGalleryView;
            return;
        }

        public void ChangeViewDocument(object sender = null, RoutedEventArgs e = null)
        {
            ChangeButton(ViewDocumentButton, ViewDocumentLabel, ViewDocumentImage, "icon_wdocument.png");
            ChangeView(MainDocumentView, SubDocumentView);
            MainDocumentView.DatabaseName = this.DatabaseName;
            MainDocumentView.main = this;
            SubDocumentView.DatabaseName = this.DatabaseName;
            SubDocumentView.main = this;
            MainDocumentView.LoadList();

            SearchBarView.menu = "Document";
            SearchBarView.document = MainDocumentView;
            return;
        }

        private void ChangeViewHelp(object sender, RoutedEventArgs e)
        {
            ChangeButton(ViewHelpButton, ViewHelpLabel, ViewHelpImage, "icon_whelp.png");
            ChangeView(MainHelpView, SubHelpView);
            return;
        }

        private void UserMenu(object sender, RoutedEventArgs e)
        {
            UserMenu user = new UserMenu(this, this.DatabaseName);
            user.Show();
            this.WindowState = WindowState.Minimized;
            return;
        }

        public void ReloadAllListView()
        {
            MainRecordView.LoadList();
            MainCredentialView.LoadList();
            MainGalleryView.LoadList();
            MainDocumentView.LoadList();
            return;
        }
    }
}
