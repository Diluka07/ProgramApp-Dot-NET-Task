using Newtonsoft.Json;
using WebApplicationDotNET_Task.Enums;

namespace WebApplicationDotNET_Task.Models
{
    public class QuestionResponse
    {
        [JsonProperty("questionId")]
        public required int QuestionId { get; set; }
        [JsonProperty("questionTitle")]
        public required string QuestionTitle { get; set; }
        [JsonProperty("questionType")]
        public required QuestionType QuestionType { get; set; }
        [JsonProperty("paragraphResponse")]
        public string? ParagraphResponse { get; set; }
        [JsonProperty("numericResponse")]
        public int NumericResponse { get; set; }
        [JsonProperty("multipleChoiceResponse")]
        public  List<string>? MultipleChoiceResponse { get; set; }
        [JsonProperty("yesNoResponse")]
        public bool YesNoResponse { get; set; }
    }
}
