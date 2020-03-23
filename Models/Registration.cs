using System.ComponentModel.DataAnnotations;

namespace LearnAspNetCoreMvc.Models {
    public class Registration {
        [Required]
        [EmailAddress, MaxLength (200)]
        [Display (Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType (DataType.Password)]
        public string Password { get; set; }

        [Compare ("Password", ErrorMessage = "Passwords must match")]
        [Display (Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}