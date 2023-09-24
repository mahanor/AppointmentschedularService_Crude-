using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentschedularService.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public string Title { get; set; }
        
        public DateTime AppointmentDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}

        [ForeignKey("User")]
        public int UserId { get; set; }


    }
}
