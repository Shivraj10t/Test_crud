using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using Newtonsoft.Json;
using System.Web.UI.WebControls;

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
                throw ex;
            }

            return View(ds);
        }

        public JsonResult getListData()
        {
            DataSet ds = new DataSet();
            string result = string.Empty;
            try
            {
                string ss = ConfigurationManager.ConnectionStrings["qq"].ToString();
                SqlConnection con = new SqlConnection(ss);
                SqlCommand cmd = new SqlCommand("STUDENTS_LIST", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds);
                result = JsonConvert.SerializeObject(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
           
        }

        public ActionResult Add_update()
        {
            return View();
        }

        public string SAVE_DATA(string firstName,string LastName, int Contact,string DO)
        {
            DataSet ds = new DataSet();
            string ss = ConfigurationManager.ConnectionStrings["qq"].ToString();
            SqlConnection con = new SqlConnection(ss);
            SqlCommand cmd = new SqlCommand("INSERT_UPDATE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("id", 0);
            cmd.Parameters.AddWithValue("firstName", firstName);
            cmd.Parameters.AddWithValue("lastName", LastName);
            cmd.Parameters.AddWithValue("contact", Contact);
            cmd.Parameters.AddWithValue("DOB", DateTime.Today);
            cmd.Parameters.AddWithValue("mode",1);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            sqlDataAdapter.SelectCommand = cmd;
            sqlDataAdapter.Fill(ds);
            return "";
        }
        public ActionResult Update_data(int id)
        {


            DataSet ds = new DataSet();
            string result = string.Empty;
            try
            {
                string ss = ConfigurationManager.ConnectionStrings["qq"].ToString();
                SqlConnection con = new SqlConnection(ss);
                SqlCommand cmd = new SqlCommand("select_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ID", id);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds);
                result = JsonConvert.SerializeObject(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }


            return View(ds);
        }

public JsonResult get_data(int student_id)
        {
            DataSet ds = new DataSet();
            string result = string.Empty;
            try
            {
                string ss = ConfigurationManager.ConnectionStrings["qq"].ToString();
                SqlConnection con = new SqlConnection(ss);
                SqlCommand cmd = new SqlCommand("select_data", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@P_ID", student_id);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = cmd;
                sqlDataAdapter.Fill(ds);
                result = JsonConvert.SerializeObject(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(result,JsonRequestBehavior.AllowGet);
        }

    }
}