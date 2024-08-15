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
            app.MapPost("/api/v1/user/create", Create);
        }

        private static async Task<IResult> Create(
            IUserService userService,
            [FromBody] UserCreatePostRequest request)
        {
            var result = await userService.Create(request);
            return result.ToResult();
        }
    }
}
