using FinancesWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FinancesWebApi.Data
{
    public class DataContext : DbContext
    {
        //public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<ListFinances> Financas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source = ITLNB055\SQL2017; Initial Catalog = Financas; Integrated Security = True");
           
        }
    }
}
