using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Echoes.Shared;
using Microsoft.AspNetCore.Blazor;

namespace Echoes.Client.Services
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _http;

        public LoginService(HttpClient http)
        {
            _http = http;
        }

        public string Token { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public async Task LoginAsync(LoginViewModel model)
        {
            try
            {
                var response = await _http.PostJsonAsync<TokenResult>("/api/auth", model);
                Token = response.Token;
                ExpireDate = response.ExpireDate;
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            }
            catch (Exception)
            {
                Console.WriteLine("Error :(");
            }
        }
    }
}
