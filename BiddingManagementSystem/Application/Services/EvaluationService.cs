using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class EvaluationService : IEvaluationService
    {
        private readonly IEvaluationRepository _evaluationRepository;

        public EvaluationService(IEvaluationRepository evaluationRepository)
        {
            _evaluationRepository = evaluationRepository;
        }

        public async Task<EvaluationDTO> GetEvaluationByIdAsync(int id)
        {
            var evaluation = await _evaluationRepository.GetByIdAsync(id);
            return evaluation == null ? null : MapToDTO(evaluation);
        }

        public async Task<IEnumerable<EvaluationDTO>> GetAllEvaluationsAsync()
        {
            var evaluations = await _evaluationRepository.GetAllAsync();
            return evaluations.Select(MapToDTO);
        }

        public async Task AddEvaluationAsync(EvaluationDTO evaluationDTO)
        {
            var evaluation = MapToEntity(evaluationDTO);
            await _evaluationRepository.AddAsync(evaluation);
            evaluationDTO.Id = evaluation.Id;
        }

        public async Task UpdateEvaluationAsync(EvaluationDTO evaluationDTO)
        {
            var existingEvaluation = await _evaluationRepository.GetByIdAsync(evaluationDTO.Id);
            if (existingEvaluation != null)
            {
                var updatedEvaluation = MapToEntity(evaluationDTO, existingEvaluation);
                await _evaluationRepository.UpdateAsync(updatedEvaluation);
            }
        }

        public async Task DeleteEvaluationAsync(int id)
        {
            await _evaluationRepository.DeleteAsync(id);
        }

        private EvaluationDTO MapToDTO(Evaluation evaluation)
        {
            return new EvaluationDTO
            {
                Id = evaluation.Id,
                BidId = evaluation.BidId,
                EvaluatorId = evaluation.EvaluatorId,
                Score = evaluation.Score,
                Comments = evaluation.Comments
            };
        }

        private Evaluation MapToEntity(EvaluationDTO evaluationDTO, Evaluation existingEvaluation = null)
        {
            var evaluation = existingEvaluation ?? new Evaluation();
            evaluation.BidId = evaluationDTO.BidId;
            evaluation.EvaluatorId = evaluationDTO.EvaluatorId;
            evaluation.Score = evaluationDTO.Score;
            evaluation.Comments = evaluationDTO.Comments;
            return evaluation;
        }
    }
}
