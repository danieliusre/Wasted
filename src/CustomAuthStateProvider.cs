using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using Wasted.Data;

namespace Wasted
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }
        public void markUserAsAuthenticated(string emailAddress)
        {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, emailAddress),
                }, "Fake authentication type");

                var user = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged (Task.FromResult(new AuthenticationState(user)));
        }
    }
}