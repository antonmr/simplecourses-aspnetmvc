using System.ComponentModel.DataAnnotations;

namespace SimpleCourses.Models
{
    public class RegistrationModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "User Name")]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        //[RegularExpression("pattern")]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [Required]
        //[RegularExpression("pattern")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public bool AcceptUserAgreement { get; set; }
        public string? RegistrationInvalid {  get; set; }

    }
}
