using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace FDI.Areas.Admin.Controllers
{
    public class ExecuteController : Controller
    {

        public SqlConnection Getconnection { get; private set; }

        public ExecuteController()
        {
            DbConnect();
        }

        public ActionResult Index()
        {
            DataTable dt = null;
            //var role = Roles.GetRolesForUser(UserName);
            //if (role.Contains("Admin"))
            //{}
            var type = Request["DropDownList"];
            var txtsql = Request["txtsql"];
            ViewBag.txtsql = txtsql;
            ViewBag.type = type;
            if (type == "1")
            {
                try
                {
                    dt = Gets(txtsql);
                    ViewBag.Text = "Câu lệnh đã được thực thi";
                }
                catch (Exception ex)
                {
                    ViewBag.Text = "Lỗi khi thực thi";
                    ViewBag.Message = ex.Message;
                }
            }
            if (type == "2")
            {
                try
                {
                    ExecuteQuerys(txtsql);
                    ViewBag.Text = "Câu lệnh đã được thực thi";
                }
                catch (Exception ex)
                {
                    ViewBag.Text = "Lỗi khi thực thi";
                    ViewBag.Message = ex.Message;
                }
            }

            return View(dt);
        }

        public void DbConnect()
        {
            try
            {
                var strCon = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                Getconnection = new SqlConnection(strCon);
                Getconnection.Open();
            }
            catch (Exception)
            {
                throw new Exception("Lỗi kết nối DataBase !");
            }
        }

        public int ExecuteQuerys(string query)
        {
            int re;
            try
            {
                if (Getconnection.State == ConnectionState.Closed)
                    Getconnection.Open();
                var sql = query;
                var cmd = new SqlCommand(sql, Getconnection);
                re = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return re;
        }

        public DataTable Gets(string query)
        {
            if (Getconnection.State == ConnectionState.Closed)
                Getconnection.Open();
            var sql = query;
            var da = new SqlDataAdapter(sql, Getconnection);
            var ds = new DataTable();
            da.Fill(ds);
            Getconnection.Close();
            return ds;
        }

    }
}
