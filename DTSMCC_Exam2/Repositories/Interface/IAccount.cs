using DTSMCC_Exam2.Models;
using DTSMCC_Exam2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DTSMCC_Exam2.Repositories.Interface
{
    interface IAccount
    {
        ResponseLogin Login(Login login);
        int Regist(Regist regist);
        List<Account> ViewAccount();
        ResponseGetAccount ViewAccount(int id);
        Account Get(int id);
        int Update(Update update);
        public int DeleteAccount(int id);
    }
}
