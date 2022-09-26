using Microsoft.EntityFrameworkCore;
using Project1_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1_Core.Database_conn
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)     //since,constructor initializes object.
        {

        }
        public DbSet<Employee> Employeeies { get; set; }
    }
}
