using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Annoucement
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int FK_CourseID { get; set; }

        public Annoucement() { }
        public Annoucement(int id, string title, string description, DateTime date, int fk_courseid)
        {
            this.ID = id; 
            this.Title = title;
            this.Description = description;
            this.Date = date;
            this.FK_CourseID = fk_courseid;
        }
    }
}
