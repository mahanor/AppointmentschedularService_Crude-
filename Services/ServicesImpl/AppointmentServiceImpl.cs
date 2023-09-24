using AppointmentschedularService.Models;
using AppointmentschedularService.Repository.IRepository;
using AppointmentschedularService.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AppointmentschedularService.Services.ServicesImpl
{
    public class AppointmentServiceImpl : IAppointmentService
    {
        private readonly IRepository _IRepo;
        public AppointmentServiceImpl(IRepository IRepo) 
        {
            _IRepo = IRepo;
        }
        public Appointment CreateAppointment(Appointment appointment)
        {
            var CreatedAppointment = _IRepo.CreateAppointment(appointment);
            return CreatedAppointment;
        }

       

        public Appointment GetApointmentById(int id)
        {
            return _IRepo.GetApointmentById(id);
        }

        public bool UpdateAppointment(int id, Appointment updateAppointment)
        {
            User userUpdated = new User();
            var UpdatedAppointment = _IRepo.GetApointmentById(id);

            if (UpdatedAppointment == null)
            {
                return false;
            }

            UpdatedAppointment.Title = updateAppointment.Title;
          
            UpdatedAppointment.AppointmentDate = updateAppointment.AppointmentDate;
            UpdatedAppointment.LastUpdatedDate = updateAppointment.LastUpdatedDate;
            

           
            _IRepo.UpdateAppointment(UpdatedAppointment);

            return true;
        }

        public bool DeleteAppointment(int id)
        {
            var existingAppointment = _IRepo.GetApointmentById(id);

            if (existingAppointment == null)
            {
                return false;
            }

            _IRepo.DeleteAppointment(existingAppointment);

            return true;
        }

        public void Dispose()
        {
            _IRepo?.Dispose();
        }
    }
}
