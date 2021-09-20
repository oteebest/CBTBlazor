using CBTBlazor.Models.Request;
using CBTBlazor.Models.Response;
using CBTBlazor.Models;
using CBTBlazor.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public class AssessmentService : IAssessmentService
    {
        private  HttpClient _httpClient;

        public AssessmentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AssessmentResponseModel> CreateAssessment(AssessmentRequestModel model)
        {

            var response = await _httpClient.PostAsJsonAsync("api/v1/assessment", model);


            return  JsonConvert.DeserializeObject<AssessmentResponseModel>(
                            await response.Content.ReadAsStringAsync());

        }

        public async Task DeleteAssesment(string id)
        {
            var response =  await _httpClient.DeleteAsync($"api/v1/assessment/{id}");

        }

        public async Task<AssessmentListResponseModel> GetAssesments()
        {
            var response = await _httpClient.GetAsync($"api/v1/assessment");

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<AssessmentListResponseModel>(responseString);

            return data;
        }

        public async Task<AssessmentResponseModel> GetAssesments(string id)
        {
            var response = await _httpClient.GetAsync($"api/v1/assessment/{id}");

            return  JsonConvert.DeserializeObject<AssessmentResponseModel> (
                            await response.Content.ReadAsStringAsync());
        }

        public async Task<AssessmentResponseModel> UpdateAssessment(string Id, AssessmentRequestModel model)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/v1/assessment/{Id}", model);

            return  JsonConvert.DeserializeObject<AssessmentResponseModel>(
                            await response.Content.ReadAsStringAsync());

        }

    }
}
