using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.DAL.Entity;

namespace Template.DAL.Database
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions <ApplicationContext> ops):base (ops)
        {
            
            
        }
        public DbSet<Department>departments { get; set; }
        public DbSet<Employee>Employee { get; set; }



        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=ABOELNAGA;database=templatedb;integrated security=true;encrypt=false");
        //}



    }
}
