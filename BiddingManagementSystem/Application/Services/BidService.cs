using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _bidRepository;

        public BidService(IBidRepository bidRepository)
        {
            _bidRepository = bidRepository;
        }

        public async Task<BidDTO> GetBidByIdAsync(int id)
        {
            var bid = await _bidRepository.GetByIdAsync(id);
            return bid == null ? null : MapToDTO(bid);
        }

        public async Task<IEnumerable<BidDTO>> GetAllBidsAsync()
        {
            var bids = await _bidRepository.GetAllAsync();
            return bids.Select(MapToDTO);
        }

        public async Task AddBidAsync(BidDTO bidDTO)
        {
            var bid = MapToEntity(bidDTO);
            await _bidRepository.AddAsync(bid);
            bidDTO.Id = bid.Id;
        }

        public async Task UpdateBidAsync(BidDTO bidDTO)
        {
            var existingBid = await _bidRepository.GetByIdAsync(bidDTO.Id);
            if (existingBid != null)
            {
                var updatedBid = MapToEntity(bidDTO, existingBid);
                await _bidRepository.UpdateAsync(updatedBid);
            }
        }

        public async Task DeleteBidAsync(int id)
        {
            await _bidRepository.DeleteAsync(id);
        }

        private BidDTO MapToDTO(Bid bid)
        {
            return new BidDTO
            {
                Id = bid.Id,
                TenderId = bid.TenderId,
                BidderId = bid.BidderId,
                Amount = bid.Amount,
                Status = bid.Status
            };
        }

        private Bid MapToEntity(BidDTO bidDTO, Bid existingBid = null)
        {
            var bid = existingBid ?? new Bid();
            bid.TenderId = bidDTO.TenderId;
            bid.BidderId = bidDTO.BidderId;
            bid.Amount = bidDTO.Amount;
            bid.Status = bidDTO.Status;
            return bid;
        }
    }


}
