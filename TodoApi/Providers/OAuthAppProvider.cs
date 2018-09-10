using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TodoApi.Code;
using TodoApi.Service;

namespace TodoApi.Providers
{
    public class OAuthAppProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            if (context.ClientId == null)
            {
                context.Validated();
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            return Task.Factory.StartNew(() => 
            {
                var userName = context.UserName;
                var userPassword = context.Password;
                var userService = new UserService();

                var user = userService.GetUserByCredentials(userName, userPassword);
                if (user != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name, user.Name),
                        new Claim("UserID", user.Id.ToString()),
                    };

                    var OAuthIdentity = new ClaimsIdentity(claims, Startup.OAuthOptions.AuthenticationType);
                    context.Validated(new AuthenticationTicket(OAuthIdentity, new AuthenticationProperties() {}));
                } 
                else context.SetError("invalid_grant", "Error");
            });
        }
    }
}
