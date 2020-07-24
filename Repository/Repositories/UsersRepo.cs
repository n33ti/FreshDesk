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
        public bool AddTicket(AddTicketRequest data, int UserId)
        {
            if(data == null)
            return false;
            DBContextApp db = new DBContextApp();
            Ticket ticket = new Ticket();
            ticket.ContactId = Convert.ToInt32(data.ContactId);
            ticket.Query = data.Query;
            ticket.Status = "Raised";
            ticket.UserId = UserId;
          
            db.Tickets.Add(ticket);
            db.SaveChanges();
            
            return true;
        }

        public bool AddUser(AddUserRequest data)
        {
            if (data == null)
                return false;
            List<User> users = this.GetUsers().Where(a=> a.Username == data.Username).ToList();
            if(users.Count()>1)
            {
                return false;
            }
            User user = new User();
            user.Password = data.Password;
            user.Username = data.Username;
            DBContextApp db = new DBContextApp();
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public Contact GetContact(int TicketId)
        {
            DBContextApp db = new DBContextApp();
            // Contact contact = db.Contacts.Where(a => TicketId == TicketId).FirstOrDefault();
            Ticket ticket = db.Tickets.Where(a => a.Id == TicketId).FirstOrDefault();
            return db.Contacts.Where(a=> a.Id == ticket.ContactId).FirstOrDefault();
        }

        public List<Contact> GetContacts()
        {
            DBContextApp db = new DBContextApp();

            return db.Contacts.ToList();
        }

        public List<Ticket> GetTickets(string username = null)
        {
            DBContextApp db = new DBContextApp();
            List<Ticket> tickets;
            if (username == null)
            {
                tickets = db.Tickets.ToList();
            }
            else
            {
                User usrs = this.GetUsers().Where(a => a.Username == username).FirstOrDefault();
                if (usrs == null)
                    return null;
                else
                    tickets = db.Tickets.Where(a => a.UserId == usrs.Id).ToList();
            }
            List<User> users = this.GetUsers();
            User user = users.Where(a => a.Username == username).FirstOrDefault();
            foreach (var item in tickets)
            {
                item.User = user;
                List<Contact> contacts = this.GetContacts();
                Contact contact = contacts.Where(a => a.Id == item.ContactId).FirstOrDefault();
                item.Contact = contact;
            }

            
            return tickets;

        }

        public List<User> GetUsers()
        {
            DBContextApp db = new DBContextApp();
            return db.Users.ToList();
        }

        public bool UpdateTicket(UpdateTicketRequest data)
        {
            if (data == null)
                return false;
            DBContextApp db = new DBContextApp();
            var ticket = db.Tickets.Where(a => a.Id == data.Id).FirstOrDefault();
            if(ticket == null)
            {
                return false;
            }
            if (data.Query != null)
                ticket.Query = data.Query;
            if (data.Status != null)
                ticket.Status = data.Status;
            db.SaveChanges();
            return true;
        }

        
    }
}
