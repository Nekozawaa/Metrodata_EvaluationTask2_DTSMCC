using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Models
{
    public class StatusBekerja
    {
        [Key]
        public int idSB { set; get; }
        public string status { set; get; }
    }
}
