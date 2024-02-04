using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authentication;
namespace BlazorApp4;

public static class AuthenticationExtensions
{
    public static WebApplication SetupEndpoints(this WebApplication app)
    {
        app.MapGet("/Account/Login", async (HttpContext httpContext, string returnUrl = "/") =>
        {
            await httpContext.ChallengeAsync(OpenIdConnectDefaults.AuthenticationScheme,
                new AuthenticationProperties
                {
                    RedirectUri = !string.IsNullOrEmpty(returnUrl) ? returnUrl : "/"
                });
        });

        app.MapPost("/Account/Logout", async (HttpContext httpContext) =>
        {
            var authenticationProperties = new AuthenticationProperties
            {
                RedirectUri = "/SignedOut"
            };
            if (httpContext.Request.Cookies.Count > 0)
            {
                var siteCookies = httpContext
                    .Request
                    .Cookies
                    .Where(c => c.Key.Contains(".AspNetCore.") 
                        || c.Key.Contains("Microsoft.Authentication"));

                foreach (var cookie in siteCookies)
                {
                    httpContext.Response.Cookies.Delete(cookie.Key);
                }
            }

            await httpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme, 
                authenticationProperties);

            await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

        }).RequireAuthorization();

        return app;
    }
}