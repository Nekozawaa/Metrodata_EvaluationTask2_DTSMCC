using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Models
{
    public class Role
    {
        [Key]
        public int idRole { set; get; }
        public string namaRole { set; get; }
    }
}
