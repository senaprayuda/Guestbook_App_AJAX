using GSI_M6_P1_18.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GSI_M6_P1_18.Controllers
{

    public class HomeController : Controller
    {
        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public ActionResult Index()
        {
            List<GuestBookModel> guestbookModels = new List<GuestBookModel>();
            SqlCommand cmd = new SqlCommand("select * from GuestBook", connection);
            cmd.CommandType = CommandType.Text;
            connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                guestbookModels.Add(new GuestBookModel()
                {
                    id = Convert.ToInt32(dr["id"]),
                    nama = dr["nama"].ToString(),
                    alamat = dr["alamat"].ToString(),
                    provinsi = dr["provinsi"].ToString(),
                    jenisKelamin = Convert.ToInt32(dr["jenisKelamin"].ToString()),
                    tanggalLahir = Convert.ToDateTime(dr["tanggalLahir"]).ToString("yyyy-MM-dd"),
                    pesan = dr["pesan"].ToString()
                });
        };
        dr.Close();
        connection.Close();
        return View(guestbookModels);
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