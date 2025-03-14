using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly HttpClient _httpClient;

        public CommentsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Comments>> GetCommentsByTaskIdAsync(long taskId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Comments>>($"api/Comments/task/{taskId}");
        }

        public async Task<Comments> GetCommentByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<Comments>($"api/Comments/{id}");
        }

        public async Task<Comments> AddCommentAsync(Comments comment)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Comments", comment);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Comments>();
        }

        public async Task<Comments> UpdateCommentAsync(Comments comment)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Comments/{comment.Id}", comment);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Comments>();
        }

        public async Task<bool> DeleteCommentAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Comments/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}