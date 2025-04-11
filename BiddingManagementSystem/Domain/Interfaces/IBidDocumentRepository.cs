using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface IBidDocumentRepository
    {
        Task<BidDocument> GetByIdAsync(int id);
        Task<IEnumerable<BidDocument>> GetAllAsync();
        Task AddAsync(BidDocument bidDocument);
        Task UpdateAsync(BidDocument bidDocument);
        Task DeleteAsync(int id);
    }
}
