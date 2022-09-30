using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.ViewModels
{
    public class ResponseGetAccount
    {
        public int idKaryawan { set; get; }
        public string namaLengkap { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string jenisKelamin { set; get; }
        public string role { set; get; }
    }
}
