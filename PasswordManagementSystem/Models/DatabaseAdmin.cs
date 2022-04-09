using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySql.Data.MySqlClient;

namespace PasswordManagementSystem.Models
{
    public class DatabaseAdmin : AbstractDatabase
    {
        
        public DatabaseAdmin(string database)
        { 
            EstablishedConnection(database);
            return;
        }

        public override void EstablishedConnection( string database )
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

        public bool isEmailExist(string email)
        {
            bool isExist = false;
            string command = "";

            try
            {
                this.conn.Open();
                
                command = $"SELECT COUNT(USER_EMAIL) FROM users WHERE USER_EMAIL = '{email}';";

                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();

                while (this.rdr.Read())
                {
                    isExist = (this.rdr[0].ToString() == "0") ? false : true;
                }
                this.rdr.Close();       
            }
            catch (Exception err)
            {
                Console.WriteLine("= DatabaseAdmin.cs [Line 68] =");
                Console.WriteLine(err.Message);
                Console.WriteLine("==============================\n");
                return false;
            }
            finally
            {
                this.conn.Close();
            }
            return isExist;
        }

        public bool addNewUser(string [] information)
        {
            string command = "INSERT INTO users VALUES (";
            try
            {
                this.conn.Open();

                for (int i=0; i<4; i++)
                {
                    command += information[i];
                    if (!((i+1) == 4))
                    {
                        command += ",";
                    }
                }
                command += ");";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();

            } 
            catch (Exception err)
            {
                Console.WriteLine("= DatabaseAdmin.cs [Line 103] =");
                Console.WriteLine(err.Message);
                Console.WriteLine("===============================\n");
                return false;
            }
            finally
            {
                this.conn.Close();
            }
            return true;
        }

        public void deleteNonVerifiedUsers()
        {
            string command = "";
            string[] nonVerified = new string[3];

            try
            {
                this.conn.Open();

                command = "SELECT user_email FROM users WHERE user_verification = 0;";

                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();

                for (int i=0;  this.rdr.Read(); i++)
                {
                    nonVerified[i] = this.rdr[0].ToString();
                }
                this.rdr.Close();

                foreach (string user in nonVerified)
                {
                    command = $"DELETE FROM users WHERE user_email = '{user}';";
                    this.cmd.CommandText = command;
                    this.cmd.ExecuteNonQuery();
                }

            } catch (Exception err)
            {
                Console.WriteLine("= DatabaseAdmin.cs [Line 145] =");
                Console.WriteLine(err.Message);
                Console.WriteLine("===============================\n");
            }
            finally
            {
                this.conn.Close();
            }
            return;
        }

        public void updateVerifiedUsers(){
            string command = "";
            try
            {
                this.conn.Open();

                command = "UPDATE users SET USER_VERIFICATION = 1 WHERE USER_VERIFICATION = 0;";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.cmd.ExecuteNonQuery();

            } catch (Exception err)
            {
                Console.WriteLine("= DatabaseAdmin.cs [Line 169] =");
                Console.WriteLine(err.Message);
                Console.WriteLine("===============================\n");
            } finally
            {
                this.conn.Close();
            }
            return;
        }

        public void getNonVerifiedUser(string [] information){
            string command = "";

            try {
                this.conn.Open();
                
                command = "SELECT * FROM users WHERE USER_VERIFICATION = 0;";
                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();

                this.rdr.Read();
                for (int i=0; i<4; i++){
                    information[i] = this.rdr[i].ToString();
                }
                this.rdr.Close();

            } catch (Exception err){
                Console.WriteLine("= DatabaseAdmin.cs [Line 179] =");
                Console.WriteLine(err.Message);
                Console.WriteLine("===============================\n");
            } finally {
                this.conn.Close();
            }
            return;
        }   

        public void getVerifiedUser(string [] information, string email)
        {
            string command = "";
            try
            {
                this.conn.Open();

                command = $"SELECT * FROM users WHERE USER_EMAIL = '{email}';";

                this.cmd.Connection = this.conn;
                this.cmd.CommandText = command;
                this.rdr = this.cmd.ExecuteReader();

                this.rdr.Read();
                for (int i = 0; i<4; i++)
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

        public void updateUserInformation(string[] information, string email)
        {
            string command = "";
            try
            {
                this.conn.Open();

                command = $"UPDATE users SET USER_PASSWORD = '{information[3]}' WHERE USER_EMAIL = '{email}';";
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
