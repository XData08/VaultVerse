using System;
using System.Collections.Generic;
using System.IO;
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
using PasswordManagementSystem.TemplateDocument;
using PasswordManagementSystem.TemplateRecord;
using PasswordManagementSystem.TemplateGallery;
using PasswordManagementSystem.Models;
using MySql.Data.MySqlClient;

namespace PasswordManagementSystem.Views.MainView
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        private string Section;
        private string databaseName;
        private MainWindow main;

        private protected string connection;
        private protected MySqlConnection conn;
        private protected MySqlDataReader rdr;
        private protected MySqlCommand cmd;

        public Item(MainWindow main, long key, string currtitle, string currdate, string database, string section)
        {
            InitializeComponent();
            DisplayText(key, currtitle, currdate);
            this.Section = section;
            this.databaseName = database;
            this.main = main;

            return;
        }

        public void EstablishedConnection(string database)
        {
            DataCryptography cypher = new DataCryptography();

            string filePath = @"E:\Code_Codes\C#\GUI\PasswordManagementSystem\PasswordManagementSystem\Models\Connection.txt";
            string[] fileLine = File.ReadAllLines(filePath);

            long key = Convert.ToInt64(fileLine[0]);

            this.connection = $"server={cypher.Decrypt(fileLine[1], key)};" +
                              $"port={cypher.Decrypt(fileLine[2], key)};" +
                              $"user={cypher.Decrypt(fileLine[3], key)};" +
                              $"password={cypher.Decrypt(fileLine[4], key)};" +
                              $"database={database};";
            this.conn = new MySqlConnection(this.connection);
            this.cmd = new MySqlCommand();
        }

        private void DisplayText(long key, string currtitle, string currdate)
        {
            DataCryptography cypher = new DataCryptography();
            TitleHere.Text = cypher.Decrypt(currtitle, key);

            string date = "";
            foreach (char x in currdate)
            {
                if (char.IsWhiteSpace(x))
                {
                    break;
                } date += x;
            }
            DateHere.Text = date;
            return;
        }

        private void DirectPage(object sender, RoutedEventArgs e)
        {
            EstablishedConnection(this.databaseName);
            string command = "";
            string[] information;
            string[] table;
            int size = 0;

            if (this.Section == "Credential")
            {
                table = new string[5]
                {
                    "credential_account", "credential_address", "credential_bank_account",
                    "credential_payment_card", "credential_drivers_license"
                };
            } 
            else if (this.Section == "Record")
            {
                table = new string[4]
                {
                    "record_lecture" , "record_collaboration",
                    "record_to_do_list", "record_schedule"
                };
            } 
            else if (this.Section == "Gallery")
            {
                table = new string[2]{ "gallery_image", "gallery_video" };
            } 
            else
            {
                table = new string[3] { "document_zip", "document_file", "document_folder" };
            }

            for (int i = 0; i < table.Length; i++)
            {
                if (this.Section == "Credential")
                {
                    switch (i)
                    {
                        case 0: case 2: case 3: size = 8; break;
                        case 1: size = 10; break;
                        case 4: size = 13; break;
                    }
                } 
                else if (this.Section == "Record")
                {
                    switch (i)
                    {
                        case 0: size = 6; break;
                        case 1: size = 5; break;
                        case 2: size = 4; break;
                        case 3: size = 11; break;
                    }
                }
                else
                {
                    size = 4;   
                }
                information = new string[size];

                try
                {
                    this.conn.Open();
                    command = $"SELECT * FROM {table[i]};";

                    this.cmd.Connection = this.conn;
                    this.cmd.CommandText = command;
                    this.rdr = this.cmd.ExecuteReader();
                    while (this.rdr.Read())
                    {
                        for (int j = 0; j < size; j++)
                        {
                            information[j] = this.rdr[j].ToString();
                        }

                        DataCryptography cypher = new DataCryptography();
                        long key = Convert.ToInt64(information[0]);
                        for (int j = 1; j < (information.Length - 1); j++)
                        {
                            information[j] = cypher.Decrypt(information[j], key);
                        }

                        if (TitleHere.Text == information[1])
                        {
                            if (table[i] == "credential_account")
                            {
                                TemplateAccount template = new TemplateAccount(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "credential_address")
                            {
                                TemplateAddress template = new TemplateAddress(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "credential_bank_account")
                            {
                                TemplateBankAccount template = new TemplateBankAccount(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "credential_payment_card")
                            {
                                TemplatePaymentCard tmeplate = new TemplatePaymentCard(main, databaseName, "Modify", information);
                                tmeplate.Show();
                            }
                            else if (table[i] == "credential_drivers_license")
                            {
                                TemplateLicense template = new TemplateLicense(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "record_lecture")
                            {
                                TemplateLecture template = new TemplateLecture(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "record_collaboration")
                            {
                                TemplateCollaboration template = new TemplateCollaboration(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "record_to_do_list")
                            {
                                TemplateList template = new TemplateList(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "record_schedule")
                            {
                                TemplateSchedule template = new TemplateSchedule(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "gallery_image")
                            {

                                TemplateImages template = new TemplateImages(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "gallery_video")
                            {
                                TemplateVideo template = new TemplateVideo(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "document_zip")
                            {
                                TemplateZip template = new TemplateZip(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else if (table[i] == "document_file")
                            {
                                TemplateFile template = new TemplateFile(main, databaseName, "Modify", information);
                                template.Show();
                            }
                            else
                            {
                                TemplateFolder template = new TemplateFolder(main, databaseName, "Modify", information);
                                template.Show();
                            }

                            this.main.WindowState = WindowState.Minimized;
                            break;
                        }
                        
                    }
                    this.rdr.Close();

                    
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
    }
}
