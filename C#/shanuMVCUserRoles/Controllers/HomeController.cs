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
            return View();
        }

        // POST: Scanned/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Scanned/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Scanned/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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