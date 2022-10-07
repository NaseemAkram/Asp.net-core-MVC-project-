using System.ComponentModel.DataAnnotations;

namespace Rsvpproject.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "please enter your name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "please enter your email address")]

        public string Email { get; set; }
        [Required(ErrorMessage = "please enter a phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "please specify wether you will attend ")]
        public bool? WillAttend { get; set; }
    }
}
