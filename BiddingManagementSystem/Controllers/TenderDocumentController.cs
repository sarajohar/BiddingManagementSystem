using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ProcurementOfficer")]
    public class TenderDocumentController : ControllerBase
    {
        private readonly ITenderDocumentService _tenderDocumentService;

        public TenderDocumentController(ITenderDocumentService tenderDocumentService)
        {
            _tenderDocumentService = tenderDocumentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTenderDocument(int id)
        {
            var tenderDocument = await _tenderDocumentService.GetTenderDocumentByIdAsync(id);
            if (tenderDocument == null)
            {
                return NotFound();
            }
            return Ok(tenderDocument);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTenderDocuments()
        {
            var tenderDocuments = await _tenderDocumentService.GetAllTenderDocumentsAsync();
            return Ok(tenderDocuments);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadTenderDocument(TenderDocumentDTO tenderDocumentDTO)
        {
            await _tenderDocumentService.AddTenderDocumentAsync(tenderDocumentDTO);
            return CreatedAtAction(nameof(GetTenderDocument), new { id = tenderDocumentDTO.Id }, tenderDocumentDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTenderDocument(int id, TenderDocumentDTO tenderDocumentDTO)
        {
            if (id != tenderDocumentDTO.Id)
            {
                return BadRequest();
            }

            await _tenderDocumentService.UpdateTenderDocumentAsync(tenderDocumentDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTenderDocument(int id)
        {
            await _tenderDocumentService.DeleteTenderDocumentAsync(id);
            return NoContent();
        }
    }
}
