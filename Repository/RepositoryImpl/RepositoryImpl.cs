using AppointmentschedularService.Data;
using AppointmentschedularService.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AppointmentschedularService.Repository.RepositoryImpl
{
    public class RepositoryImpl : IRepository.IRepository
    {
        private readonly DataContext _ctx;
        public RepositoryImpl(DataContext ctx)
        {
            _ctx = ctx;
        }
        public User InsertUser(User user)
        {
            try
            {
                _ctx.users.Add(user);
                _ctx.SaveChanges();
                
            }
            
            catch (Exception ex)
            {

            }
            return user;

        }

        public bool UpdateUser(User updatedUser)
        {
            _ctx.users.Update(updatedUser);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteUser(User deleteUser)
        {
            _ctx.users.Remove(deleteUser);
            _ctx.SaveChanges();
            return true;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            users= _ctx.users.ToList();
            return users;
        }

        public User GetUserById(int id)
        {
            return _ctx.users.FirstOrDefault(u => u.UserId== id);
        }

        public Appointment CreateAppointment(Appointment appointment)
        {
            try
            {
                _ctx.appointments.Add(appointment);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
            }
            
            return appointment;
        }

        public Appointment GetApointmentById(int id)
        {
            return _ctx.appointments.FirstOrDefault(appoint => appoint.AppointmentId == id);
        }

        public bool UpdateAppointment(Appointment updatedAppointment)
        {
            _ctx.appointments.Update(updatedAppointment);
            _ctx.SaveChanges();
            return true;
        }

        public bool DeleteAppointment(Appointment appointment)
        {
            _ctx.appointments.Remove(appointment);
            _ctx.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            _ctx?.Dispose();
        }
    }
}
