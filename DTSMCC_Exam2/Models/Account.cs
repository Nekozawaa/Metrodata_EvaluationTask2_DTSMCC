using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Models
{
    public class Account
    {
        [Key]
        public int idKaryawan { set; get; }
        public string namaLengkap { set; get; }
        public string email { set; get; }
        public string password { set; get; }
        public string alamat { set; get; }
        public string noTelp { set; get; }
        public JenisKelamin JenisKelamin { set; get; }
        [ForeignKey("JenisKelamin")]
        public int idJK { set; get; }
        public Role Role { set; get; }
        [ForeignKey("Role")]
        public int roleId { set; get; }
    }
}
