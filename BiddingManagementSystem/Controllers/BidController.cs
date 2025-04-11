using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Bidder")]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBid(int id)
        {
            var bid = await _bidService.GetBidByIdAsync(id);
            if (bid == null)
            {
                return NotFound();
            }
            return Ok(bid);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBids()
        {
            var bids = await _bidService.GetAllBidsAsync();
            return Ok(bids);
        }

        [HttpPost]
        public async Task<IActionResult> AddBid(BidDTO bidDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bidService.AddBidAsync(bidDTO);
            return CreatedAtAction(nameof(GetBid), new { id = bidDTO.Id }, bidDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBid(int id, BidDTO bidDTO)
        {
            if (id != bidDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _bidService.UpdateBidAsync(bidDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBid(int id)
        {
            await _bidService.DeleteBidAsync(id);
            return NoContent();
        }
    }
}
