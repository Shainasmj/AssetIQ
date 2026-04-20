using AssetIQ.Models.Domain;

namespace AssetIQ.Services.Interfaces
{
    public interface IAssetService
    {
        Task<IEnumerable<Asset>> GetAllAsync();
        Task<Asset?> GetByIdAsync(int id);
        Task CreateAsync(Asset asset);
        Task UpdateAsync(Asset asset);
        Task DeleteAsync(int id);
    }
}