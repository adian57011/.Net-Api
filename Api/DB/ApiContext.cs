using Api.DB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api.DB
{
    public class ApiContext:DbContext
    {
        public DbSet<Catagory> Catagories { get; set; }
        public DbSet<News> News { get; set; }

    }
}