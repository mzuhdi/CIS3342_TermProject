using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Grade
    {
        public int ID { get; set; }
        public int FK_StudentID { get; set; }
        public int FK_AssignmentID { get; set; }
        public int theGrade { get; set; }
        public string FileTitle { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public long FileLength { get; set; }

        public Grade() { }
        public Grade (int id, int fk_studentid, int fk_assignmentid, int thegrade, string filetitle,
            string filetype, byte[] filedata, long filelength)
        {
            this.ID = id;
            this.FK_StudentID = fk_studentid;
            this.FK_AssignmentID = fk_assignmentid;
            this.theGrade = thegrade;
            this.FileTitle = filetitle;
            this.FileType = filetype;
            this.FileData = filedata;
            this.FileLength = filelength;
        }


    }
}
