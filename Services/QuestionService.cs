using CBTBlazor.Models.Request;
using CBTBlazor.Models.Response;
using CBTBlazor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

   

        public async Task<QuestionListResponseModel> GetQuestions(int pageSize = 10, int pageNumber = 1, string subjectId = "", string difficultyLevelId = "")
        {
            var response = await _httpClient.GetFromJsonAsync<QuestionListResponseModel>($"api/v1/question?pageSize={pageSize}&pageNumber={pageNumber}&subjectId={subjectId}&difficultyLevelId={difficultyLevelId}");

            return response;
        }

        public async Task<ResponseModelBase> UpdateQuestion(string Id, QuestionRequestModel model)
        {

            var response = await _httpClient.PutAsJsonAsync($"api/v1/question/{Id}", model);

            return JsonConvert.DeserializeObject<ResponseModelBase>(await response.Content.ReadAsStringAsync());

        }

        public async Task<ResponseModelBase> CreateQuestion(QuestionRequestModel model)
        {
                       
            var response = await _httpClient.PostAsJsonAsync("api/v1/question", model);

            return JsonConvert.DeserializeObject<ResponseModelBase>(await response.Content.ReadAsStringAsync());

        }

        public async Task<QuestionResponseModel> GetQuestion(string Id)
        {
            var response = await _httpClient.GetFromJsonAsync<QuestionResponseModel>($"api/v1/question/{Id}");

            return response;
        }
    }
}
