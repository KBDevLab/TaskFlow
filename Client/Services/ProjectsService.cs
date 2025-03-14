using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly HttpClient _httpClient;

        public ProjectsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Projects>> GetAllProjectsAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Projects>>("api/Projects");
        }

        public async Task<Projects> GetProjectByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<Projects>($"api/Projects/{id}");
        }

        public async Task<Projects> AddProjectAsync(Projects project)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Projects", project);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Projects>();
        }

        public async Task<Projects> UpdateProjectAsync(Projects project)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Projects/{project.Id}", project);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Projects>();
        }

        public async Task<bool> DeleteProjectAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Projects/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}