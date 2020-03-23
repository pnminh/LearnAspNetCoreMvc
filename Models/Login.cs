using System.ComponentModel.DataAnnotations;

namespace LearnAspNetCoreMvc.Models
{
    public class Login
    {
        [Required]
        [EmailAddress, MaxLength(200)]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}