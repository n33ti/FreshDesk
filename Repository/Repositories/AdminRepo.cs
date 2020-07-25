using Repository.DTO;
using Repository.Requsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersManagement;
using UsersManagement.Models;

namespace Repository.Repositories
{
    public class AdminRepo : IAdminRepo
    {
        public bool CreateContact(CreateContactRequest data)
        {
            if (data == null)
                return false;
            Contact contact = new Contact();
            contact.Username = data.Username;
            DBContextApp db = new DBContextApp();
            var contacts = db.Contacts.Where(a => a.Username == data.Username).FirstOrDefault();
            if (contacts != null)
                return false;
            db.Contacts.Add(contact);
            db.SaveChanges();
            return true;

        }

        public bool DeleteTicket(int TicketId)
        {
            DBContextApp db = new DBContextApp();
            Ticket ticket = db.Tickets.Where(a => a.Id == TicketId).FirstOrDefault();
            if(ticket != null)
            {
                db.Tickets.Remove(ticket);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Admin> GetAdmins()
        {
            DBContextApp db = new DBContextApp();
            return db.Admins.ToList();
        }

        public List<UserDTO> GetUsersDTO()
        {
            DBContextApp db = new DBContextApp();
            List<UserDTO> users = new List<UserDTO>();
            foreach(var user in db.Users.ToList())
            {
                UserDTO usr = new UserDTO();
                usr.Username = user.Username;
                users.Add(usr);
            }
            return users;
            
        }
    }
}
