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
        Task LoginAsync(LoginViewModel model);
    }
}
