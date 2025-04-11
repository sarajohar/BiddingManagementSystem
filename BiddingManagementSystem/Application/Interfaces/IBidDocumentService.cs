using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IBidDocumentService
    {
        Task<BidDocumentDTO> GetBidDocumentByIdAsync(int id);
        Task<IEnumerable<BidDocumentDTO>> GetAllBidDocumentsAsync();
        Task AddBidDocumentAsync(BidDocumentDTO bidDocumentDTO);
        Task UpdateBidDocumentAsync(BidDocumentDTO bidDocumentDTO);
        Task DeleteBidDocumentAsync(int id);
    }
}
