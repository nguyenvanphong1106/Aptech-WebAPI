using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Buoi07___BookAPI.Models
{
    public class Buoi07BookAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Buoi07BookAPIContext() : base("name=Buoi07BookAPIContext")
        {
        }

        public System.Data.Entity.DbSet<Buoi07___BookAPI.Models.Book> Books { get; set; }

        public System.Data.Entity.DbSet<Buoi07___BookAPI.Models.Author> Authors { get; set; }
    }
}
