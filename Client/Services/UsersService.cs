using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaskFlow.Shared.Models;

namespace TaskFlow.Client.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _httpClient;

        public UsersService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Users>> GetAllUsersAsync()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Users>>("api/Users");
        }

        public async Task<Users> GetUserByIdAsync(long id)
        {
            return await _httpClient.GetFromJsonAsync<Users>($"api/Users/{id}");
        }

        public async Task<Users> AddUserAsync(Users user)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Users", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Users>();
        }

        public async Task<Users> UpdateUserAsync(Users user)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/Users/{user.Id}", user);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Users>();
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            var response = await _httpClient.DeleteAsync($"api/Users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}