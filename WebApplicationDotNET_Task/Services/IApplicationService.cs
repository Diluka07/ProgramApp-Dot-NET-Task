using WebApplicationDotNET_Task.Models;

namespace WebApplicationDotNET_Task.Services
{
    public interface IApplicationService
    {
        Task CreatePogramApplication(ProgramModel program);
        Task CreateApplicationResponse(CandidateResponseModel candidateResponseModel);
    }
}
