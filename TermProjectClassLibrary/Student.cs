using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Major { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public Student() { }

        public Student (string firstname, string lastname, string major, string username, string password)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Major = major;
            this.Username = username;
            this.Password = password;
        }
    }
}
