using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Course
    {
        public string CourseID { get; set; }
        public string Name { get; set; }
        public string FK_TermID { get; set; }
        public int FK_CBID { get; set; }

        public Course() { }

        public Course (string courseid, string name, string fk_termid, int fk_cbid)
        {
            this.CourseID = courseid;
            this.Name = name;
            this.FK_TermID = fk_termid;
            this.FK_CBID = fk_cbid;
        }
    }
}
