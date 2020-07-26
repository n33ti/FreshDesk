using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement.Models;

namespace UsersManagement
{
   public  class DBContextApp : DbContext
    {
        public DBContextApp(DbContextOptions<DBContextApp> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Admin> Admins {get; set; }
        public DbSet<Contact> Contacts { get; set; }

       
    }
}
