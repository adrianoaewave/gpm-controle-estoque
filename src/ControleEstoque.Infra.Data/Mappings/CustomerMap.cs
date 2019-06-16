using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ControleEstoque.Domain.Models;

namespace ControleEstoque.Infra.Data.Mappings
{    
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("tb_clientes");

            builder.Property(c => c.Id)
                .HasColumnName("id_cliente")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .HasColumnName("ds_cliente")
                .IsRequired();
        }
    }
}
