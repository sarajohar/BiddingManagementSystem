using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "ProcurementOfficer")]
    public class TenderController : ControllerBase
    {
        private readonly ITenderService _tenderService;

        public TenderController(ITenderService tenderService)
        {
            _tenderService = tenderService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTender(int id)
        {
            var tender = await _tenderService.GetTenderByIdAsync(id);
            if (tender == null)
            {
                return NotFound();
            }
            return Ok(tender);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTenders()
        {
            var tenders = await _tenderService.GetAllTendersAsync();
            return Ok(tenders);
        }

        [HttpPost]
        public async Task<IActionResult> AddTender(TenderDTO tenderDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tenderService.AddTenderAsync(tenderDTO);
            return CreatedAtAction(nameof(GetTender), new { id = tenderDTO.Id }, tenderDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTender(int id, TenderDTO tenderDTO)
        {
            if (id != tenderDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tenderService.UpdateTenderAsync(tenderDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTender(int id)
        {
            await _tenderService.DeleteTenderAsync(id);
            return NoContent();
        }
    }
}
