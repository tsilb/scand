using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{          
            String connectionString = "Server=tcp:scand2.database.windows.net,1433;Initial Catalog=AttendanceDB;Persist Security Info=False;User ID=scandadmin;Password=Capstone1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            String sql = "SELECT * FROM Logs";        

            var model = new List<ScannedViewModel>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var scanned = new ScannedViewModel();
                    scanned.UserName = rdr["UserName"].ToString();
                    scanned.Room = rdr["Room"].ToString();
                    scanned.Time = rdr["Time"].ToString();

                    model.Add(scanned);
                }
            }
            return View(model);
        }

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
    }
}