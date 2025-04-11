using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class TenderDocumentService : ITenderDocumentService
    {
        private readonly ITenderDocumentRepository _tenderDocumentRepository;

        public TenderDocumentService(ITenderDocumentRepository tenderDocumentRepository)
        {
            _tenderDocumentRepository = tenderDocumentRepository;
        }

        public async Task<TenderDocumentDTO> GetTenderDocumentByIdAsync(int id)
        {
            var tenderDocument = await _tenderDocumentRepository.GetByIdAsync(id);
            return tenderDocument == null ? null : MapToDTO(tenderDocument);
        }

        public async Task<IEnumerable<TenderDocumentDTO>> GetAllTenderDocumentsAsync()
        {
            var tenderDocuments = await _tenderDocumentRepository.GetAllAsync();
            return tenderDocuments.Select(MapToDTO);
        }

        public async Task AddTenderDocumentAsync(TenderDocumentDTO tenderDocumentDTO)
        {
            var tenderDocument = MapToEntity(tenderDocumentDTO);
            await _tenderDocumentRepository.AddAsync(tenderDocument);
            tenderDocumentDTO.Id = tenderDocument.Id;
        }

        public async Task UpdateTenderDocumentAsync(TenderDocumentDTO tenderDocumentDTO)
        {
            var existingTenderDocument = await _tenderDocumentRepository.GetByIdAsync(tenderDocumentDTO.Id);
            if (existingTenderDocument != null)
            {
                var updatedTenderDocument = MapToEntity(tenderDocumentDTO, existingTenderDocument);
                await _tenderDocumentRepository.UpdateAsync(updatedTenderDocument);
            }
        }

        public async Task DeleteTenderDocumentAsync(int id)
        {
            await _tenderDocumentRepository.DeleteAsync(id);
        }

        private TenderDocumentDTO MapToDTO(TenderDocument tenderDocument)
        {
            return new TenderDocumentDTO
            {
                Id = tenderDocument.Id,
                TenderId = tenderDocument.TenderId,
                FilePath = tenderDocument.FilePath,
                UploadedAt = tenderDocument.UploadedAt,
                FileName = tenderDocument.FileName
            };
        }

        private TenderDocument MapToEntity(TenderDocumentDTO tenderDocumentDTO, TenderDocument existingTenderDocument = null)
        {
            var tenderDocument = existingTenderDocument ?? new TenderDocument();
            tenderDocument.TenderId = tenderDocumentDTO.TenderId;
            tenderDocument.FilePath = tenderDocumentDTO.FilePath;
            tenderDocument.UploadedAt = tenderDocumentDTO.UploadedAt;
            tenderDocument.FileName = tenderDocumentDTO.FileName;
            return tenderDocument;
        }
    }

}
