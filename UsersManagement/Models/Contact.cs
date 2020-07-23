using System;
using System.Collections.Generic;
using System.Text;

namespace UsersManagement.Models
{
   public class Contact
    {
        public int Id { get; set; }

        public String Username { get; set; }

        public List <Ticket> Tickets { get; set; }


    }
}
