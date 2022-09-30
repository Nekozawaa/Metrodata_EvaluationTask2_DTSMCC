using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.ViewModels
{
    public class ResponseLogin
    {
        public int idKaryawan { set; get; }
        public string namaLengkap { set; get; }
        public string email { set; get; }
        public string alamat { set; get; }
        public string noTelp { set; get; }
        public string jenisKelamin { set; get; }
        public string role { set; get; }
    }
}
