using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Bidder")]
    public class BidDocumentController : ControllerBase
    {
        private readonly IBidDocumentService _bidDocumentService;

        public BidDocumentController(IBidDocumentService bidDocumentService)
        {
            _bidDocumentService = bidDocumentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBidDocument(int id)
        {
            var bidDocument = await _bidDocumentService.GetBidDocumentByIdAsync(id);
            if (bidDocument == null)
            {
                return NotFound();
            }
            return Ok(bidDocument);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBidDocuments()
        {
            var bidDocuments = await _bidDocumentService.GetAllBidDocumentsAsync();
            return Ok(bidDocuments);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadBidDocument(BidDocumentDTO bidDocumentDTO)
        {
            await _bidDocumentService.AddBidDocumentAsync(bidDocumentDTO);
            return CreatedAtAction(nameof(GetBidDocument), new { id = bidDocumentDTO.Id }, bidDocumentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBidDocument(int id, BidDocumentDTO bidDocumentDTO)
        {
            if (id != bidDocumentDTO.Id)
            {
                return BadRequest();
            }

            await _bidDocumentService.UpdateBidDocumentAsync(bidDocumentDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBidDocument(int id)
        {
            await _bidDocumentService.DeleteBidDocumentAsync(id);
            return NoContent();
        }
    }
}
