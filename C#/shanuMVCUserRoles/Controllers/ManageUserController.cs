using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using shanuMVCUserRoles.Models;
using System.Data;
using Microsoft.AspNet.Identity;

namespace shanuMVCUserRoles.Controllers
{
    public class ManageUserController : Controller
    {
        string connectionString = "Server=tcp:scand2.database.windows.net,1433;Initial Catalog=AttendanceDB;Persist Security Info=False;User ID=scandadmin;Password=Capstone1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblScanned = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM AspNetUsers ORDER BY ID DESC", sqlCon);
                sqlDa.Fill(dtblScanned);
            }
            return View(dtblScanned);
        }

        // GET: Home/Create
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ManageUserModel());
        }

        // POST: Home/Create
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string id)
        {
            ManageUserModel manageUserModel = new ManageUserModel();
            DataTable dtblUser = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string ed = "SELECT * FROM AspNetUsers Where Id = @Id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(ed, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
                sqlDa.Fill(dtblUser);
            }
            if (dtblUser.Rows.Count == 1)
            {                
                manageUserModel.UserName = dtblUser.Rows[0][11].ToString();
                manageUserModel.Email = dtblUser.Rows[0][1].ToString();                
                return View(manageUserModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Scanned/Edit/5
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(ManageUserModel manageUserModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string ed = "UPDATE AspNetUsers SET UserName = @UserName , Email = @Email WHERE Id = @Id";
                SqlCommand sqlCmd = new SqlCommand(ed, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", manageUserModel.Id);
                sqlCmd.Parameters.AddWithValue("@UserName", manageUserModel.UserName);
                sqlCmd.Parameters.AddWithValue("@Email", manageUserModel.Email);                
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Scanned/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string del = "DELETE FROM AspNetUsers WHERE Id = @Id";
                SqlCommand sqlCmd = new SqlCommand(del, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
