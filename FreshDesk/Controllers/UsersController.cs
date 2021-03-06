﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;

using Repository.Requsets;

namespace FreshDesk.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api")]
    [ApiController]
   
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo repo;
        public UsersController(IUsersRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
            //IUsersRepo repo = new UsersRepo();
            return Ok(repo.GetUsers());
        }

     

        [HttpGet("Tickets/{Username}")]
        public IActionResult GetAllTickets(string Username)
        {
            //IUsersRepo repo = new UsersRepo();
            return Ok(repo.GetTickets(Username));
        }

        [HttpGet("Tickets")]
        public IActionResult GetTickets()
        {
           // IUsersRepo repo = new UsersRepo();
            return Ok(repo.GetTickets());
        }


        [HttpGet("Contacts")]
        public IActionResult GetContacts()
        {
            //IUsersRepo repo = new UsersRepo();
            return Ok(repo.GetContacts());
        }

        [HttpGet("Contact/{TicketId}")]

        public IActionResult GetContact(int TicketId)
        
        {
           // IUsersRepo repo = new UsersRepo();
            return Ok(repo.GetContact(TicketId));

        }      



        [HttpPost("AddTicket/{UserId}")]
        public IActionResult AddTicket(AddTicketRequest data, int UserId)
        {
          //  IUsersRepo repo = new UsersRepo();
            return Ok(repo.AddTicket(data, UserId));
        }

        [HttpPost("AddUser")]
        public IActionResult AddUser(AddUserRequest data)
        {
           // IUsersRepo repo = new UsersRepo();
            return Ok(repo.AddUser(data));
        }

        [HttpPost("UpdateTicket")]
        public IActionResult UpdateUser(UpdateTicketRequest data)
        {
           // IUsersRepo repo = new UsersRepo();
            return Ok(repo.UpdateTicket(data));
        }

        [HttpGet("DeleteUser/{UserId}")]
        public IActionResult DeleteUser(int UserId)
        {
            // IUsersRepo repo = new UsersRepo();
            return Ok(repo.DeleteUser(UserId));
        }

    }
}
