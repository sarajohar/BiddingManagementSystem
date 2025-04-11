using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class BidDocumentRepository : IBidDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public BidDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BidDocument> GetByIdAsync(int id)
        {
            return await _context.BidDocuments.FindAsync(id);
        }

        public async Task<IEnumerable<BidDocument>> GetAllAsync()
        {
            return await _context.BidDocuments.ToListAsync();
        }

        public async Task AddAsync(BidDocument bidDocument)
        {
            _context.BidDocuments.Add(bidDocument);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BidDocument bidDocument)
        {
            _context.Entry(bidDocument).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bidDocument = await _context.BidDocuments.FindAsync(id);
            if (bidDocument != null)
            {
                _context.BidDocuments.Remove(bidDocument);
                await _context.SaveChangesAsync();
            }
        }
    }
}
