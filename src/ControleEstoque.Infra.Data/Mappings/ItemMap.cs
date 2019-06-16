using ControleEstoque.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Data.Mappings
{
    public class ItemMap : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("tb_itens");

            builder.Property(c => c.Id)
                .HasColumnName("id_item")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("ds_item")
                .IsRequired();

            builder.Property(c => c.QuantidadeEstoque)
                .HasColumnName("qt_estoque")
                .IsRequired();

            builder.Property(c => c.ERPCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .HasColumnName("id_erp");
        }
    }
}
