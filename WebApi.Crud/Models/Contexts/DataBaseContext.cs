using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Entities;

namespace WebApi.Crud.Models.Contexts
{
    public class DataBaseContext:DbContext
    {

        public DataBaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
    }
}
