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

        public List<UserDTO> GetUsersDTO()
        {
           
            List<UserDTO> users = new List<UserDTO>();
            foreach(var user in _db.Users.ToList())
            {
                UserDTO usr = new UserDTO();
                usr.Username = user.Username;
                users.Add(usr);
            }
            return users;
            
        }
    }
}
