using Microsoft.EntityFrameworkCore;
using Repository.Requsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersManagement;
using UsersManagement.Models;

namespace Repository
{
   public class UsersRepo : IUsersRepo
    {
        private readonly DBContextApp _db;

        public UsersRepo(DBContextApp db)
        {
            this._db = db;
        }
        public bool AddTicket(AddTicketRequest data, int UserId)
        {
            if(data == null)
            return false;

            User user = _db.Users.Where(a => a.Id == UserId).FirstOrDefault();
            if (user == null)
                return false;
          
            Ticket ticket = new Ticket();
            ticket.ContactId = 1;
            ticket.Query = data.Query;
            ticket.Status = "Raised";
            ticket.UserId = UserId;
          
            _db.Tickets.Add(ticket);
            _db.SaveChanges();
            
            return true;
        }

        public bool AddUser(AddUserRequest data)
        {
            if (data == null)
                return false;
            if (data.Password == "")
                return false;
           User usr = this.GetUsers().Where(a=> a.Username == data.Username).FirstOrDefault();
            if(usr != null)
            {
                return false;
            }
            User user = new User();
            user.Password = data.Password;
            user.Username = data.Username;
          
            _db.Users.Add(user);
            _db.SaveChanges();
            return true;
        }

        public bool DeleteUser(int UserId)
        {
            User usr = _db.Users.Where(a => a.Id == UserId).FirstOrDefault();
            if (usr == null)
                return false;
            _db.Users.Remove(usr);
            _db.SaveChanges();
            return true;
        }

        public Contact GetContact(int TicketId)
        {
           
            // Contact contact = db.Contacts.Where(a => TicketId == TicketId).FirstOrDefault();
            Ticket ticket = _db.Tickets.Where(a => a.Id == TicketId).FirstOrDefault();
            if (ticket == null)
                return null;
            return _db.Contacts.Where(a=> a.Id == ticket.ContactId).FirstOrDefault();
        }

        public List<Contact> GetContacts()
        {
            

            return _db.Contacts.ToList();
        }

        public List<Ticket> GetTickets(string username = null)
        {
           
            List<Ticket> tickets;
            if (username == null)
            {
                tickets = _db.Tickets.ToList();
            }
            else
            {
                User usrs = this.GetUsers().Where(a => a.Username == username).FirstOrDefault();
                if (usrs == null)
                    return null;            
                    tickets = _db.Tickets.Where(a => a.UserId == usrs.Id).ToList();
                foreach (var item in tickets)
                {
                    //item.User = user;
                    item.User.Tickets.Clear();
                }

                }
            //List<User> users = this.GetUsers();
            //User user = users.Where(a => a.Username == username).FirstOrDefault();

            foreach (var item in tickets)
            {
                //item.User = user;
               // item.User.Tickets.Clear();
               
                List<Contact> contacts = this.GetContacts();
                Contact contact = contacts.Where(a => a.Id == item.ContactId).FirstOrDefault();
                item.Contact = contact;
                item.Contact.Tickets.Clear();
            }

            
            return tickets;

        }

        public List<User> GetUsers()
        {
            
            return _db.Users.ToList();
        }

        public bool UpdateTicket(UpdateTicketRequest data)
        {
            if (data == null)
                return false;
           
            var ticket = _db.Tickets.Where(a => a.Id == data.Id).FirstOrDefault();
            if(ticket == null)
            {
                return false;
            }
            if (data.Query != null)
                ticket.Query = data.Query;
            if (data.Status != null)
                ticket.Status = data.Status;
            if (data.ContactId != '\0')
                ticket.ContactId =data.ContactId ;
            _db.SaveChanges();
            return true;
        }

        
    }
}
