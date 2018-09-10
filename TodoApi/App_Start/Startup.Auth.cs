using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using TodoApi.Providers;

namespace TodoApi
{
    public partial class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions {get; private set;}

        public Startup()
        {
            OAuthOptions = new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthAppProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(5),
                AllowInsecureHttp = true
            };
        }

        public void ConfigureAuth(IAppBuilder app)
        {
            app.UseOAuthBearerTokens(OAuthOptions);
        }
    }
}
