using AssetIQ.Data;
using AssetIQ.Models.Domain;
using AssetIQ.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AssetIQ.Repositories.Implementations
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _context;

        public AssetRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _context.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _context.Assets.FindAsync(id);
        }

        public async Task AddAsync(Asset asset)
        {
            await _context.Assets.AddAsync(asset);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Asset asset)
        {
            _context.Assets.Update(asset);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var asset = await _context.Assets.FindAsync(id);
            if (asset != null)
            {
                _context.Assets.Remove(asset);
                await _context.SaveChangesAsync();
            }
        }
    }
}