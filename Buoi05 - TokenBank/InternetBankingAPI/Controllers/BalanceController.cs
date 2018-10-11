using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using InternetBankingAPI.Models;

namespace InternetBankingAPI.Controllers
{
    public class BalanceController : ApiController
    {
        BankDbEntities db = new BankDbEntities();

        //GET: api/balance/Id?token=...
        [HttpGet]
        public IHttpActionResult GetBalance(int id,[FromUri]string token)//[FromUri] để phân biệt đây là 1 tham số trên URL
        {
            //Check token
            if (string.IsNullOrEmpty(token)) return BadRequest();

            var acc = db.Accounts.Where(x => x.Id == id && x.Token.Equals(token)).SingleOrDefault();
            if(acc != null)
            {
                return Ok(acc.Balance);
            }
            return BadRequest();
        }
    }
}
