using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace small_crud_asp_dotnet.Migrations
{
    /// <inheritdoc />
    public partial class AddDonHangCompositeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "idx_donhang_makhachhang_ngaytao",
                table: "DonHangs",
                columns: new[] { "MaKhachHang", "NgayTao" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "idx_donhang_makhachhang_ngaytao",
                table: "DonHangs");
        }
    }
}
