using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Onion.Data.Modes.Products;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Onion.Repository.ApplicationContext
{
     public class OnionDbContext :DbContext
    {
      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ApiDb;Integrated Security=true");

            base.OnConfiguring(optionsBuilder);
        }


        public virtual DbSet<Product> Products { get; set; }

      
    }
}
