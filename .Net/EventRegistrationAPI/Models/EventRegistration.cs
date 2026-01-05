using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI.Models
{
    public class EventRegistration
    {
        [Required, Key]
        public int RegistrationId { get; set; }

        [Required, MaxLength(100)]
        public string ParticipantName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string EventName { get; set; }

        public int Age { get; set; }

        [Required]
        public DateTime RegistrationDate { get; set; }
    }
}
