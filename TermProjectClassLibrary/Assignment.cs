using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Assignment
    {
        public string Name { get; set; }
        public DateTime DueDate { get; set; }
        public int MaximumGrade { get; set; }
        public int FK_CourseID { get; set; }
        public string Description { get; set; }

        public Assignment() { }
        public Assignment(string name, DateTime duedate, int maximumgrade, int fk_courseid, string description)
        {
            this.Name = name;
            this.DueDate = duedate;
            this.MaximumGrade = maximumgrade;
            this.FK_CourseID = fk_courseid;
            this.Description = description;
        }
    }
}
