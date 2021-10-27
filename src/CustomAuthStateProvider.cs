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
        public void markUserAsAuthenticated(string emailAddress, string role)
        {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, emailAddress),
                    new Claim(ClaimTypes.Role, role)
                }, "adminAuth");

                var user = new ClaimsPrincipal(identity);

                NotifyAuthenticationStateChanged (Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            var anonymousUser = new ClaimsPrincipal(new ClaimsIdentity());
            var authState = Task.FromResult(new AuthenticationState(anonymousUser));
            NotifyAuthenticationStateChanged(authState);
        }
    }
}