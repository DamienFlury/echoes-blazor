using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Echoes.Shared;

namespace Echoes.Client.Services
{
    public interface ILoginService
    {
        string Token { get; }
        Task<bool> LoginFromLocalStorageAsync();
        Task<bool> LoginAsync(LoginViewModel model);
        bool IsLoggedIn { get; }
    }
}
