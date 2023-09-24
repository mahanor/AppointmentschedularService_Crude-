using AppointmentschedularService.Models;

namespace AppointmentschedularService.Repository.IRepository
{
    public interface IRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User InsertUser(User user);
        bool UpdateUser(User updatedUser);
        bool DeleteUser(User deleteUser);
        Appointment CreateAppointment(Appointment appointment);
        Appointment GetApointmentById(int id);
        bool UpdateAppointment(Appointment updatedAppointment);
        bool DeleteAppointment(Appointment appointment);
        void Dispose();
        //User DeleteAppointmentById(int id);
    }
}
