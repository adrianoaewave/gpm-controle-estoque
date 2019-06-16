using ControleEstoque.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Data.Mappings
{
    public class ItemProductMap : IEntityTypeConfiguration<ItemProduct>
    {
        public void Configure(EntityTypeBuilder<ItemProduct> builder)
        {
            builder.ToTable("tb_itens_produtos");

            builder.Property(c => c.IdItem)
                .HasColumnName("id_item")
                .IsRequired();

            builder.Property(c => c.IdProduct)
                .HasColumnName("id_produto")
                .IsRequired();

            builder.HasKey(x => new { x.IdItem, x.IdProduct });

            builder.Property(c => c.ItemProductQuantity)
                .HasColumnName("qt_item_produto")
                .IsRequired();

            builder.HasOne(c => c.Product)
                .WithMany(d => d.ItemProducts)
                .HasForeignKey(e => e.IdProduct)
                .IsRequired();

            builder.HasOne(c => c.Item)
                .WithMany(d => d.ItemProducts)
                .HasForeignKey(e => e.IdItem)
                .IsRequired();
        }
    }
}
