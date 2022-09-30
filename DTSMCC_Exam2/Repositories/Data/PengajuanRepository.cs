using DTSMCC_Exam2.Context;
using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.Repositories.Interface;
using DTSMCC_Exam2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Repositories.Data
{
    public class PengajuanRepository : IPengajuan
    {
        MyContext myContext;
        public PengajuanRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public List<Pengajuan> Get()
        {
            var data = myContext.pengajuans.ToList();
            return data;
        }

        public ResponsePengajuan Get(int idKaryawan)
        {
            var data = myContext.pengajuans
                .Include(x => x.StatusBekerja)
                .Include(x => x.Account)
                .FirstOrDefault(x =>
                    x.idKaryawan.Equals(idKaryawan));
            if (data != null)
            {
                ResponsePengajuan responsePengajuan = new ResponsePengajuan()
                {
                    idKaryawan = data.idKaryawan,
                    namaLengkap = data.Account.namaLengkap,
                    status = data.StatusBekerja.status,
                    namaPerusahaan = data.namaPerusahaan,
                    alamatPerusahaan = data.alamatPerusahaan,
                    statusPengajuan = data.statusPengajuan,
                };
                return responsePengajuan;
            }
            return null;
        }

        public int Post(PengajuanMV pengajuanMV)
        {
            Pengajuan pengajuan = new Pengajuan()
            {
                idKaryawan = pengajuanMV.idKaryawan,
                idStatusBekerja = pengajuanMV.idStatusBekerja,
                namaPerusahaan = pengajuanMV.namaPerusahaan,
                alamatPerusahaan = pengajuanMV.alamatPerusahaan
            };
            if (pengajuan.idStatusBekerja == 1)
                pengajuan.statusPengajuan = "Pending";
            else if (pengajuan.idStatusBekerja == 2)
                pengajuan.statusPengajuan = "Decline";
            else if (pengajuan.idStatusBekerja == 3)
                pengajuan.statusPengajuan = "Approve";
            myContext.pengajuans.Add(pengajuan);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
