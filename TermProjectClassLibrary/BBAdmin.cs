using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    [Serializable]
    public class BBAdmin
    {
        public int ID { get; set; } 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public BBAdmin() { }
        public BBAdmin(string firstname, string lastname, string username, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Username = username;
            this.Password = password;
        }
    }
}
