using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace eShop.Web
{
    public static class AuthenticationEndpoints
    {
        public static IEndpointRouteBuilder MapAuthenticationEndpoints(this IEndpointRouteBuilder app)
        {
            // Endpoint to process Login POST from Login Form
            app.MapPost("/login", async (HttpContext httpContext, [FromForm] string? username, [FromForm] string? password, [FromForm] string? returnUrl) =>
            {
                var userToSignIn = string.IsNullOrWhiteSpace(username) ? "admin" : username;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userToSignIn),
                    new Claim(ClaimTypes.Email, $"{userToSignIn}@eshop.com"),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
                {
                    return Results.Redirect(returnUrl);
                }

                return Results.Redirect("/admin");
            }).DisableAntiforgery();

            // Direct GET login helper endpoint
            app.MapGet("/auth/login", async (HttpContext httpContext, string? username, string? returnUrl) =>
            {
                var userToSignIn = string.IsNullOrWhiteSpace(username) ? "admin" : username;

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userToSignIn),
                    new Claim(ClaimTypes.Email, $"{userToSignIn}@eshop.com"),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await httpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                if (!string.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
                {
                    return Results.Redirect(returnUrl);
                }

                return Results.Redirect("/admin");
            });

            // Logout GET and POST endpoints
            app.MapGet("/logout", async (HttpContext httpContext) =>
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Redirect("/");
            });

            app.MapPost("/logout", async (HttpContext httpContext) =>
            {
                await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Redirect("/");
            }).DisableAntiforgery();

            return app;
        }

        private static bool IsLocalUrl(string url)
        {
            return !string.IsNullOrEmpty(url) && (url.StartsWith("/") && !url.StartsWith("//") && !url.StartsWith("/\\"));
        }
    }
}
