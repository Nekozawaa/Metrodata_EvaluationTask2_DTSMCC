using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Models
{
    public class JenisKelamin
    {
        [Key]
        public int idJK { set; get; }
        public string jenisKelamin { set; get; }

    }
}
