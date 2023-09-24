using AppointmentschedularService.Models;

namespace AppointmentschedularService.Services.IServices
{
    public interface IUserService : IDisposable
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User InsertUser(User user);
        bool UpdateUser(int id, User updatedUser);
        bool DeleteUser(int id);
    }
}
