using AppointmentschedularService.Models;

namespace AppointmentschedularService.Services.IServices
{
    public interface IAppointmentService:IDisposable
    {
        Appointment CreateAppointment(Appointment appointment);
        bool DeleteAppointment(int id);
        Appointment GetApointmentById(int id);
        bool UpdateAppointment(int id, Appointment updatedAppointment);
    }
}
