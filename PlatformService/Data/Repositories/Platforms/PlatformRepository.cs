using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data.Repositories.Platforms
{
    public class PlatformRepository(AppDbContext context) : IPlataformRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreatePlatform(Platform platform)
        {
            await _context.AddAsync(platform);
        }

        public async Task<IEnumerable<Platform>> GetAllPlatforms()
        {
            return await _context.Platforms
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Platform?> GetPlatformById(int id)
        {
            return await _context.Platforms.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}