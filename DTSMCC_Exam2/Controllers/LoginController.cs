using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.Repositories.Data;
using DTSMCC_Exam2.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        AccountRepository accountRepository;
        public LoginController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if(data != null)
                return Ok(new { message = "Berhasil Login, Selamat Datang " + data.namaLengkap, statusCode = 200, data = data });
            return BadRequest(new { message = "Gagal Login", statusCode = 400});
        }
    }
}
