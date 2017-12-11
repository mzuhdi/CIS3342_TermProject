using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using TermProjectClassLibrary;
using System.Collections;

namespace TermProjectWebService
{
    /// <summary>
    /// Summary description for BlackBoardService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BlackBoardService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public void SendMail(Email theEmail)
        {
            theEmail.SendMail(theEmail.Recipient, theEmail.Sender, theEmail.Subject, theEmail.Message);
        }

        [WebMethod]
        public string[] verifyLogin(string username, string password)
        {
            string[] User = new string[2];

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_verifyUserForLogin";
            objCommand.Parameters.AddWithValue("@username", username);
            objCommand.Parameters.AddWithValue("@password", password);
            SqlParameter returnValue = new SqlParameter("@Result", 0);
            SqlParameter returnID = new SqlParameter("@ID", 0);

            returnValue.Direction = ParameterDirection.Output;
            returnID.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(returnValue);
            objCommand.Parameters.Add(returnID);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int result = int.Parse(objCommand.Parameters["@Result"].Value.ToString());
            int id = int.Parse(objCommand.Parameters["@ID"].Value.ToString());

            User[0] = result.ToString();
            User[1] = id.ToString();

            return User;
        }
        [WebMethod]
        public DataSet addNameFromCourseID(string courseID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_addNameFromCourseID";

            objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        [WebMethod]
        public bool AddAssignmentSvc(string key, Assignment assignment)
        {
            if (assignment != null && key == "zuhdi" && assignment.FileData != null) //Assignment with Files
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAssignment";
                objCommand.Parameters.AddWithValue("@Name", assignment.Name);
                objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Description", assignment.Description);
                objCommand.Parameters.AddWithValue("@fileTitle", assignment.FileTitle);
                objCommand.Parameters.AddWithValue("@fileData", assignment.FileData);
                objCommand.Parameters.AddWithValue("@fileType", assignment.FileType);
                objCommand.Parameters.AddWithValue("@fileLength", assignment.FileLength);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                //lblUpload.Text = "file is uploaded";
                return true;
            }
            else if (assignment != null && key == "zuhdi") //Assignment without files
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAssignment";
                objCommand.Parameters.AddWithValue("@Name", assignment.Name);
                objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Description", assignment.Description);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool addStudent(Student student, string key)
        {
            if (student != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddStudent";
                objCommand.Parameters.AddWithValue("@FirstName", student.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", student.LastName);
                objCommand.Parameters.AddWithValue("@Major", student.Major);
                objCommand.Parameters.AddWithValue("@Username", student.Username);
                objCommand.Parameters.AddWithValue("@Password", student.Password);
                
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool addCourseBuilder(CourseBuilder cb, string key)
        {
            if (cb != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.Parameters.Clear();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddCourseBuilder";
                objCommand.Parameters.AddWithValue("@FirstName", cb.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", cb.LastName);
                objCommand.Parameters.AddWithValue("@Username", cb.Username);
                objCommand.Parameters.AddWithValue("@Password", cb.Password);
                objCommand.Parameters.AddWithValue("@FK_DeptID", cb.FK_DeptID);
                SqlParameter returnValue = new SqlParameter("@Result", 0);
                //DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                returnValue.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(returnValue);

                objDB.GetDataSetUsingCmdObj(objCommand);

                int result = int.Parse(objCommand.Parameters["@Result"].Value.ToString());

                //return result;
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool addBBAdmin(BBAdmin admin, string key)
        {
            if (admin != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.Parameters.Clear();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddBBAdmin";
                objCommand.Parameters.AddWithValue("@FirstName", admin.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", admin.LastName);
                objCommand.Parameters.AddWithValue("@Username", admin.Username);
                objCommand.Parameters.AddWithValue("@Password", admin.Password);
                SqlParameter returnValue = new SqlParameter("@Result", 0);
                //    DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                //    objCommand.Parameters.Clear();
                //    return true;
                //}
                //return false;
                returnValue.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(returnValue);

                objDB.GetDataSetUsingCmdObj(objCommand);

                int result = int.Parse(objCommand.Parameters["@Result"].Value.ToString());

                //return result;
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public bool AddAnnoucementSvc(string key, Annoucement annoucement)
        {
            if (annoucement != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAnnoucement";
                objCommand.Parameters.AddWithValue("@Title", annoucement.Title);
                objCommand.Parameters.AddWithValue("@Description", annoucement.Description);
                objCommand.Parameters.AddWithValue("@Date", annoucement.Date);
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool UpdateAnnoucementSvc(string key, Annoucement annoucement)
        {
            if (annoucement != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateAnnoucement";
                objCommand.Parameters.AddWithValue("@ID", annoucement.ID);
                objCommand.Parameters.AddWithValue("@Title", annoucement.Title);
                objCommand.Parameters.AddWithValue("@Description", annoucement.Description);
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Date", annoucement.Date);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool addBBAdmin2(byte[] array, string key)
        {
            if (array != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.Parameters.Clear();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddBBAdmin2";
                objCommand.Parameters.AddWithValue("@theAdmin", array);
                SqlParameter returnValue = new SqlParameter("@Result", 0);
                //    DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                //    objCommand.Parameters.Clear();
                //    return true;
                //}
                //return false;
                returnValue.Direction = ParameterDirection.Output;
                objCommand.Parameters.Add(returnValue);

                objDB.GetDataSetUsingCmdObj(objCommand);

                int result = int.Parse(objCommand.Parameters["@Result"].Value.ToString());

                //return result;
                if (result == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool addCourse(Course course, string key)
        {
            if (course != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddCourse";
                objCommand.Parameters.AddWithValue("@Name", course.Name);
                objCommand.Parameters.AddWithValue("@FK_TermID", course.FK_TermID);
                objCommand.Parameters.AddWithValue("@FK_CBID", course.FK_CBID);
                objCommand.Parameters.AddWithValue("@CourseCode", course.CourseCode);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool DeleteCourse(string course,string key)
        {
            if (course != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteCourse";
                objCommand.Parameters.AddWithValue("@courseID", Convert.ToInt32(course));

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public void EnrollCourse(string key)
        {
            
        }

        [WebMethod]
        public void EmailCourse(string key)
        {
           
        }

        [WebMethod]
        public DataSet GetDepartment(string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetDepartment";

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        public DataTable GetAssignmentByCourseIDSvc(string key, Assignment assignment)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssignmentByCourseID";
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public DataSet GetContentPages(string courseID, string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "GetContentPages";

                objCommand.Parameters.AddWithValue("@FK_CourseID", Convert.ToInt32(courseID));

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public DataSet GetTerm(string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetTerm";

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public DataSet GetAnnoucement(string key, Annoucement annoucement)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAnnoucementByCourseID";
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public DataSet GetContentPageDetails(string pageID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RetrieveContentPageDetails";

            objCommand.Parameters.AddWithValue("@ContentPageID", Convert.ToInt32(pageID));

            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            objCommand.Parameters.Clear();
            return myDataSet;
        }

        [WebMethod]
        public DataTable GetAssignmentByIDSvc(string key, Assignment assignment)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssignmentByID";
                objCommand.Parameters.AddWithValue("@ID", assignment.ID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public DataTable GetAssignmentSvc(string key, Assignment assignment)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssignmentByCourseID";
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public DataTable GetAdminByIDSvc(string key, BBAdmin admin)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAdminByID";
                objCommand.Parameters.AddWithValue("@ID", admin.ID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public DataSet findNameBycbID(string cbID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_findNameBycbID";

            objCommand.Parameters.AddWithValue("@cbID", Convert.ToInt32(cbID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }
        [WebMethod]
        public DataSet populateClases(string cbID)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RetrieveCBClasses";

            objCommand.Parameters.AddWithValue("@cbID", Convert.ToInt32(cbID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        [WebMethod]
        public DataSet WebGetCourseBuilder(string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCourseBuilder";

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public DataSet GetUserType(string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetUserType";

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public DataSet GetCourseByTerm(string fk_termid, string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCourseByTerm";
                objCommand.Parameters.AddWithValue("@FK_TermID", fk_termid);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public DataSet GetCourseByCBID(int fk_CBID, string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCourseByCBID";
                objCommand.Parameters.AddWithValue("@FK_CBID", fk_CBID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        [WebMethod]
        public bool UpdateCourse(Course course, string key)
        {
            if (course != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateCourse";
                objCommand.Parameters.AddWithValue("@courseID", course.CourseID);
                objCommand.Parameters.AddWithValue("@Name", course.Name);
                objCommand.Parameters.AddWithValue("@FK_TermID", course.FK_TermID);
                objCommand.Parameters.AddWithValue("@FK_CBID", course.FK_CBID);
                objCommand.Parameters.AddWithValue("@CourseCode", course.CourseCode);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public DataSet populateStudentsInCourse(string key, string courseID)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Parameters.Clear();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_PopulateStudentsInCourse";
                objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));
                //objCommand.Parameters.AddWithValue("@CourseID", courseID);
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        [WebMethod]
        public void addStudentsToCourse(ArrayList arrStudents, string courseID)
        {

            foreach (string stdID in arrStudents)
            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddStudentsToCourse";

                objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(stdID));
                objCommand.Parameters.AddWithValue("@CourseID", courseID);//Convert.ToInt32(Session["CourseID"]));

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
            }
        }
    }
}
