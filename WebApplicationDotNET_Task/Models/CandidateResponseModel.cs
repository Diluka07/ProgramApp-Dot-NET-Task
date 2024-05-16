using Newtonsoft.Json;

namespace WebApplicationDotNET_Task.Models
{
    public class CandidateResponseModel
    {
        [JsonProperty("id")]
        public required string Id { get; set; }
        [JsonProperty("programId")]
        public required string ProgramId { get; set; }
        public required List<QuestionResponse> PersonalInformationQuestionsResponse { get; set; }
        public List<QuestionResponse>? AdditionalQuestionsResponse { get; set; }
    }
}
