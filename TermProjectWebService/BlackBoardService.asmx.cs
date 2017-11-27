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

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddCourseBuilder";
                objCommand.Parameters.AddWithValue("@FirstName", cb.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", cb.LastName);
                objCommand.Parameters.AddWithValue("@Username", cb.Username);
                objCommand.Parameters.AddWithValue("@Password", cb.Password);
                objCommand.Parameters.AddWithValue("@FK_DeptID", cb.FK_DeptID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        [WebMethod]
        public bool addBBAdmin(BBAdmin admin, string key)
        {
            if (admin != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddBBAdmin";
                objCommand.Parameters.AddWithValue("@FirstName", admin.FirstName);
                objCommand.Parameters.AddWithValue("@LastName", admin.LastName);
                objCommand.Parameters.AddWithValue("@Username", admin.Username);
                objCommand.Parameters.AddWithValue("@Password", admin.Password);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
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
                objCommand.Parameters.AddWithValue("@courseID", course.CourseID);
                objCommand.Parameters.AddWithValue("@Name", course.Name);
                objCommand.Parameters.AddWithValue("@FK_TermID", course.FK_TermID);
                objCommand.Parameters.AddWithValue("@FK_CBID", course.FK_CBID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        [WebMethod]
        public bool DeleteCourse(Course course,string key)
        {
            if (course != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteCourse";
                objCommand.Parameters.AddWithValue("@courseID", course.CourseID);

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
        public bool UpdateCourse(Course course, string key)
            //Not working because i'm changing the courseid therefore it doesn't know which to update.
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
    }
}
