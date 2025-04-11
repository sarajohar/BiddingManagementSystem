using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class EvaluationRepository : IEvaluationRepository
    {
        private readonly ApplicationDbContext _context;

        public EvaluationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Evaluation> GetByIdAsync(int id)
        {
            return await _context.Evaluations.FindAsync(id);
        }

        public async Task<IEnumerable<Evaluation>> GetAllAsync()
        {
            return await _context.Evaluations.ToListAsync();
        }

        public async Task AddAsync(Evaluation evaluation)
        {
            _context.Evaluations.Add(evaluation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Evaluation evaluation)
        {
            _context.Entry(evaluation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var evaluation = await _context.Evaluations.FindAsync(id);
            if (evaluation != null)
            {
                _context.Evaluations.Remove(evaluation);
                await _context.SaveChangesAsync();
            }
        }
    }
}
