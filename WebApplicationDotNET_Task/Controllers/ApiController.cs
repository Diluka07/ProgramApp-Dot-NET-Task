using Microsoft.AspNetCore.Mvc;
using WebApplicationDotNET_Task.Enums;
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
                await applicationService.CreatePogramApplicationAsync(program);
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
                await applicationService.CreateApplicationResponseAsync(candidateResponseModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("updatequestion")]
        public async Task<IActionResult> UpdateQuestion([FromBody] QuestionUpdateModel questionUpdateModel)
        {
            try
            {
                await applicationService.UpdateQuestionAsync(questionUpdateModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("questionbytype")]
        public async Task<IActionResult> GetQuestionsByType([FromQuery] string programId, QuestionType questionType)
        {
            try
            {
                var res = await applicationService.GetQuestionByQuestionType(programId, questionType);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
