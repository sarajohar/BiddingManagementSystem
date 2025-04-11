using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface ITenderService
    {
        Task<TenderDTO> GetTenderByIdAsync(int id);
        Task<IEnumerable<TenderDTO>> GetAllTendersAsync();
        Task AddTenderAsync(TenderDTO tenderDTO);
        Task UpdateTenderAsync(TenderDTO tenderDTO);
        Task DeleteTenderAsync(int id);
    }
}
