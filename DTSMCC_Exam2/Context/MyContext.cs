using DTSMCC_Exam2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Account> accounts { set; get; }
        public DbSet<JenisKelamin> jenisKelamins { set; get; }
        public DbSet<Pengajuan> pengajuans { set; get; }
        public DbSet<Role> roles { set; get; }
        public DbSet<StatusBekerja> statusBekerjas { set; get; }
    }
}
