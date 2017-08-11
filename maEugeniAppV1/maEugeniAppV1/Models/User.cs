using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maEugeniAppV1.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string UserName, string Password)
        {
            this.Username = UserName;
            this.Password = Password;
        }

        public bool CheckUserInformation()
        {
            if (this.Username.Equals("") && this.Password.Equals(""))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
