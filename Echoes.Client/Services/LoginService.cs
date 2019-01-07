using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Echoes.Shared;
using Microsoft.AspNetCore.Blazor;
using Blazor.Extensions.Storage;

namespace Echoes.Client.Services
{
    public class LoginService
    {
        private readonly HttpClient _http;
        private readonly LocalStorage _localStorage;

        public LoginService(HttpClient http, LocalStorage localStorage) => (_http, _localStorage) = (http, localStorage);

        public event Action OnChange;

        public string Token { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public bool IsLoggedIn => !string.IsNullOrEmpty(Token);

        public async Task<bool> LoginFromLocalStorageAsync()
        {
            var token = await _localStorage.GetItem<string>("token");
            if (token is null) return false;
            Token = token;
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            OnChange?.Invoke();
            return true;
        }

        public async Task<bool> LoginAsync(LoginViewModel model)
        {
            try
            {
                var response = await _http.PostJsonAsync<TokenResult>("/api/auth", model);
                Token = response.Token;
                ExpireDate = response.ExpireDate;
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                await _localStorage.SetItem("token", Token);
                OnChange?.Invoke();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task LogoutAsync()
        {
            Token = "";
            await _localStorage.SetItem("token", "");
        }
    }
}
