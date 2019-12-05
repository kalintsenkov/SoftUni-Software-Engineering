namespace VaporStore.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
    {
        public void Configure(EntityTypeBuilder<Purchase> purchase)
        {
            purchase
                .HasOne(p => p.Card)
                .WithMany(c => c.Purchases)
                .HasForeignKey(p => p.CardId);

            purchase
                .HasOne(p => p.Game)
                .WithMany(g => g.Purchases)
                .HasForeignKey(p => p.GameId);
        }
    }
}
