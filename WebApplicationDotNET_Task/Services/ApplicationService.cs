using Microsoft.Azure.Cosmos;
using System.ComponentModel;
using WebApplicationDotNET_Task.Enums;
using WebApplicationDotNET_Task.Models;

namespace WebApplicationDotNET_Task.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly CosmosClient cosmosClient;
        private readonly IConfiguration configuration;
        private readonly Microsoft.Azure.Cosmos.Container _programContainer;
        private readonly Microsoft.Azure.Cosmos.Container _candidateResponseContainer;

        public ApplicationService(CosmosClient cosmosClient, IConfiguration configuration)
        {
            this.cosmosClient = cosmosClient;
            this.configuration = configuration;
            var databaseId = configuration["CosmosDbSettings:DatabaseId"];
            var programContainerName = "programs";
            var candidateResponseContainerName = "candidateResponses";
            _programContainer = cosmosClient.GetContainer(databaseId, programContainerName);
            _candidateResponseContainer = cosmosClient.GetContainer(databaseId, candidateResponseContainerName);
        }

        public async Task CreateApplicationResponseAsync(CandidateResponseModel candidateResponseModel)
        {
            try
            {
                await _candidateResponseContainer.CreateItemAsync(candidateResponseModel);
            }
            catch
            {
                throw;
            }
        }

        public async Task CreatePogramApplicationAsync(ProgramModel program)
        {
            try
            {
                await _programContainer.CreateItemAsync(program);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<QuestionModel>> GetQuestionByQuestionType(string programId, QuestionType questionType)
        {
            try
            {
                var additionalQuestionsQuery = _programContainer.GetItemQueryIterator<QuestionModel>(
                    new QueryDefinition("SELECT q.questionId, q.questionTitle, q.questionType, q.mandatory, q.internalQ, q.hide, q.multipleChoiceOptions FROM c JOIN q IN c.additionalQuestions WHERE c.programId = @programId AND q.questionType = @questionType")
                        .WithParameter("@programId", programId)
                        .WithParameter("@questionType", questionType));

                var additionalQuestionsWithType = new List<QuestionModel>();
                while (additionalQuestionsQuery.HasMoreResults)
                {
                    var response = await additionalQuestionsQuery.ReadNextAsync();
                    additionalQuestionsWithType.AddRange(response.ToList());
                }

                return additionalQuestionsWithType;
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateQuestionAsync(QuestionUpdateModel questionUpdateModel)
        {
            try
            {
                var response = await _programContainer.ReadItemAsync<dynamic>(questionUpdateModel.Id.ToString(), new PartitionKey(questionUpdateModel.ProgramId.ToString()));
                dynamic document = response.Resource;

                foreach (var question in questionUpdateModel.QuestionReigon == Enums.QuestionReigon.personalInfoQuestions ? document.personalInformationQuestions : document.additionalQuestions)
                {
                    if (question.questionId == questionUpdateModel.QuestionId)
                    {
                        if(questionUpdateModel.PropertyName == "questionTitle")
                        {
                            question.questionTitle = questionUpdateModel.NewValueString;
                        }
                        else if(questionUpdateModel.PropertyName == "mandatory")
                        {
                            question.mandatory = questionUpdateModel.NewValueBool;
                        }
                        else if(questionUpdateModel.PropertyName == "internal")
                        {
                            question.mandatory = questionUpdateModel.NewValueBool;
                        }
                        else if (questionUpdateModel.PropertyName == "hide")
                        {
                            question.mandatory = questionUpdateModel.NewValueBool;
                        }
                        else if(questionUpdateModel.PropertyName == "multipleChoiceOptions")
                        {
                            question.multipleChoiceOptions = questionUpdateModel.NewValueOptions;
                        }
                    }
                }
                await _programContainer.ReplaceItemAsync(document, document.id.ToString(), new PartitionKey(document.programId.ToString()));
            }
            catch
            {
                throw;
            }
        }
    }
}
