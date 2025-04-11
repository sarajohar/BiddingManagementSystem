namespace BiddingManagementSystem.Application.DTOs
{
    public class TenderDocumentDTO
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string FileName { get; set; }
    }
}
