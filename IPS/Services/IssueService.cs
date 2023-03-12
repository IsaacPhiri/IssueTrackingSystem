using ITS.Domain.Models;
using ITS.Domain.Services;
using ITS.Pages;
using System.Net.Http.Json;

namespace ITS.Services
{  
    internal class IssueService : IIssueService
    {
        HttpClient httpClient;
        public IssueService(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<bool> Add(Issue model)
        {
            var response = await httpClient.PostAsJsonAsync("issue", model);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"issue/{id}");
            return response.IsSuccessStatusCode;

        }

        public async Task<Issue> Get(int id)
        {
            var response = await httpClient.GetFromJsonAsync<Issue>($"issue/{id}");
            return response;
        }

        public async Task<IEnumerable<Issue>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<Issue>>($"issue");
        }

        public async Task<bool> Update(Issue model)
        {
            var response = await httpClient.PutAsJsonAsync($"issue", model);
            return response.IsSuccessStatusCode;
        }
    }
}
