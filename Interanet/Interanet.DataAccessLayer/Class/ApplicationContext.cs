using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Models.Data;

namespace DataAccessLayer.Class
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        //https://stackoverflow.com/questions/34534310/the-type-or-namespace-name-dbentityentrytentity-could-not-be-found
        //https://entityframework.net/knowledge-base/38878140/how-can-i-implement-dbcontext-connection-string-in--net-core-
        //https://askcodes.net/coding/how-can-i-implement-dbcontext-connection-string-in--net-core-
        public ApplicationContext( DbContextOptions<ApplicationContext>  Options)
            : base(Options)
        {

        }


        public DbSet<Customer> Customer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(Cus =>
            {
                Cus.HasKey(Cu => new { Cu.ID });
            });


        }

        DatabaseFacade  IApplicationContext.getDatabase()
        {
            return this.Database;
        }

   
    }
}