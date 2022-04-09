using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;

namespace PasswordManagementSystem.Models
{
    public class DatabaseUser : AbstractDatabase
    {
        public DatabaseUser(string database = "")
        {
            EstablishedConnection(database);
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
                              $"password={cypher.Decrypt(fileLine[4], key)};";
            if (database != "")
            {
                this.connection += $"database={database};";
            }
                              
            this.conn = new MySqlConnection(this.connection);
            this.cmd = new MySqlCommand();
            return;
        }

        public string createNewUser(string[] information)
        {

            DataCryptography cypher = new DataCryptography();
            Hash hash = new Hash();

            string databaseName = hash.Encrypt(information[1]);
            string command = "";

            try
            {
                this.conn.Open();
                command = $"CREATE DATABASE {databaseName};";

                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();
            } 
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            } finally
            {
                conn.Close();
            }

            EstablishedConnection(databaseName);
            try
            {
                this.conn.Open();

                string pathName = @"E:\Code_Codes\C#\GUI\PasswordManagementSystem\PasswordManagementSystem\Models\UserDatabase.txt";
                string[] fileLine = File.ReadAllLines(pathName);
                string line = "";

                foreach (string x in fileLine)
                {
                    if (x != "")
                    {
                        line += x;
                    }
                    else
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = line;
                        cmd.ExecuteNonQuery();
                        line = "";
                    }
                }

                command = "INSERT INTO user_info VALUES(" +
                          $"'{information[1]}', '{information[2]}', '{information[3]}'," +
                          $"{new Random().Next(8)}, 0,0,0,0);";
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
            return databaseName;
        }

        public void getUserInformation(string[] information)
        {
            string command = "";
            try
            {
                this.conn.Open();
                command = "SELECT * FROM user_info;";

                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;

                this.rdr = this.cmd.ExecuteReader();
                this.rdr.Read();
                for (int i=0; i<8; i++)
                {
                    information[i] = this.rdr[i].ToString();
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
            return;
        }

        public void updateUserInformation(string oldPassword, string newPassword)
        {
            string command = "";
            try
            {
                this.conn.Open();
                command = $"UPDATE user_info SET user_password = '{oldPassword}' WHERE user_password = '{newPassword}';";

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
    }
}
