using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.ViewModels
{
    public class ResponsePengajuan
    {
        public int idKaryawan { set; get; }
        public string namaLengkap { set; get; }
        public string status { set; get; }
        public string namaPerusahaan { set; get; }
        public string alamatPerusahaan { set; get; }
        public string statusPengajuan { set; get; }
    }
}
