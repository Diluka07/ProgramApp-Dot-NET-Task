using Newtonsoft.Json;
using WebApplicationDotNET_Task.Enums;

namespace WebApplicationDotNET_Task.Models
{
    public class QuestionModel
    {
        [JsonProperty("questionId")]
        public required string QuestionId { get; set; }
        [JsonProperty("questionTitle")]
        public required string QuestionTitle { get; set; }
        [JsonProperty("questionType")]
        public required QuestionType QuestionType { get; set; }
        [JsonProperty("mandatory")]
        public required bool Mandatory { get; set; } = false;
        [JsonProperty("internal")]
        public required bool Internal { get; set; } = false;
        [JsonProperty("hide")]
        public required bool Hide { get; set; } = false;
        [JsonProperty("multipleChoiceOptions")]
        public List<string>? MultipleChoiceOptions { get; set; }
    }
}
