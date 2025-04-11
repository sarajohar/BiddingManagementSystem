using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface IBidRepository
    {
        Task<Bid> GetByIdAsync(int id);
        Task<IEnumerable<Bid>> GetAllAsync();
        Task AddAsync(Bid bid);
        Task UpdateAsync(Bid bid);
        Task DeleteAsync(int id);
    }
}
