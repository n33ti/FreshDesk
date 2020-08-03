using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Repositories;
using Repository.Requsets;

namespace FreshDesk.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]


    public class AdminController : ControllerBase
    {

        private readonly IAdminRepo repo;
        public AdminController(IAdminRepo repo)
        {
            this.repo = repo;
        }
        [HttpGet("Admin")]
        public IActionResult GetAdmins()
        {
            //AdminRepo repo = new AdminRepo();
            return Ok(repo.GetAdmins());
        }

        [HttpGet("Users")]
        public IActionResult GetUsers()
        {
          //  AdminRepo repo = new AdminRepo();
            return Ok(repo.GetUsersDTO());
        }

        [HttpGet("DeleteTicket/{TicketId}")]
        public IActionResult DeleteTicket(int TicketId)
        {
           // AdminRepo repo = new AdminRepo();
            return Ok(repo.DeleteTicket(TicketId));
        }

        [HttpPost("CreateContact")]

        public IActionResult CreateContact(CreateContactRequest data)
        {
           // AdminRepo repo = new AdminRepo();
            return Ok(repo.CreateContact(data));
        }

        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin(AddUserRequest data)
        {
            return Ok(repo.AddAdmin(data));
        }

        [HttpGet("DeleteAdmin/{AdminId}")]
        public IActionResult DeleteAdmin(int AdminId)
        {
            // IUsersRepo repo = new UsersRepo();
            return Ok(repo.DeleteAdmin(AdminId));
        }

        [HttpGet("GetTickets/{ContactId}")]
        public IActionResult GetTickets(int ContactId)
        {
            return Ok(repo.GetTickets(ContactId));
        }

    }
}
