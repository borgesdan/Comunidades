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
            app.MapPost("/api/user/create", Create);
        }

        private static async Task<IResult> Create(
            UserService userService,
            [FromBody] UserCreateRequest request)
        {
            var result = await userService.Create(request);
            return result.ToResult();
        }
    }
}
