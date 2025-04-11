using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface ITenderDocumentService
    {
        Task<TenderDocumentDTO> GetTenderDocumentByIdAsync(int id);
        Task<IEnumerable<TenderDocumentDTO>> GetAllTenderDocumentsAsync();
        Task AddTenderDocumentAsync(TenderDocumentDTO tenderDocumentDTO);
        Task UpdateTenderDocumentAsync(TenderDocumentDTO tenderDocumentDTO);
        Task DeleteTenderDocumentAsync(int id);
    }
}
