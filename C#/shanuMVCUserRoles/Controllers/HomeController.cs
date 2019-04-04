using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using shanuMVCUserRoles.Models;
using System.Data;

namespace shanuMVCUserRoles.Controllers
{
	public class HomeController : Controller
	{
        string connectionString = "Server=tcp:scand2.database.windows.net,1433;Initial Catalog=AttendanceDB;Persist Security Info=False;User ID=scandadmin;Password=Capstone1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblScanned = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Logs ORDER BY ID DESC", sqlCon);
                sqlDa.Fill(dtblScanned);
            }
            return View(dtblScanned);
        }

        // GET: Home/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ScannedViewModel());
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(ScannedViewModel scannedViewModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string ins = "INSERT INTO Logs VALUES(@UserName,@Room,@Time)";
                SqlCommand sqlCmd = new SqlCommand(ins, sqlCon);
                sqlCmd.Parameters.AddWithValue("@UserName", scannedViewModel.UserName);
                sqlCmd.Parameters.AddWithValue("@Room", scannedViewModel.Room);
                sqlCmd.Parameters.AddWithValue("@Time", scannedViewModel.Time);
                sqlCmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");
        }

        // GET: Scanned/Edit/5
        public ActionResult Edit(int id)
        {
            ScannedViewModel scannedViewModel = new ScannedViewModel();
            DataTable dtblScanned = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string ed = "SELECT * FROM Logs Where ID = @ID";
                SqlDataAdapter sqlDa = new SqlDataAdapter(ed, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@ID", id);
                sqlDa.Fill(dtblScanned);
            }
            if (dtblScanned.Rows.Count == 1)
            {
                scannedViewModel.UserName = dtblScanned.Rows[0][1].ToString();
                scannedViewModel.Room = dtblScanned.Rows[0][2].ToString();
                scannedViewModel.Time = dtblScanned.Rows[0][3].ToString();
                return View(scannedViewModel);
            }
            else
                return RedirectToAction("Index");                
        }

        // POST: Scanned/Edit/5
        [HttpPost]
        public ActionResult Edit(ScannedViewModel scannedViewModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string ed = "UPDATE Logs SET UserName = @UserName , Room = @Room , Time = @Time WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(ed, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", scannedViewModel.ID);
                sqlCmd.Parameters.AddWithValue("@UserName", scannedViewModel.UserName);
                sqlCmd.Parameters.AddWithValue("@Room", scannedViewModel.Room);
                sqlCmd.Parameters.AddWithValue("@Time", scannedViewModel.Time);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Scanned/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string del = "DELETE FROM Logs WHERE ID = @ID";
                SqlCommand sqlCmd = new SqlCommand(del, sqlCon);
                sqlCmd.Parameters.AddWithValue("@ID", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
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