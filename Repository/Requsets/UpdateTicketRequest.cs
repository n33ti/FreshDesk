using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Requsets
{
    public class UpdateTicketRequest: AddTicketRequest
    {
        public int Id { get; set; }
    }
}
