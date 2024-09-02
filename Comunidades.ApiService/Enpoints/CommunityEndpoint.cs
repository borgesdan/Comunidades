using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Comunidades.ApiService.Enpoints
{
    public static class CommunityEndpoint
    {
        private static readonly string source = "/api/v1/community";

        public static void UseCommunityEndpoints(this WebApplication app)
        {
            app.MapPost(source, Create)
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
