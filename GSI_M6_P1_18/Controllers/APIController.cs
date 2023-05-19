using GSI_M6_P1_18.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSI_M6_P1_18.Controllers
{
    public class APIController : Controller
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        ResponseModel response = new ResponseModel();

        [HttpGet]
        public JsonResult getAllDataGuestBook()
        {
            try
            {
                response.status = 200;
                response.messages = "Success";
                response.data = new List<object>();
                SqlCommand cmd = new SqlCommand("Select * from GuestBook", connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string nama = dr["nama"].ToString();
                    string alamat = dr["alamat"].ToString();
                    string provinsi = dr["provinsi"].ToString();
                    int jenisKelamin = Convert.ToInt32(dr["jenisKelamin"].ToString());
                    string tanggalLahir = Convert.ToDateTime(dr["tanggalLahir"]).ToString("yyyy-MM-dd");
                    string pesan = dr["pesan"].ToString();
                    response.data.Add(new { id, nama, alamat, provinsi, jenisKelamin, tanggalLahir, pesan });
                };
                dr.Close();
                connection.Close();
            }
            catch
            {
                response.status = 500;
                response.messages = "Failed";
                response.data = null;

            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult getDataGuestBook(int pid)
        {
            try
            {
                response.status = 200;
                response.messages = "Success";
                response.data = new List<object>();
                SqlCommand cmd = new SqlCommand("Select * from GuestBook where id= @p1", connection);
                cmd.Parameters.AddWithValue("@p1", pid);
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = Convert.ToInt32(dr["id"]);
                    string nama = dr["nama"].ToString();
                    string alamat = dr["alamat"].ToString();
                    string provinsi = dr["provinsi"].ToString();
                    int jenisKelamin = Convert.ToInt32(dr["jenisKelamin"].ToString());
                    string tanggalLahir = Convert.ToDateTime(dr["tanggalLahir"]).ToString("yyyy-MM-dd");
                    string pesan = dr["pesan"].ToString();
                    response.data.Add(new { id, nama, alamat, provinsi, jenisKelamin, tanggalLahir, pesan });
                };
                dr.Close();
                connection.Close();
            }
            catch
            {
                response.status = 500;
                response.messages = "Failed";
                response.data = null;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public JsonResult insertGuestBook(string nama, string alamat, string provinsi, int jenisKelamin, string tanggalLahir, string pesan)
        {
            try
            {
                response.status = 200;
                response.messages = "Success";
                response.data = new List<object>();
                SqlCommand cmd = new SqlCommand("Insert into GuestBook values(@p1,@p2,@p3,@p4,@p5,@p6)", connection);
                cmd.Parameters.AddWithValue("@p1", nama);
                cmd.Parameters.AddWithValue("@p2", alamat);
                cmd.Parameters.AddWithValue("@p3", provinsi);
                cmd.Parameters.AddWithValue("@p4", jenisKelamin);
                cmd.Parameters.AddWithValue("@p5", tanggalLahir);
                cmd.Parameters.AddWithValue("@p6", pesan);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                response.status = 500;
                response.messages = "Failed";
                response.data = null;
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult updateGuestBook(int id, string nama, string alamat, string provinsi, int jenisKelamin, string tanggalLahir, string pesan)
        {
            try
            {
                response.status = 200;
                response.messages = "Success";
                response.data = new List<object>();
                SqlCommand cmd = new SqlCommand("update GuestBook " +
                    "set nama = @p2" +
                    ",alamat = @p3" +
                    ",provinsi = @p4" +
                    ",jenisKelamin = @p5" +
                    ",tanggalLahir = @p6" +
                    ",pesan = @p7" +
                    " where id = @p1", connection);
                cmd.Parameters.AddWithValue("@p1", id);
                cmd.Parameters.AddWithValue("@p2", nama);
                cmd.Parameters.AddWithValue("@p3", alamat);
                cmd.Parameters.AddWithValue("@p4", provinsi);
                cmd.Parameters.AddWithValue("@p5", jenisKelamin);
                cmd.Parameters.AddWithValue("@p6", tanggalLahir);
                cmd.Parameters.AddWithValue("@p7", pesan);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                response.status = 500;
                response.messages = ex.ToString();
                response.data = null;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult deleteGuestBook(int id)
        {
            try
            {
                response.status = 200;
                response.messages = "Success";
                response.data = new List<object>();
                SqlCommand cmd = new SqlCommand("delete from GuestBook where id = @p1", connection);
                cmd.Parameters.AddWithValue("@p1", id);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch
            {
                response.status = 500;
                response.messages = "Failed";
                response.data = null;
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }
    }
}




