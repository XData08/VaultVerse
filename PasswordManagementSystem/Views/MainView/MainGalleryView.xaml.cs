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

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for MainGalleryView.xaml
    /// </summary>
    public partial class MainGalleryView : UserControl
    {
        public string DatabaseName;
        public MainWindow main;

        private MySqlConnection conn;
        private MySqlCommand cmd;
        private MySqlDataReader rdr;
        private string connection;

        public MainGalleryView()
        {
            InitializeComponent();
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

        public void LoadList(string title_name = null)
        {
            EstablishedConnection();
            string[] tables = { "gallery_image", "gallery_video" };

            ToDisplay.Children.Clear();
            for (int i = 0; i < tables.Length; i++)
            {
                try
                {
                    this.conn.Open();
                    this.cmd.Connection = this.conn;
                    string command = "";

                    if (title_name != null)
                    {
                        command = $"SELECT private_key FROM {tables[i]};";
                        this.cmd.CommandText = command;
                        this.rdr = this.cmd.ExecuteReader();

                        while (this.rdr.Read())
                        {
                            DataCryptography cypher = new DataCryptography();
                            long key = Convert.ToInt64(rdr[0].ToString());
                            string copy = cypher.Encrypt(title_name, key);

                            string newCommand = $"SELECT private_key, title, date_added FROM {tables[i]} WHERE title LIKE '{copy}%';";
                            DisplaySearch(newCommand);
                        }
                        this.rdr.Close();
                    }
                    else
                    {
                        command = $"SELECT private_key, title, date_added FROM {tables[i]};";
                        this.cmd.CommandText = command;
                        this.rdr = this.cmd.ExecuteReader();
                        while (this.rdr.Read())
                        {
                            long key = Convert.ToInt64(rdr[0].ToString());
                            Item item = new Item(this.main, key, rdr[1].ToString(), rdr[2].ToString(), this.DatabaseName, "Gallery");
                            ToDisplay.Children.Add(item);
                        }
                        this.rdr.Close();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                }
                finally
                {
                    this.conn.Close();
                }
            }
            return;

        }

        public void SearchTitle(string title)
        {
            LoadList(title);
            return;
        }

        private void DisplaySearch(string command)
        {
            MySqlConnection myConn = new MySqlConnection(this.connection);
            MySqlCommand myCom = new MySqlCommand();
            MySqlDataReader myReader;

            try
            {
                myConn.Open();
                myCom.Connection = myConn;
                myCom.CommandText = command;
                myReader = myCom.ExecuteReader();
                while (myReader.Read())
                {
                    long key = Convert.ToInt64(myReader[0].ToString());
                    Item item = new Item(this.main, key, myReader[1].ToString(), myReader[2].ToString(), this.DatabaseName, "Gallery");
                    ToDisplay.Children.Add(item);
                }
                myReader.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            finally
            {
                myConn.Close();
            }
            return;
        }
    }
}
