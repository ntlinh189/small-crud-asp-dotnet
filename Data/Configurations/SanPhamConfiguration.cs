using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using small_crud_asp_dotnet.Models;

namespace small_crud_asp_dotnet.Data.Configurations;

public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
{
    public void Configure(EntityTypeBuilder<SanPham> entity)
    {
        entity.ToTable("SanPhams");

        entity.HasKey(p => p.Id);

        entity.Property(p => p.Id).UseIdentityByDefaultColumn();

        entity.Property(p => p.Ten).HasColumnName("Ten").HasColumnType("text").IsRequired();

        entity.Property(p => p.Gia).HasColumnName("Gia").HasColumnType("numeric").IsRequired();

        entity.Property(p => p.SoLuong).IsRequired();

        entity.Property(p => p.CreatedAt).HasColumnName("created_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }    
}