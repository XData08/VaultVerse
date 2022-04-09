using System;
using System.IO;
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
using MySql.Data.MySqlClient;
using PasswordManagementSystem.Models;
using PasswordManagementSystem.Views.MainView;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for MainHomeView.xaml
    /// </summary>

    public partial class MainHomeView : UserControl
    {
        public MainWindow main;

        private int credential_click;
        private int record_click;
        private int document_click;
        private int gallery_click;


        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;
        private string connection;
        public string DatabaseName;


        public MainHomeView()
        {
            InitializeComponent();
            this.credential_click = 0;
            this.record_click = 0;
            this.gallery_click = 0;
            this.document_click = 0;
            return;
        }

        private void EstablishedConnection()
        {
            DataCryptography cypher = new DataCryptography();

            string filePath = @"E:\Code_Codes\C#\GUI\PasswordManagementSystem\PasswordManagementSystem\Models\Connection.txt";
            string[] fileLine = File.ReadAllLines(filePath);

            long key = Convert.ToInt64(fileLine[0]);

            this.connection = $"server={cypher.Decrypt(fileLine[1], key)};" +
                              $"port={cypher.Decrypt(fileLine[2], key)};" +
                              $"user={cypher.Decrypt(fileLine[3], key)};" +
                              $"password={cypher.Decrypt(fileLine[4], key)};" +
                              $"database={this.DatabaseName};";
            this.conn = new MySqlConnection(this.connection);
            this.cmd = new MySqlCommand();
            return;
        }

        private void IconChange(Border mainBtn, Image mainIcon, string name)
        {
            var br = new BrushConverter();
            string[] defaultName = { "icon_rbcredential.png", "icon_rbrecord.png"
                                    , "icon_rbgallery.png", "icon_rbdocument.png"};
            Border[] buttons = { CredentialButton, RecordButton, GalleryButton, DocumentButton};
            Image[] image = { CredentialIcon, RecordIcon, GalleryIcon, DocumentIcon };

            for (int i=0; i<buttons.Length; i++)
            {
                buttons[i].Background = Brushes.White;
                image[i].Source = new BitmapImage(new Uri(defaultName[i], UriKind.Relative));
            }

            mainBtn.Background = (Brush)br.ConvertFrom("#F05454");
            mainIcon.Source = new BitmapImage(new Uri(name, UriKind.Relative));
        }
        private void CredentialClick(object sender, RoutedEventArgs e)
        {
            IconChange(CredentialButton, CredentialIcon, "icon_wbcredential.png");
            this.credential_click++;
            if (credential_click == 2)
            {
                this.credential_click = 0;
                this.main.ChangeViewCredential();
     
            }
            this.document_click = 0;
            this.record_click = 0;
            this.gallery_click = 0;
            return;
        }

        private void RecordClick(object sender, RoutedEventArgs e)
        {
            IconChange(RecordButton, RecordIcon, "icon_wbrecord.png");
            this.record_click++;
            if (record_click == 2)
            {
                this.record_click = 0;
                this.main.ChangeViewRecord();
            }
            this.credential_click = 0;
            this.document_click = 0;
            this.gallery_click = 0;
            return;
        }

        private void GalleryClick(object sender, RoutedEventArgs e)
        {
            IconChange(GalleryButton, GalleryIcon, "icon_wbgallery.png");
            this.gallery_click++;
            if (gallery_click== 2)
            {
                this.gallery_click = 0;
                this.main.ChangeViewGallery();
            }
            this.credential_click = 0;
            this.record_click = 0;
            this.document_click = 0;
            return;
        }

        private void DocumentClick(object sender, RoutedEventArgs e)
        {
            IconChange(DocumentButton, DocumentIcon, "icon_wbdocument.png");
            this.document_click++;
            if (document_click == 2)
            {
                this.document_click = 0;
                this.main.ChangeViewGallery();
            }
            this.credential_click = 0;
            this.record_click = 0;
            this.gallery_click = 0;
            return;
        }

        
        public void ReloadListView()
        {
            EstablishedConnection();
            ToDisplay.Children.Clear();

            string[] table1 = {"credential_account" ,  "credential_address", "credential_bank_account"
            , "credential_drivers_license", "credential_payment_card" };
            
            string[] table2 = {"record_lecture" ,  "record_schedule", "record_collaboration"
            , "record_to_do_list" };

            string[] table3 = { "gallery_image", "gallery_video" };

            string[] table4 = { "document_zip", "document_file", "document_folder" };

            LoadListView(table1, "Credential");
            LoadListView(table2, "Record");
            LoadListView(table3, "Gallery");
            LoadListView(table4, "Document");

            return;
        }

        private void LoadListView(string [] tables, string name)
        {
            for (int i = 0; i < tables.Length; i++)
            {
                try
                {
                    this.conn.Open();
                    string command = $"SELECT private_key, title, date_added FROM {tables[i]};";

                    this.cmd.Connection = this.conn;
                    this.cmd.CommandText = command;
                    this.rdr = this.cmd.ExecuteReader();

                    while (this.rdr.Read())
                    {
                        
                        long key = Convert.ToInt64(rdr[0].ToString());
                        SubItem item = new SubItem(this.main, key, rdr[1].ToString(), rdr[2].ToString(), this.DatabaseName, name);
                        
                        ToDisplay.Children.Add(item);
                    }
                    this.rdr.Close();

                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    this.conn.Close();
                }
            }
        }
    }
}
