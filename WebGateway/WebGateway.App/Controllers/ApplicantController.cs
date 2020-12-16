namespace WebGateway.App.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebGateway.Messaging.Interfaces;
    using WebGateway.Models.BindingModels;
    using WebGateway.NetworkServices.Interfaces;

    [ApiController]
    [Route("applicant")]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService applicantService;
        private readonly IApplicantBusService applicantBusService;

        public ApplicantController(IApplicantService applicantService, IApplicantBusService applicantBusService)
        {
            this.applicantService = applicantService;
            this.applicantBusService = applicantBusService;
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> RegisterNewInfectedApplicant([FromBody] RegisterNewApplicantBindingModel bm)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Model state is not valid");
            }

            this.applicantBusService.MessageApplicantAPI_RegisterNewApplicant(bm);

            return StatusCode(202); // Accepted
        }
    }
}
