using Repository.DTO;
using Repository.Requsets;
using System;
using System.Collections.Generic;
using System.Text;
using UsersManagement.Models;

namespace Repository.Repositories
{
   public interface IAdminRepo
    {
        List<Admin> GetAdmins();
        List<UserDTO> GetUsersDTO();

        bool CreateContact(CreateContactRequest data);
        bool DeleteTicket(int TicketId);


    }
}
