using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Infrastructure.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly ApplicationDbContext _context;

        public BidRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bid> GetByIdAsync(int id)
        {
            return await _context.Bids.FindAsync(id);
        }

        public async Task<IEnumerable<Bid>> GetAllAsync()
        {
            return await _context.Bids.ToListAsync();
        }

        public async Task AddAsync(Bid bid)
        {
            _context.Bids.Add(bid);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Bid bid)
        {
            _context.Entry(bid).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var bid = await _context.Bids.FindAsync(id);
            if (bid != null)
            {
                _context.Bids.Remove(bid);
                await _context.SaveChangesAsync();
            }
        }
    }
}
