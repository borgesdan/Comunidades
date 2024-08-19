using Comunidades.ApiService.Models.Requests;

namespace Comunidades.ApiService.Services.Interfaces
{
    public interface ICommunityService
    {
        Task<IServiceResult> CreateAsync(CommunityCreatePostRequest request);
    }
}
