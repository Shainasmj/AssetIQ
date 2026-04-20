using AssetIQ.Models.Domain;
using AssetIQ.Repositories.Interfaces;
using AssetIQ.Services.Interfaces;

namespace AssetIQ.Services.Implementations
{
    public class AssetService : IAssetService
    {
        private readonly IAssetRepository _assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            _assetRepository = assetRepository;
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await _assetRepository.GetAllAsync();
        }

        public async Task<Asset?> GetByIdAsync(int id)
        {
            return await _assetRepository.GetByIdAsync(id);
        }

        public async Task CreateAsync(Asset asset)
        {
            await _assetRepository.AddAsync(asset);
        }

        public async Task UpdateAsync(Asset asset)
        {
            await _assetRepository.UpdateAsync(asset);
        }

        public async Task DeleteAsync(int id)
        {
            await _assetRepository.DeleteAsync(id);
        }
    }
}