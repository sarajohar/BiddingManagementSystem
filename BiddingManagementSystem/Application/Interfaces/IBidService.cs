using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IBidService
    {
        Task<BidDTO> GetBidByIdAsync(int id);
        Task<IEnumerable<BidDTO>> GetAllBidsAsync();
        Task AddBidAsync(BidDTO bidDTO);
        Task UpdateBidAsync(BidDTO bidDTO);
        Task DeleteBidAsync(int id);
    }
}
