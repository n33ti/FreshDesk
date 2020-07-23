using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement.Models;

namespace UsersManagement
{
   public  class DBContextApp : DbContext
    {
     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=APINP-ELPT55965;user id=sa;password=2November@;database=UserManagement");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Admin> Admins {get; set; }
        public DbSet<Contact> Contacts { get; set; }

       
    }
}
