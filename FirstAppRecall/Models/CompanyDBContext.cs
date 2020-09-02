using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Web;

namespace FirstAppRecall.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext() : base(@"data source=DESKTOP-HA86C8R; initial catalog=Company1; integrated Security=true ")
        { 
        
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories{ get; set; }

        public DbSet<Product> Products { get; set; }

    }
}