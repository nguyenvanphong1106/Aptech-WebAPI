using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using InternetBankingAPI.Models;

namespace InternetBankingAPI.Controllers
{
    public class TransactionsController : ApiController
    {
        private BankDbEntities db = new BankDbEntities();

        // GET: api/Transactions
        public IQueryable<Transaction> GetTransactions()
        {
            return db.Transactions;
        }

        // GET: api/Transactions/5
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult GetTransaction(int id)
        {
            Transaction transaction = db.Transactions.Find(id);
            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        //DELETE PUT TRANSACTION

        //Create new transaction
        // POST: api/Transactions?token=...
        [ResponseType(typeof(Transaction))]
        public IHttpActionResult PostTransaction(Transaction transaction,  [FromUri] string token)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Transactions.Add(transaction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = transaction.Id }, transaction);
        }

        // DELETE: api/Transactions/5 --> DELETE THIS METHOD
    }
}