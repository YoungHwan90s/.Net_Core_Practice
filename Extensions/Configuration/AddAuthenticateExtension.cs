using Microsoft.AspNetCore.Authentication.Cookies;

namespace RunNetCoreWeb.Extensions.Configuration
{
    public static class AddAuthenticateExtension
    {
        public static void AddAuthenticateService(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                // General User
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.Cookie.Name = "User";
                })
                // Super User Or Admin
                .AddCookie("SuperUser", options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                    options.Cookie.Name = "SuperUser";
                });
        }
    }
}