using Microsoft.AspNetCore.Mvc;
using WebApplicationDotNET_Task.Models;
using WebApplicationDotNET_Task.Services;

namespace WebApplicationDotNET_Task.Controllers
{
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly IApplicationService applicationService;

        public ApiController(IApplicationService applicationService)
        {
            this.applicationService = applicationService;
        }

        [HttpPost]
        [Route("program")]
        public async Task<IActionResult> CreateProgram([FromBody] ProgramModel program)
        {
            try
            {
                await applicationService.CreatePogramApplication(program);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        [Route("response")]
        public async Task<IActionResult> CreateResponse([FromBody] CandidateResponseModel candidateResponseModel)
        {
            try
            {
                await applicationService.CreateApplicationResponse(candidateResponseModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
