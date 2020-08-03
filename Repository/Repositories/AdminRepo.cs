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
        private readonly DBContextApp _db;

        public AdminRepo(DBContextApp db)
        {
            this._db = db;
        }

        public bool AddAdmin(AddUserRequest data)
        {
            if (data == null)
                return false;
            if (data.Password == "")
                return false;
            Admin admin = this.GetAdmins().Where(a => data.Username == a.Username).FirstOrDefault();
            if (admin != null)
                return false;
            admin = new Admin();
            admin.Username = data.Username;
            admin.Password = data.Password;
            _db.Admins.Add(admin);
            _db.SaveChanges();
            return true;
        }

        public bool CreateContact(CreateContactRequest data)
        {
            if (data == null)
                return false;
            Contact contact = new Contact();
            contact.Username = data.Username;
           
            var contacts = _db.Contacts.Where(a => a.Username == data.Username).FirstOrDefault();
            if (contacts != null)
                return false;
            _db.Contacts.Add(contact);
            _db.SaveChanges();
            return true;

        }

        public bool DeleteAdmin(int AdminId)
        {
            Admin adm = _db.Admins.Where(a => a.Id == AdminId).FirstOrDefault();
            if (adm == null)
                return false;
            _db.Admins.Remove(adm);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteTicket(int TicketId)
        {
            
            Ticket ticket = _db.Tickets.Where(a => a.Id == TicketId).FirstOrDefault();
            if(ticket != null)
            {
                _db.Tickets.Remove(ticket);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Admin> GetAdmins()
        {
            
            return _db.Admins.ToList();
        }

        public List<Ticket> GetTickets(int ContactId)
        {
            Contact contact = _db.Contacts.Where(a => a.Id == ContactId).FirstOrDefault();
            if (contact == null)
                return null;
            List<Ticket> tickets = _db.Tickets.Where(a => a.ContactId == ContactId).ToList();
            foreach(var ticket in tickets)
            {
                ticket.Contact = null;
            }
            return tickets;
        }

        public List<UserDTO> GetUsersDTO(int userId = 0)
        {
            if(userId != 0)
            {
                User user =_db.Users.Where(a => a.Id == userId).FirstOrDefault();
                if (user == null)
                    return null;
                UserDTO usr = new UserDTO();
                usr.Username = user.Username;
                usr.UserId = user.Id;
                List<UserDTO> usrs = new List<UserDTO>();
                usrs.Add(usr);
                return usrs;

            }
           
            List<UserDTO> users = new List<UserDTO>();
            foreach(var user in _db.Users.ToList())
            {
                UserDTO usr = new UserDTO();
                usr.Username = user.Username;
                usr.UserId = user.Id;
                users.Add(usr);
            }
            return users;
            
        }

       
    }
}
