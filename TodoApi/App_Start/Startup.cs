
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Owin;

namespace TodoApi
{
    public partial class Startup
    {
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddMvc();
            //services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/login"))
                .AddFacebook(o =>
                {
                    o.AppId = "appid";
                    o.AppSecret = "secret";
                })
                .AddGoogle(o =>
                {
                    o.ClientId  = "appid";
                    o.ClientSecret  = "secret";
                });

                //AddExternal
                /*
                .AddOAuth("GitHub", options =>
        {
            options.ClientId = Configuration["GitHub:ClientId"];
            options.ClientSecret = Configuration["GitHub:ClientSecret"];
            options.CallbackPath = new PathString("/signin-github");

            options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
            options.TokenEndpoint = "https://github.com/login/oauth/access_token";
            options.UserInformationEndpoint = "https://api.github.com/user";

            options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "id");
            options.ClaimActions.MapJsonKey(ClaimTypes.Name, "name");
            options.ClaimActions.MapJsonKey("urn:github:login", "login");
            options.ClaimActions.MapJsonKey("urn:github:url", "html_url");
            options.ClaimActions.MapJsonKey("urn:github:avatar", "avatar_url");

            options.Events = new OAuthEvents
            {
                OnCreatingTicket = async context =>
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                    var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                    response.EnsureSuccessStatusCode();

                    var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                    context.RunClaimActions(user);
                }
            };
        });
                 */
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            app.UseAuthentication();
            app.UseMvc();

            app.Run(async (context) => 
            {
                await context.Response.WriteAsync("Started");
            });
        }
    }
}
