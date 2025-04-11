using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class TenderRepository : ITenderRepository
    {
        private readonly ApplicationDbContext _context;

        public TenderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Tender> GetByIdAsync(int id)
        {
            return await _context.Tenders.FindAsync(id);
        }

        public async Task<IEnumerable<Tender>> GetAllAsync()
        {
            return await _context.Tenders.ToListAsync();
        }

        public async Task AddAsync(Tender tender)
        {
            _context.Tenders.Add(tender);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Tender tender)
        {
            _context.Entry(tender).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tender = await _context.Tenders.FindAsync(id);
            if (tender != null)
            {
                _context.Tenders.Remove(tender);
                await _context.SaveChangesAsync();
            }
        }
    }
}
