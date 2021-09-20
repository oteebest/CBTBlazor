using CBTBlazor.Models.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CBTBlazor.Services
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PredefinedDataResponseModel> GetPredefinedData()
        {
            var response = await _httpClient.GetAsync($"api/v1/data");

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<PredefinedDataResponseModel>(responseString);

            return data;
        }
    }
}
