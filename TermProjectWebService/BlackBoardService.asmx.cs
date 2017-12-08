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
