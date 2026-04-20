using AssetIQ.Models.Domain;

namespace AssetIQ.Repositories.Interfaces
{
    public interface IAssetRepository
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task AddAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(int id);
    }
}