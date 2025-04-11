namespace BiddingManagementSystem.Application.DTOs
{
    public class BidDocumentDTO
    {
        public int Id { get; set; }
        public int BidId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string FileName { get; set; }
    }
}
