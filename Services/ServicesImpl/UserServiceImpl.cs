using AppointmentschedularService.Data;
using AppointmentschedularService.Models;
using AppointmentschedularService.Repository.IRepository;
using AppointmentschedularService.Services.IServices;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace AppointmentschedularService.Services.ServicesImpl
{
    public class UserServiceImpl : IUserService
    {
        private readonly IRepository _IRepo;
        private bool disposedValue;

        public UserServiceImpl(IRepository IRepo)
        {
            _IRepo = IRepo;
        }
        public User InsertUser(User user)
        {
            var createdUser = _IRepo.InsertUser(user);
            return createdUser;
        }

        public bool UpdateUser(int id, User updatedUser)
        {
            User userUpdated = new User();
            var existingUser = _IRepo.GetUserById(id);

            if (existingUser == null)
            {
                return false;
            }

            existingUser.UserName = updatedUser.UserName;
            existingUser.UserEmail = updatedUser.UserEmail;
            existingUser.UserPhoneNumber = updatedUser.UserPhoneNumber;
            existingUser.UserPassword = updatedUser.UserPassword;
            existingUser.UserAddress = updatedUser.UserAddress;

            _IRepo.UpdateUser(existingUser);

            return true;
        }

        public bool DeleteUser(int id)
        {
            var existingUser = _IRepo.GetUserById(id);

            if (existingUser == null)
            {
                return false; 
            }
            
            _IRepo.DeleteUser(existingUser);

            return true;
        }

        public List<User> GetAllUsers()
        {
            return _IRepo.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            
             return _IRepo.GetUserById(id);
            
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~UserServiceImpl()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
