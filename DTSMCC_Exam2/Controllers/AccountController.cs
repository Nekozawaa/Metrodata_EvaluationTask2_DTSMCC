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
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }


        [HttpPost]
        public IActionResult Regist(Regist regist)
        {
            var result = accountRepository.Regist(regist);
            if (result > 0)
                return Ok(new { message = "Berhasil melakukan registrasi", statusCode = 200, data = result });
            return BadRequest(new { message = "Gagal melakukan registrasi", statusCode = 400 });
        }

        [HttpGet]
        public IActionResult ViewAccount()
        {
            var data = accountRepository.ViewAccount();
            if (data.Count == 0)
                return Ok(new { message = "Data masih kosong !", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult ViewAccount(int id)
        {
            var data = accountRepository.ViewAccount(id);
            if (data == null)
                return Ok(new { message = "Data dengan ID " + id + " tidak ditemukan !", statusCode = 200, data = "null" });
            return Ok(new { message = "Berhasil menampilkan data !", statusCode = 200, data = data });
        }

        [HttpPut]
        public IActionResult Update(Update update)
        {
            var result = accountRepository.Update(update);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Data berhasi di Update !" });
            return BadRequest(new { statusCode = 400, message = "Data gagal di Update !" });
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteAccount(int id)
        {
            var result = accountRepository.DeleteAccount(id);
            if (result > 0)
                return Ok(new { statusCode = 200, message = "Data berhasil Dihapus !" });
            return BadRequest(new { statusCode = 400, message = "Data gagal Dihapus !" });
        }
    }
}
