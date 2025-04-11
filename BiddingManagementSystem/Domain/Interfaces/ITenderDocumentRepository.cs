using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface ITenderDocumentRepository
    {
        Task<TenderDocument> GetByIdAsync(int id);
        Task<IEnumerable<TenderDocument>> GetAllAsync();
        Task AddAsync(TenderDocument tenderDocument);
        Task UpdateAsync(TenderDocument tenderDocument);
        Task DeleteAsync(int id);

    }
}
