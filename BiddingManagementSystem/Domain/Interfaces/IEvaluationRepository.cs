using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Domain.Interfaces
{
    public interface IEvaluationRepository
    {
        Task<Evaluation> GetByIdAsync(int id);
        Task<IEnumerable<Evaluation>> GetAllAsync();
        Task AddAsync(Evaluation evaluation);
        Task UpdateAsync(Evaluation evaluation);
        Task DeleteAsync(int id);
    }
}
