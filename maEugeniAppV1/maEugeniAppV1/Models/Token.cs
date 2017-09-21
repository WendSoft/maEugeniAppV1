using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maEugeniAppV1.Models
{
    public class Token
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Access_token { get; set; }
        public string Error_description { get; set; }
        public DateTime Expire_date { get; set; }
        public int expires_in { get; set; }

        public Token() { }


    }
}
