using System.ComponentModel.DataAnnotations;

namespace ReactMVC.Models
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string UserEmail { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Your password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string UserPassword { get; set; }
    }
}
