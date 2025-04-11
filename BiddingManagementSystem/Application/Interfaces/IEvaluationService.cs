using BiddingManagementSystem.Application.DTOs;

namespace BiddingManagementSystem.Application.Interfaces
{
    public interface IEvaluationService
    {
        Task<EvaluationDTO> GetEvaluationByIdAsync(int id);
        Task<IEnumerable<EvaluationDTO>> GetAllEvaluationsAsync();
        Task AddEvaluationAsync(EvaluationDTO evaluationDTO);
        Task UpdateEvaluationAsync(EvaluationDTO evaluationDTO);
        Task DeleteEvaluationAsync(int id);
    }
}
