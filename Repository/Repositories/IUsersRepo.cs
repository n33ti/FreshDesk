
using Repository.Requsets;
using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement;
using UsersManagement.Models;

namespace Repository
{
   public interface IUsersRepo
    {

        List<User> GetUsers();
        List<Ticket> GetTickets(int UserId=0);
        List<Contact> GetContacts();

        Contact GetContact(int TicketId);

        bool AddTicket(AddTicketRequest data, int UserId);

        bool AddUser(AddUserRequest data);

        bool UpdateTicket(UpdateTicketRequest data);
    }
}
