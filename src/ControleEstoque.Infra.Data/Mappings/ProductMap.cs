using ControleEstoque.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("tb_produtos");

            builder.Property(c => c.Id)
                .HasColumnName("id_produto")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("ds_produto")
                .IsRequired();

            builder.Property(c => c.ERPCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(100)
                .HasColumnName("id_erp")
                .IsRequired();
        }
    }
}
