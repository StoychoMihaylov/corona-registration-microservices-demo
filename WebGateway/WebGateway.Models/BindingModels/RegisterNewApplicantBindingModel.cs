namespace WebGateway.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterNewApplicantBindingModel
    {
        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public int Age { get; set; }

        [MaxLength(500)]
        public string Symptoms { get; set; }
    }
}
