namespace ApplicantAPI.Models.BindingModels
{
    public class RegisterNewApplicantBindingModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }

        public string Symptoms { get; set; }
    }
}
