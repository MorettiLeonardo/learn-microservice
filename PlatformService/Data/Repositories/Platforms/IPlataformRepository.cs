using PlatformService.Models;

namespace PlatformService.Data.Repositories.Platforms
{
    public interface IPlataformRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Platform>> GetAllPlatforms();
        Task<Platform?> GetPlatformById(int id);
        Task CreatePlatform(Platform platform);
    }
}