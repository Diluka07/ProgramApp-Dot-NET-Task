using Newtonsoft.Json;
using WebApplicationDotNET_Task.Enums;

namespace WebApplicationDotNET_Task.Models
{
    public class QuestionUpdateModel
    {
        [JsonProperty("id")]
        public required string Id { get; set; }
        [JsonProperty("programId")]
        public required string ProgramId { get; set; }
        [JsonProperty("questionId")]
        public required string QuestionId { get; set; }
        [JsonProperty("questionReigon")]
        public QuestionReigon QuestionReigon { get; set; }
        [JsonProperty("propertyName")]
        public required string PropertyName { get; set; }
        [JsonProperty("questionType")]
        public string? NewValueString { get; set; }
        [JsonProperty("newValueNum")]
        public string? NewValueNum { get; set; }
        [JsonProperty("newValueDate")]
        public DateTime? NewValueDate { get; set; }
        [JsonProperty("newValueOptions")]
        public List<string>? NewValueOptions { get; set; }
        [JsonProperty("newValueBool")]
        public bool NewValueBool { get; set; }
    }
}
