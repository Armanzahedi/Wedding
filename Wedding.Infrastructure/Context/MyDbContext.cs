using Wedding.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wedding.Infrastructure.Context
{
    public class MyDbContext : IdentityDbContext<User>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        #region Models
        public DbSet<SystemParameter> SystemParameters { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<NavigationMenu> NavigationMenu { get; set; }
        public DbSet<RoleMenuPermission> RoleMenuPermission { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleTag> ArticleTags { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ArticleComment> ArticleComments { get; set; }
        public DbSet<ContactUsForm> ContactUsForms { get; set; }
        public DbSet<GeoDivision> GeoDivisions { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdContact> AdContacts { get; set; }
        public DbSet<AdFaq> AdFaqs { get; set; }
        public DbSet<AdGallery> AdGalleries { get; set; }
        public DbSet<AdPurchaseHistory> AdPurchaseHistory { get; set; }
        public DbSet<AdRating> AdRatings { get; set; }
        public DbSet<AdReview> AdReviews { get; set; }
        public DbSet<AdTag> AdTags { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletTransaction> WalletTransactions { get; set; }
        public DbSet<PaymentAccount> PaymentAccounts { get; set; }
        public DbSet<Payment> Payments{ get; set; }
        public DbSet<WithdrawalRequest> WithdrawalRequests { get; set; }
        public DbSet<Invoice> Invoices { get; set; }


        #endregion



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleMenuPermission>()
            .HasKey(c => new { c.RoleId, c.NavigationMenuId });

            modelBuilder.Entity<ArticleTag>()
            .HasKey(c => new { c.ArticleId, c.TagId });

            modelBuilder.Entity<AdTag>()
            .HasKey(c => new { c.AdId, c.TagId });


            //modelBuilder.Entity<WithdrawalRequest>()
            //    .HasOne<WalletTransaction>(s => s.WalletTransaction)
            //    .WithOne(ad => ad.WithdrawalRequest)
            //    .HasForeignKey<WalletTransaction>(ad => ad.WithdrawalRequestId)
            //    .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WalletTransaction>()
                .HasOne<WithdrawalRequest>(s => s.WithdrawalRequest)
                .WithOne(ad => ad.WalletTransaction)
                .HasForeignKey<WithdrawalRequest>(ad => ad.WalletTransactionId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdPurchaseHistory>()
                .HasOne(e => e.Invoice)
                .WithMany()
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
