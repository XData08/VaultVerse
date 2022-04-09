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
    /// Interaction logic for SubItem.xaml
    /// </summary>
    public partial class SubItem : UserControl
    {
        private string Section;
        private string databaseName;
        private MainWindow main;

        private protected string connection;
        private protected MySqlConnection conn;
        private protected MySqlDataReader rdr;
        private protected MySqlCommand cmd;

        public SubItem(MainWindow main, long key, string currtitle, string currdate, string database, string section)
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
                }
                date += x;
            }
            DateHere.Text = date;
            return;
        }

    }
}
