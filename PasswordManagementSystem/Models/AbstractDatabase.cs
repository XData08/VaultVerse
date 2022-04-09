    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PasswordManagementSystem.Models
{
    public abstract class AbstractDatabase 
    {
        private protected string connection;
        private protected MySqlConnection conn;
        private protected MySqlDataReader rdr;
        private protected MySqlCommand cmd;

        public abstract void EstablishedConnection(string database);
    }
}
