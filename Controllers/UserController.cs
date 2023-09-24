using AppointmentschedularService.Models;
using AppointmentschedularService.Repository.IRepository;
using AppointmentschedularService.Repository.RepositoryImpl;
using AppointmentschedularService.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentschedularService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IUserService _Iuser;
            
        public UserController(IUserService user)
        {           
            _Iuser = user;
        }

        [HttpPost("InsertUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createdUser = _Iuser.InsertUser(user);
            return CreatedAtAction("GetUserById", new { id = createdUser.UserId }, createdUser);

        }


        [HttpPut("UpdateUserById")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            var isUpdated = _Iuser.UpdateUser(id, updatedUser);

            if (isUpdated)
            {
                return Ok("User Updated Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("DeleteUserById")]
        public IActionResult DeleteUser(int id)
        {
            var isDeleted = _Iuser.DeleteUser(id);

            if (isDeleted)
            {
                return Ok("User Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers()
        {
            var users = _Iuser.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById")]
        public IActionResult GetUserById(int id)
        {
            var user = _Iuser.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
                               
    }
}
