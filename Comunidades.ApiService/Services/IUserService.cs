using Comunidades.ApiService.Models.Requests;

namespace Comunidades.ApiService.Services
{
    public interface IUserService
    {
        Task<IServiceResult> Create(UserCreatePostRequest request);
    }
}
