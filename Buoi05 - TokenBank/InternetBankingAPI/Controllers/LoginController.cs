using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web.Http;
using InternetBankingAPI.Models;

namespace InternetBankingAPI.Controllers
{
    public class LoginController : ApiController
    {
        BankDbEntities db = new BankDbEntities();

        //Encrypt Token
        private string Encrypt(string s)
        {
            SHA256 sha = SHA256Managed.Create();
            byte[] rs = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            return BitConverter.ToString(rs).ToLower().Replace("-", "");
        }

        //POST: api/Login
        [HttpPost]
        public IHttpActionResult CheckLogin(Account data)    //truyen di 1 du lieu object
        {
            var acc = db.Accounts.Where(x => x.AccountNo.Equals(data.AccountNo)).SingleOrDefault();
            if(acc != null)
            {
                if(acc.PIN.Equals(data.PIN))
                {
                    //set token for tracing history
                    acc.LastLogin = DateTime.Now;
                    acc.Token = Encrypt(acc.Id + acc.LastLogin.Value.Ticks.ToString()); //Value.Ticks lay ve don vi micro s
                    db.SaveChanges();

                    return Ok(acc);
                }
            }
            return BadRequest();
        }
    }
}
