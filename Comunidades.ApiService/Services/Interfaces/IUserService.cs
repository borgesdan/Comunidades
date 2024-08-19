using Comunidades.ApiService.Models.Requests;

namespace Comunidades.ApiService.Services.Interfaces
{
    public interface IUserService
    {
        Task<IServiceResult> CreateAsync(UserCreatePostRequest request);
        Task<IServiceResult> LoginAsync(UserLoginPostRequest request);
    }
}
