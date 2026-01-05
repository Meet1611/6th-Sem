using System.ComponentModel.DataAnnotations;

namespace EventRegistrationAPI.DTOs
{
    public class CreateEventRegistrationDto
    {
        [Required, MaxLength(100)]
        public string ParticipantName { get; set; }

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }

        [Required, MaxLength(100)]
        public string EventName { get; set; }

        public int Age { get; set; }
    }
}
