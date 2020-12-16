namespace ApplicantAPI.App.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ApplicantController : ControllerBase
    {
        [HttpGet]
        [Route("applicants")]
        public IActionResult GetAllRegistaredApplicants()
        {
            return StatusCode(200); // Ok
        }
    }
}
