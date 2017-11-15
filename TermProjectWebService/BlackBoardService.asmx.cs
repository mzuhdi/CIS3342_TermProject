using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
        public void createCourse(string key)
        {
            
        }

        [WebMethod]
        public void DeleteCourse(string key)
        {
            
        }

        [WebMethod]
        public void EnrollCourse(string key)
        {
            
        }

        [WebMethod]
        public string EmailCourse(string key)
        {
           
        }
    }
}
