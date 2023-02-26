using ITS.Domain.Models;
using ITS.Domain.Services;
using ITS.Pages;
using System.Net.Http.Json;

namespace ITS.Services
{
    internal class DepartmentService : IDepartmentService
    {
        HttpClient httpClient;
        public DepartmentService(HttpClient _httpClient)
        { 
            httpClient = _httpClient;
        }

        public async Task<bool> Add(Department model)
        {
            var response = await httpClient.PostAsJsonAsync("department", model);
            return response.IsSuccessStatusCode;           
        }

        public async Task<bool> Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"department/{id}");
            return  response.IsSuccessStatusCode;      
            
        }

        public async Task<Department> Get(int id)
        {
            var response = await httpClient.GetFromJsonAsync<Department>($"department/{id}");
            return response;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
           return  await httpClient.GetFromJsonAsync<List<Department>>($"department");
        }

        public async Task<bool> Update(Department model)
        {
            var response = await httpClient.PutAsJsonAsync($"department", model);
            return response.IsSuccessStatusCode;
        }
    }
}
