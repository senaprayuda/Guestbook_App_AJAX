using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GSI_M6_P1_18.Models
{
    public class GuestBookModel
    {
        public int id { get; set; }

        public string nama { get; set; }
        
        public string alamat { get; set; }

        public string provinsi { get; set; }

        public int jenisKelamin { get; set; }

        public string tanggalLahir { get; set; }

        public string pesan { get; set; }


    }
}