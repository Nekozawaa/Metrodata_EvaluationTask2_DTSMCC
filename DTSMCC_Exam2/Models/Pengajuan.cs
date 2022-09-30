using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Models
{
    public class Pengajuan
    {
        [Key]
        public int idPengajuan { set; get; }
        public Account Account { set; get; }
        [ForeignKey("Account")]
        public int idKaryawan { set; get; }
        public StatusBekerja StatusBekerja { set; get; }
        [ForeignKey("StatusBekerja")]
        public int idStatusBekerja { set; get; }
        public string namaPerusahaan { set; get; }
        public string alamatPerusahaan { set; get; }
        public string statusPengajuan { set; get; }
    }
}
