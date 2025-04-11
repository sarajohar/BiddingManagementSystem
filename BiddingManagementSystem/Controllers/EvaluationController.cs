using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiddingManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Evaluator")]
    public class EvaluationController : ControllerBase
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvaluation(int id)
        {
            var evaluation = await _evaluationService.GetEvaluationByIdAsync(id);
            if (evaluation == null)
            {
                return NotFound();
            }
            return Ok(evaluation);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvaluations()
        {
            var evaluations = await _evaluationService.GetAllEvaluationsAsync();
            return Ok(evaluations);
        }

        [HttpPost]
        public async Task<IActionResult> AddEvaluation(EvaluationDTO evaluationDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _evaluationService.AddEvaluationAsync(evaluationDTO);
            return CreatedAtAction(nameof(GetEvaluation), new { id = evaluationDTO.Id }, evaluationDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvaluation(int id, EvaluationDTO evaluationDTO)
        {
            if (id != evaluationDTO.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _evaluationService.UpdateEvaluationAsync(evaluationDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvaluation(int id)
        {
            await _evaluationService.DeleteEvaluationAsync(id);
            return NoContent();
        }
    }
}
