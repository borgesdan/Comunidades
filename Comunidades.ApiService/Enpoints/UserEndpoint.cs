using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Enpoints
{
    public static class UserEndpoint
    {
        private static readonly string source = "/api/v1/user/";

        public static void UseUserEndpoints(this WebApplication app) 
        {
            app.MapPost(source, Create)
                .WithGroupName("User");

            app.MapPost(Path.Combine(source, "login"), Login)
                .WithGroupName("User")
                .WithSummary("Executa login do usuário");

        }

        private static async Task<IResult> Create(IUserService userService, [FromBody] UserCreatePostRequest request)
        {
            var result = await userService.CreateAsync(request);
            return result.ToResult();
        }

        private static async Task<IResult> Login(IUserService userService, [FromBody]UserLoginPostRequest request)
        {
            var result = await userService.LoginAsync(request);
            return result.ToResult();
        }        
    }
}
