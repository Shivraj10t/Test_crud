using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;

namespace Test_crud.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
                DataSet ds = new DataSet();
            try
            {
                string ss = ConfigurationManager.ConnectionStrings["qq"].ToString();
                SqlConnection con = new SqlConnection(ss);
                SqlCommand cmd = new SqlCommand("STUDENTS_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds);
                
            }
            catch (Exception ex)
            {

                throw ex ;
            }
            
            return View(ds);
        }




    }
}