using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement.Models;

namespace UsersManagement
{
   public  class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public List<Ticket> Tickets { get; set;}
        
    }
}
