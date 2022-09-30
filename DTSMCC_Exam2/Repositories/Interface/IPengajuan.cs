using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Repositories.Interface
{
    interface IPengajuan
    {
        List<Pengajuan> Get();
        ResponsePengajuan Get(int idKaryawan);
        int Post(PengajuanMV pengajuanMV);
    }
}
