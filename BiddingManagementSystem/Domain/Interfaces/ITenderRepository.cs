using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface ITenderRepository
    {
        Task<Tender> GetByIdAsync(int id);
        Task<IEnumerable<Tender>> GetAllAsync();
        Task AddAsync(Tender tender);
        Task UpdateAsync(Tender tender);
        Task DeleteAsync(int id);
    }
}
