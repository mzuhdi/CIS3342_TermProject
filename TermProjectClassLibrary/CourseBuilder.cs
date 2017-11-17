using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class CourseBuilder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int FK_DeptID { get; set; }

        public CourseBuilder() { }
        public CourseBuilder(string firstname, string lastname, string username, string password, int fk_DeptID)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Username = username;
            this.Password = password;
            this.FK_DeptID = fk_DeptID;
        }
    }
}
