namespace ApplicantAPI.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Applicant
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(20)]
        public string FirstName { get; set; }

        [MaxLength(20)]
        public string LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public int Age { get; set; }

        [MaxLength(500)]
        public string Syndromes { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
