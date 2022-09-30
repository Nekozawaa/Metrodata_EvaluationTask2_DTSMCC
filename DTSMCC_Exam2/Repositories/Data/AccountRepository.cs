using DTSMCC_Exam2.Context;
using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.Repositories.Interface;
using DTSMCC_Exam2.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BCrypt.Net;

namespace DTSMCC_Exam2.Repositories.Data
{
    public class AccountRepository : IAccount
    {
        MyContext myContext;
        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        //LOGIN
        public ResponseLogin Login(Login login)
        {
            var data = myContext.accounts
                .Include(x => x.Role)
                .Include(x => x.JenisKelamin)
                .FirstOrDefault(x =>
                    x.email.Equals(login.Email));
            bool verifikasi = BCrypt.Net.BCrypt.Verify(login.Password, data.password); //Proses verifikasi hashing dari password yg diinput dgn password database
            if (verifikasi == true)
            {
                if (data != null)
                {
                    ResponseLogin responseLogin = new ResponseLogin()
                    {
                        idKaryawan = data.idKaryawan,
                        namaLengkap = data.namaLengkap,
                        email = data.email,
                        alamat = data.alamat,
                        noTelp = data.noTelp,
                        jenisKelamin = data.JenisKelamin.jenisKelamin,
                        role = data.Role.namaRole,

                    };
                    return responseLogin;
                }
            }
            return null;
        }

        //REGIST
        public int Regist(Regist regist)
        {
            regist.password = BCrypt.Net.BCrypt.HashPassword(regist.password); //Hashing password ketika pertama kali melakukan registrasi
            Account account = new Account()
            {
                namaLengkap = regist.namaLengkap,
                email = regist.email,
                password = regist.password,
                alamat = regist.alamat,
                noTelp = regist.noTelp,
                idJK = regist.idJK,
                roleId = regist.roleId,
            };
            myContext.accounts.Add(account);
            var result = myContext.SaveChanges();
            return result;
        }

        //VIEW
        public List<Account> ViewAccount()
        {
            var data = myContext.accounts.ToList();
            return data;
        }

        public ResponseGetAccount ViewAccount(int id)
        {
            var data = myContext.accounts
                .Include(x => x.Role)
                .Include(x => x.JenisKelamin)
                .FirstOrDefault(x =>
                    x.idKaryawan.Equals(id));
            if (data != null)
            {
                ResponseGetAccount responseGetAccount = new ResponseGetAccount()
                {
                    idKaryawan = data.idKaryawan,
                    namaLengkap = data.namaLengkap,
                    email = data.email,
                    password = data.password,
                    jenisKelamin = data.JenisKelamin.jenisKelamin,
                    role = data.Role.namaRole,
                };
                return responseGetAccount;
            }
            return null;
        }

        public Account Get(int id)
        {
            var data = myContext.accounts.Find(id);
            return data;
        }

        //UPDATE
        public int Update(Update update)
        {
            var data = Get(update.idKaryawan);
            data.namaLengkap = update.namaLengkap;
            data.email = update.email;
            data.password = BCrypt.Net.BCrypt.HashPassword(update.password); //Hashing ketika mengganti password
            data.alamat = update.alamat;
            data.noTelp = update.noTelp;
            data.idJK = update.idJK;
            data.roleId = update.roleId;

            myContext.accounts.Update(data);
            var result = myContext.SaveChanges();
            return result;
        }

        //DELETE
        public int DeleteAccount(int id)
        {
            var data = Get(id);
            myContext.accounts.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
