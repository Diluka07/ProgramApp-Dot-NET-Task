using WebApplicationDotNET_Task.Models;

namespace WebApplicationDotNET_Task.Services
{
    public interface IApplicationService
    {
        Task CreatePogramApplicationAsync(ProgramModel program);
        Task CreateApplicationResponseAsync(CandidateResponseModel candidateResponseModel);
        Task UpdateQuestionAsync(QuestionUpdateModel questionUpdateModel);
    }
}
