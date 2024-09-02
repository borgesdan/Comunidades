namespace Comunidades.ApiService.Services.Interfaces
{
    public interface IUserLoginRegistryService
    {
        Task<IServiceResult> CreateAsync(int userId);
    }
}
