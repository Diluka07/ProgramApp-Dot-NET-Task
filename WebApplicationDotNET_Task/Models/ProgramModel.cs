using Newtonsoft.Json;

namespace WebApplicationDotNET_Task.Models
{
    public class ProgramModel
    {
        [JsonProperty("id")]
        public required string Id { get; set; }
        [JsonProperty("programId")]
        public required string ProgramId { get; set; }
        [JsonProperty("programTitle")]
        public required string ProgramTitle { get; set; }
        [JsonProperty("programDescription")]
        public required string ProgramDescription { get; set; }
        [JsonProperty("personalInformationQuestions")]
        public required List<QuestionModel> PersonalInformationQuestions { get; set; }
        [JsonProperty("additionalQuestions")]
        public required List<QuestionModel> AdditionalQuestions { get; set; }
    }
}
