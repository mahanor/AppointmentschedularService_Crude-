using System.ComponentModel.DataAnnotations;

namespace AppointmentschedularService.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserAddress { get; set; }

        
    }
}
