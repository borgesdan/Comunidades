using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Enpoints
{
    public static class UserEndpoint
    {
        public static void UseUserEndpoints(this WebApplication app) 
        {
            app.MapPost("/api/v1/user/create", Create)
                .WithGroupName("User");

            app.MapPost("/api/v1/user/login", Login)
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
