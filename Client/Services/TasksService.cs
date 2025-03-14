using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public class TasksService : ITasksService
    {
        private readonly HttpClient _httpClient;

        public TasksService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Tasks>>("api/Tasks");
        }

        public async Task<Tasks> GetTaskByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<Tasks>($"api/Tasks/{id}");
        }

        public async Task<Tasks> AddTaskAsync(Tasks task)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Tasks", task);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Tasks>();
        }

        public async Task<Tasks> UpdateTaskAsync(Tasks task)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Tasks/{task.Id}", task);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Tasks>();
        }

        public async Task<bool> DeleteTaskAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Tasks/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}