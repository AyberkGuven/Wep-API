using FirstAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FirstAPI.Context
{
    public class PlantDbContext:DbContext
    {
        public PlantDbContext()
            : base("PlantDBConnectionString") 
        { 
        
        }
        public DbSet<Details> Details { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<treeName> TreeNames { get; set; }
    }
}