using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using PasswordManagementSystem.Models;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManagementSystem.Models
{
    public class DatabaseTemplate : AbstractDatabase
    {
        private string[] table;
        private int table_size;
        public DatabaseTemplate(string databaseName)
        {
            EstablishedConnection(databaseName);
            this.table_size = 0;
            return;
        }

        public override void EstablishedConnection(string database)
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
            return;
        }

        public void addData(string [] information, string table_name)
        {
            DataCryptography cypher = new DataCryptography(8);
            long key = cypher.GetPrivateKey();
            information[0] = Convert.ToString(key);

            for (int i=1; i< information.Length; i++)
            {
                information[i] = cypher.Encrypt(information[i], key);
            }

            string command = $"INSERT INTO {table_name} VALUES ( {information[0]},";
            try
            {
                this.conn.Open();
                for (int i = 1; i < information.Length; i++)
                {
                    command += $" '{information[i]}',";
                }
                command += "CURDATE());";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();
            } 
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }

        public void updateData(string toChange, string[] information, string table_name)
        {
            DataCryptography cypher = new DataCryptography();
            long key = Convert.ToInt64(information[0]);
            toChange = cypher.Encrypt(toChange, key);

            for (int i=1; i< information.Length; i++)
            {
                information[i] = cypher.Encrypt(information[i], key);
            }

            if (table_name == "credential_account")
            {
                this.table = new string[6]{
                    "title", "account_application_name", "account_username",
                    "account_email_address", "account_password", "account_notes"
                };
                this.table_size = 6;
            }
            else if (table_name == "credential_address")
            {
                this.table = new string[8] { "title", "address_first_name"
                , "address_middle_name", "address_last_name", "address_phone_no",
                "address_email_address", "address_home_address", "address_notes"};
                this.table_size = 8;
            }
            else if (table_name == "credential_bank_account")
            {
                this.table = new string[6] { "title", "bank_account_name",
                "bank_account_account_type", "bank_account_account_number"
                , "bank_account_pin", "bank_account_notes"};
                this.table_size = 6;
            }
            else if (table_name == "credential_drivers_license")
            {
                this.table = new string[11] { "title", "drivers_license_first_name",
                "drivers_license_middle_name", "drivers_license_last_name",
                "drivers_license_nationality", "drivers_license_gender",
                "drivers_license_date_of_birth", "drivers_license_home_address",
                "drivers_license_expiration_date", "drivers_license_license_no",
                "drivers_notes"};
                this.table_size = 11;
            }
            else if (table_name == "credential_payment_card")
            {
                this.table = new string[6] { "title", "payment_card_cardholder_name" 
                , "payment_card_cardholder_account_no", "payment_card_cardholder_expiration_date",
                "payment_card_security_code", "payment_card_notes"};
                this.table_size = 6;
            }
            else if (table_name == "record_lecture")
            {
                this.table = new string[4] { "title", "lecture_subject",
                "lecture_lesson", "lecture_notes" };
                this.table_size = 4;
            }
            else if (table_name == "record_to_do_list")
            {
                this.table = new string[2] { "title", "to_do_list_notes" };
                this.table_size = 2;
            }
            else if (table_name == "record_schedule")
            {
                this.table = new string[9] { "title", "schedule_monday_schedule",
                    "schedule_tuesday_schedule", "schedule_wednesday_schedule",
                    "schedule_thursday_schedule", "schedule_friday_schedule",
                    "schedule_saturday_schedule", "schedule_sunday_schedule",
                    "schedule_notes"
                };
                this.table_size = 9;
            }
            else if (table_name == "record_collaboration")
            {
                this.table = new string[3] { "title", "collaboration_subject"
                , "collaboration_notes"};
                this.table_size = 3;
            }
            else if (table_name == "gallery_image")
            {
                this.table = new string[2] { "title", "image_notes" };
                this.table_size = 2;
            }
            else if (table_name == "gallery_video")
            {
                this.table = new string[2] { "title", "video_notes" };
                this.table_size = 2;
            }
            else if (table_name == "document_zip")
            {
                this.table = new string[2] { "title", "zip_notes" };
                this.table_size = 2;
            }
            else if (table_name == "document_file")
            {
                this.table = new string[2] { "title", "file_notes" };
                this.table_size = 2;
            }
            else if (table_name == "document_folder")
            {
                table = new string[2] { "title", "folder_notes" };
                this.table_size = 2;
            }
            else
            {
                Console.WriteLine("Error");
            }

            string command = $"UPDATE {table_name} SET ";
            for (int i=0; i< this.table_size; i++){
                command += $"{this.table[i]} = '{information[i+1]}' ";
                if (i != this.table_size - 1){
                    command += ",";
                }
            }
            command += $"WHERE title = '{toChange}';";
      
            try
            {
                this.conn.Open();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;

                this.cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }

        public void deleteData(string toChange, string [] information, string table_name)
        {
            DataCryptography cypher = new DataCryptography();
            long key = Convert.ToInt64(information[0]);

            for (int i=1; i< information.Length; i++)
            {
                information[i] = cypher.Encrypt(information[i], key);
            }

            string command = $"DELETE FROM {table_name} WHERE title = '{information[1]}';";
            try
            {
                this.conn.Open();
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;

                this.cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }
        public void increment(string column)
        {
            string command = "";
            int number = 0;
            try
            {
                this.conn.Open();

                command = $"SELECT {column} FROM user_info;";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();
                while (this.rdr.Read())
                {
                    number = Convert.ToInt32(this.rdr[0].ToString());
                }
                this.rdr.Close();
                number++;

                command = $"UPDATE user_info SET {column} = {number};";
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();

            } 
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }

        public void decrement(string column)
        {
            string command = "";
            int number = 0;
            try
            {
                this.conn.Open();

                command = $"SELECT {column} FROM user_info;";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();
                while (this.rdr.Read())
                {
                    number = Convert.ToInt32(this.rdr[0].ToString());
                }
                this.rdr.Close();
                number--;

                command = $"UPDATE user_info SET {column} = {number};";
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();

            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }
    }
}
