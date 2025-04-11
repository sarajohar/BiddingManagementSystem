using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class TenderDocumentRepository : ITenderDocumentRepository
    {
        private readonly ApplicationDbContext _context;

        public TenderDocumentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TenderDocument> GetByIdAsync(int id)
        {
            return await _context.TenderDocuments.FindAsync(id);
        }

        public async Task<IEnumerable<TenderDocument>> GetAllAsync()
        {
            return await _context.TenderDocuments.ToListAsync();
        }

        public async Task AddAsync(TenderDocument tenderDocument)
        {
            _context.TenderDocuments.Add(tenderDocument);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TenderDocument tenderDocument)
        {
            _context.Entry(tenderDocument).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var tenderDocument = await _context.TenderDocuments.FindAsync(id);
            if (tenderDocument != null)
            {
                _context.TenderDocuments.Remove(tenderDocument);
                await _context.SaveChangesAsync();
            }
        }
    }
}
