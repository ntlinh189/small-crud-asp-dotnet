using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using small_crud_asp_dotnet.Models;

namespace small_crud_asp_dotnet.Data.Configurations;

public class DonHangConfiguration : IEntityTypeConfiguration<DonHang>
{
    public void Configure(EntityTypeBuilder<DonHang> entity)
    {
        entity.ToTable("DonHangs");

        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id).UseIdentityByDefaultColumn();

        entity.Property(d => d.MaKhachHang).HasColumnName("MaKhachHang").HasColumnType("varchar(20)").IsRequired();

        entity.Property(d => d.TongTien).HasColumnType("numeric(18,2)").IsRequired();

        entity.Property(d => d.NgayTao).HasColumnType("timestamp with time zone").IsRequired();

        entity.HasIndex(d => new { d.MaKhachHang, d.NgayTao }).HasDatabaseName("idx_donhang_makhachhang_ngaytao");
    }
}