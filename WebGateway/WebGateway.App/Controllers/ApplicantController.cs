namespace WebGateway.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebGateway.NetworkServices.Interfaces;

    [ApiController]
    [Route("covid")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService applicantService;

        public ApplicantController(IApplicantService applicantService)
        {
            this.applicantService = applicantService;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegisterNewInfected()
        {
            return StatusCode(200); // Ok   
        }
    }
}
