using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Models
{
    public class MyDBContext : DbContext
    {
        public MyDBContext():base("name=dbcontext")
        {
            

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employees> Employees { get; set; }
    }
}
