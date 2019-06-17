using ControleEstoque.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ControleEstoque.Infra.Data.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("tb_ordens");

            builder.Property(c => c.Id)
                .HasColumnName("id_ordem")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("dt_ordem")
                .IsRequired();

            builder.Property(c => c.DeliveryDays)
                .HasColumnName("qt_prazo")
                .IsRequired();

            builder.Property(c => c.IdCustomer)
                .HasColumnName("id_cliente")
                .IsRequired();

            builder.Property(c => c.DeliveryDescription)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("ds_entrega")
                .IsRequired();

            builder.Property(c => c.Observation)
                .HasColumnType("varchar(500)")
                .HasMaxLength(500)
                .HasColumnName("ds_observacao")
                .IsRequired();

            builder.Property(c => c.ERPCode)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .HasColumnName("id_erp")
                .IsRequired();

            builder.HasOne(c => c.Customer)
                .WithMany(d => d.Orders)
                .HasForeignKey(e => e.IdCustomer)
                .IsRequired();
        }
    }
}
