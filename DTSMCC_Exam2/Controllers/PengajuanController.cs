using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.Repositories.Data;
using DTSMCC_Exam2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PengajuanController : ControllerBase
    {
        PengajuanRepository pengajuanRepository;
        public PengajuanController(PengajuanRepository pengajuanRepository)
        {
            this.pengajuanRepository = pengajuanRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = pengajuanRepository.Get();
            if (data.Count == 0)
                return Ok(new { message = "Data masih kosong !", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = pengajuanRepository.Get(id);
            if (data == null)
                return Ok(new { message = "Data dengan ID Karyawan " + id + " tidak ditemukan !", statusCode = 200, data = "null" });
            if (data.statusPengajuan == "Pending")
            {
                return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data, alasan = "Dikarenakan Statusnya 'Masa Pelatihan' maka permintaan akan di Pending hingga menyelesaikan pelatihan" });
            }
            if (data.statusPengajuan == "Decline")
            {
                return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data, alasan = "Dikarenakan Statusnya 'Bekerja' maka permintaan akan di Decline karena kontrak di perusahaan sebelumnya belum selesai" });
            }
            if (data.statusPengajuan == "Approve")
            {
                return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data, alasan = "Dikarenakan Statusnya 'Tidak Bekerja' maka permintaan akan di Approve karena kontrak dengan perusahaan sebelumnya sudah selesai" });
            }return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data });
        }

        [HttpPost]
        public IActionResult Post(PengajuanMV pengajuanMV)
        {
            var result = pengajuanRepository.Post(pengajuanMV);
            if (result > 0)
                return Ok(new { message = "Berhasil melakukan registrasi", statusCode = 200, data = result });
            return BadRequest(new { message = "Gagal melakukan registrasi", statusCode = 400 });
        }
    }
}
