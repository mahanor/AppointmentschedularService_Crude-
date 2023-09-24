using AppointmentschedularService.Data;
using AppointmentschedularService.Models;
using AppointmentschedularService.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppointmentschedularService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _IAppoint;
        private readonly DataContext _ctx;
        public AppointmentController(IAppointmentService iAppoint, DataContext ctx)
        {
            _IAppoint = iAppoint;
            _ctx = ctx;
        }

        [HttpPost("CreateAppointment")]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            var createdAppointment = _IAppoint.CreateAppointment(appointment);
            return CreatedAtAction("GetApointmentById", new { id = createdAppointment.AppointmentId }, createdAppointment);
            
        }

        [HttpPut("UpdateAppointment")]
        public IActionResult UpdateAppointment(int id, [FromBody] Appointment updatedAppointment)
        {
            var isUpdated = _IAppoint.UpdateAppointment(id, updatedAppointment);

            if (isUpdated)
            {
                return Ok("Appointment Updated Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetApointmentById")]
        public IActionResult GetApointmentById(int id)
        {
            var Appointment = _IAppoint.GetApointmentById(id);

            if (Appointment == null)
            {
                return NotFound();
            }

            return Ok(Appointment);
        }

        [HttpDelete("DeleteAppointment")]
        public IActionResult DeleteUser(int id)
        {
            var isDeleted = _IAppoint.DeleteAppointment(id);

            if (isDeleted)
            {
                return Ok("User Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("monthly-Appointment")]
        public IActionResult GetMonthlyAppointmentReport(DateTime fromDate, DateTime toDate)
        {
            var AppointmentReport = _ctx.appointments
                .Where(s => s.AppointmentDate >= fromDate && s.AppointmentDate <= toDate)
                .ToList();

            return Ok(AppointmentReport);
        }

        [HttpGet("monthly-Appointment2")]
        public IActionResult GetMonthlyAppointmentReport2(DateTime fromDate, DateTime toDate)
        {
            var appointmentReport = _ctx.appointments
                .Where(s => s.AppointmentDate >= fromDate && s.AppointmentDate <= toDate)
                .Join(
                    _ctx.users,
                    appointments => appointments.UserId,
                    users => users.UserId,
                    (appointments, users) => new
                    {
                        Appointment = appointments,
                        User = users
                    }
                )
                .Select(result => new
                {
                    AppointmentId = result.Appointment.AppointmentId,
                    AppointmentDate = result.Appointment.AppointmentDate,
                    Title = result.Appointment.Title,


                    UserId = result.User.UserId,
                    UserName = result.User.UserName,

                })
                .ToList();

            return Ok(appointmentReport);
        }

        [HttpGet("GetUserDetailsByAppointmentId")]
        public IActionResult GetUserDetailsByAppointmentId(int appointmentId)
        {
              var appointmentWithUser = _ctx.appointments
             .Where(appointment => appointment.AppointmentId == appointmentId)
             .Join(
                 _ctx.users,
                appointment => appointment.UserId,
                user => user.UserId,
             (appointment, user) => new
             {
               Appointment = appointment,
               User = user
             })
             .Select(result => new
             {
                 AppointmentId = result.Appointment.AppointmentId,
                 Title = result.Appointment.Title,
                 AppointmentDate= result.Appointment.AppointmentDate,
                 UserId = result.User.UserId,
                 UserName = result.User.UserName,
                 UserEmail=result.User.UserEmail,
                 UserPhoneNumber= result.User.UserPhoneNumber,
                 UserAddress= result.User.UserAddress
             })
             .FirstOrDefault();
           
            return Ok(appointmentWithUser);
        }
        
    }
}
