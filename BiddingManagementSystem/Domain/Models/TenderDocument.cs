﻿namespace BiddingManagementSystem.Domain.Models
{
    public class TenderDocument
    {
        public int Id { get; set; }
        public int TenderId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }
        public string FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public Tender Tender { get; set; }
    }
}
