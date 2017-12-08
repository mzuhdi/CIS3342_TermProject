using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TermProjectClassLibrary
{
    public class Assignment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string DueDate { get; set; }
        public int MaximumGrade { get; set; }
        public int FK_CourseID { get; set; }
        public string Description { get; set; }
        public string FileTitle { get; set; }
        public string FileType { get; set; }
        public byte[] FileData { get; set; }
        public long FileLength { get; set; }

        public Assignment() { }
        public Assignment(int id, string name, string duedate, int maximumgrade, int fk_courseid, string description,
                            string fileTitle, string fileType, byte[] fileData, long fileLength)
        {
            this.ID = id;
            this.Name = name;
            this.DueDate = duedate;
            this.MaximumGrade = maximumgrade;
            this.FK_CourseID = fk_courseid;
            this.Description = description;
            this.FileTitle = fileTitle;
            this.FileType = fileType;
            this.FileData = fileData;
            this.FileLength = fileLength;
        }
    }
}
