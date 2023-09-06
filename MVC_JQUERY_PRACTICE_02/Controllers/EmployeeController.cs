using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace MVC_JQUERY_PRACTICE_02.Controllers
{
    public class EmployeeController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con_string"].ConnectionString);
        // GET: Employee
        public ActionResult EmployeeForm()
        {
            return View();
        }

        public void EmployeeInsert(string A, string B, long C)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", A);
            cmd.Parameters.AddWithValue("@email", B);
            cmd.Parameters.AddWithValue("@mobile", C);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public JsonResult EmployeeShow()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_GetRecords", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            String data = JsonConvert.SerializeObject(dt); // serializing a DataTable object dt into a JSON-formatted string
            return Json(data,JsonRequestBehavior.AllowGet);
        }
    }
}