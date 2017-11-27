using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

using TermProjectClassLibrary;
using Utilities;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace SQLtest
{
    public class SQL
    {
        
        public int verifyLogin(string username, string password)
        {
            //if (cb != null && key == "zuhdi")
            //{
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();
            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_verifyUserForLogin";
            objCommand.Parameters.AddWithValue("@Username", username);
            objCommand.Parameters.AddWithValue("@Password", password);
            SqlParameter returnValue = new SqlParameter("@Result", 0);
            ;
            returnValue.Direction = ParameterDirection.Output;
            objCommand.Parameters.Add(returnValue);

            objDB.GetDataSetUsingCmdObj(objCommand);

            int result = int.Parse(objCommand.Parameters["@Result"].Value.ToString());

            return result;
            //}

            //return 0;
        }

        
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

        
        public bool DeleteCourse(Course course, string key)
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

        
        public void EnrollCourse(string key)
        {

        }

        
        public void EmailCourse(string key)
        {

        }

        
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

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
    }
}
