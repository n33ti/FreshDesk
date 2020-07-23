using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement.Models;

namespace UsersManagement
{
   public class Ticket
    {
        public int Id { get; set; }
       
        public string Status { get; set; }

        public string Query { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }

        public int ContactId { get; set; }

        public Contact Contact { get; set; }
    }
}
