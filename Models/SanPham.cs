namespace small_crud_asp_dotnet.Models;

public class SanPham
{
    public int Id { get; set; }
    public string Ten { get; set; } = string.Empty;
    public decimal Gia { get; set; }
    public int SoLuong { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}