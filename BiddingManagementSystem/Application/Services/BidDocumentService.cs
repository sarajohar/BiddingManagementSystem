using BiddingManagementSystem.Application.DTOs;
using BiddingManagementSystem.Application.Interfaces;
using BiddingManagementSystem.Domain.Interfaces;
using BiddingManagementSystem.Domain.Models;

namespace BiddingManagementSystem.Application.Services
{
    public class BidDocumentService : IBidDocumentService
    {
        private readonly IBidDocumentRepository _bidDocumentRepository;

        public BidDocumentService(IBidDocumentRepository bidDocumentRepository)
        {
            _bidDocumentRepository = bidDocumentRepository;
        }

        public async Task<BidDocumentDTO> GetBidDocumentByIdAsync(int id)
        {
            var bidDocument = await _bidDocumentRepository.GetByIdAsync(id);
            return bidDocument == null ? null : MapToDTO(bidDocument);
        }

        public async Task<IEnumerable<BidDocumentDTO>> GetAllBidDocumentsAsync()
        {
            var bidDocuments = await _bidDocumentRepository.GetAllAsync();
            return bidDocuments.Select(MapToDTO);
        }

        public async Task AddBidDocumentAsync(BidDocumentDTO bidDocumentDTO)
        {
            var bidDocument = MapToEntity(bidDocumentDTO);
            await _bidDocumentRepository.AddAsync(bidDocument);
            bidDocumentDTO.Id = bidDocument.Id;
        }

        public async Task UpdateBidDocumentAsync(BidDocumentDTO bidDocumentDTO)
        {
            var existingBidDocument = await _bidDocumentRepository.GetByIdAsync(bidDocumentDTO.Id);
            if (existingBidDocument != null)
            {
                var updatedBidDocument = MapToEntity(bidDocumentDTO, existingBidDocument);
                await _bidDocumentRepository.UpdateAsync(updatedBidDocument);
            }
        }

        public async Task DeleteBidDocumentAsync(int id)
        {
            await _bidDocumentRepository.DeleteAsync(id);
        }

        private BidDocumentDTO MapToDTO(BidDocument bidDocument)
        {
            return new BidDocumentDTO
            {
                Id = bidDocument.Id,
                BidId = bidDocument.BidId,
                FilePath = bidDocument.FilePath,
                UploadedAt = bidDocument.UploadedAt,
                FileName = bidDocument.FileName
            };
        }

        private BidDocument MapToEntity(BidDocumentDTO bidDocumentDTO, BidDocument existingBidDocument = null)
        {
            var bidDocument = existingBidDocument ?? new BidDocument();
            bidDocument.BidId = bidDocumentDTO.BidId;
            bidDocument.FilePath = bidDocumentDTO.FilePath;
            bidDocument.UploadedAt = bidDocumentDTO.UploadedAt;
            bidDocument.FileName = bidDocumentDTO.FileName;
            return bidDocument;
        }
    }
}
