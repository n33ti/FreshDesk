using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Requsets
{
   public  class AddTicketRequest
    {
        public string Status { get; set; }

        public string Query { get; set; }

        public int ContactId { get; set; }
    }
}
