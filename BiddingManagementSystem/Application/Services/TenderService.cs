using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class TenderService : ITenderService
    {
        private readonly ITenderRepository _tenderRepository;

        public TenderService(ITenderRepository tenderRepository)
        {
            _tenderRepository = tenderRepository;
        }

        public async Task<TenderDTO> GetTenderByIdAsync(int id)
        {
            var tender = await _tenderRepository.GetByIdAsync(id);
            return tender == null ? null : MapToDTO(tender);
        }

        public async Task<IEnumerable<TenderDTO>> GetAllTendersAsync()
        {
            var tenders = await _tenderRepository.GetAllAsync();
            return tenders.Select(MapToDTO);
        }

        public async Task AddTenderAsync(TenderDTO tenderDTO)
        {
            var tender = MapToEntity(tenderDTO);
            await _tenderRepository.AddAsync(tender);
            tenderDTO.Id = tender.Id;
        }

        public async Task UpdateTenderAsync(TenderDTO tenderDTO)
        {
            var existingTender = await _tenderRepository.GetByIdAsync(tenderDTO.Id);
            if (existingTender != null)
            {
                var updatedTender = MapToEntity(tenderDTO, existingTender);
                await _tenderRepository.UpdateAsync(updatedTender);
            }
        }

        public async Task DeleteTenderAsync(int id)
        {
            await _tenderRepository.DeleteAsync(id);
        }

        private TenderDTO MapToDTO(Tender tender)
        {
            return new TenderDTO
            {
                Id = tender.Id,
                Title = tender.Title,
                Description = tender.Description,
                Deadline = tender.Deadline,
                Budget = tender.Budget,
                Category = tender.Category,
                ProcurementOfficerId = tender.ProcurementOfficerId,
                IssueDate = tender.IssueDate,
                TenderType = tender.TenderType,
                Location = tender.Location,
                ContactEmail = tender.ContactEmail
            };
        }

        private Tender MapToEntity(TenderDTO tenderDTO, Tender existingTender = null)
        {
            var tender = existingTender ?? new Tender();
            tender.Title = tenderDTO.Title;
            tender.Description = tenderDTO.Description;
            tender.Deadline = tenderDTO.Deadline;
            tender.Budget = tenderDTO.Budget;
            tender.Category = tenderDTO.Category;
            tender.ProcurementOfficerId = tenderDTO.ProcurementOfficerId;
            tender.IssueDate = tenderDTO.IssueDate;
            tender.TenderType = tenderDTO.TenderType;
            tender.Location = tenderDTO.Location;
            tender.ContactEmail = tenderDTO.ContactEmail;
            return tender;
        }
    }
}
