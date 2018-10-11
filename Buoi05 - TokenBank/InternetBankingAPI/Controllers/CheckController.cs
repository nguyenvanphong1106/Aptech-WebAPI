using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using InternetBankingAPI.Models;

namespace InternetBankingAPI.Controllers
{
    public class CheckController : ApiController
    {
        BankDbEntities db = new BankDbEntities();

        //GET: api/check/Id?token=...
        [HttpGet]
        public IHttpActionResult Check(string id, [FromUri]string token)//[FromUri] để phân biệt đây là 1 tham số trên URL
        {
            //Check token
            if (string.IsNullOrEmpty(token)) return BadRequest();

            var cur_acc = db.Accounts.Where(x =>x.Token.Equals(token)).SingleOrDefault();
            if (cur_acc != null)
            {
                //cach 1
                var acc_to = (from a in db.Accounts
                              where a.AccountNo == id
                              select new
                               {
                                   a.Id, a.AccountName
                               }).SingleOrDefault();
                //cach 2
                //var acc_to2 = db.Accounts.Where(x => x.AccountNo.Equals(id)).SingleOrDefault();

                return Ok(acc_to);
            }
            return BadRequest();
        }
    }
}
