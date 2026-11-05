namespace small_crud_asp_dotnet.Models;

public class DonHang
{
    public int Id { get; set; }
    public string MaKhachHang { get; set; } = string.Empty;
    public decimal TongTien { get; set; }
    public DateTime NgayTao { get; set; } = DateTime.UtcNow;
}