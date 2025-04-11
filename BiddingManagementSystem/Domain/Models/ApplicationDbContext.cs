using Microsoft.EntityFrameworkCore;

namespace BiddingManagementSystem.Domain.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<TenderDocument> TenderDocuments { get; set; }
        public DbSet<BidDocument> BidDocuments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tender>()
                .HasOne(t => t.ProcurementOfficer)
                .WithMany(u => u.Tenders)
                .HasForeignKey(t => t.ProcurementOfficerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Tender)
                .WithMany(t => t.Bids)
                .HasForeignKey(b => b.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Bid>()
                .HasOne(b => b.Bidder)
                .WithMany(u => u.Bids)
                .HasForeignKey(b => b.BidderId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Bid>()
                .HasMany(b => b.Evaluations) 
                .WithOne(e => e.Bid)      
                .HasForeignKey(e => e.BidId) 
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evaluation>()
                .HasOne(e => e.Evaluator)
                .WithMany(u => u.Evaluations)
                .HasForeignKey(e => e.EvaluatorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TenderDocument>()
                .HasOne(td => td.Tender)
                .WithMany(t => t.TenderDocuments)
                .HasForeignKey(td => td.TenderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BidDocument>()
                .HasOne(bd => bd.Bid)
                .WithMany(b => b.BidDocuments)
                .HasForeignKey(bd => bd.BidId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Bid>()
                .Property(b => b.Amount)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Tender>()
                .Property(t => t.Budget)
                .HasColumnType("decimal(18, 2)");
        }


    }
}
