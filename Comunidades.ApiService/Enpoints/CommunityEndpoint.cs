using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Enpoints
{
    public static class CommunityEndpoint
    {
        public static void UseCommunityEndpoints(this WebApplication app)
        {
            app.MapPost("/api/v1/community/create", Create)
                .WithGroupName("Community")
                .RequireAuthorization();
        }

        private static async Task<IResult> Create(
            ICommunityService communityService,
            [FromBody] CommunityCreatePostRequest request)
        {
            var result = await communityService.CreateAsync(request);
            return result.ToResult();
        }
    }
}
