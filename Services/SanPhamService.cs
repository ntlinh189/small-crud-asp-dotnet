using Microsoft.EntityFrameworkCore;
using small_crud_asp_dotnet.Data;
using small_crud_asp_dotnet.Models;

namespace small_crud_asp_dotnet.Services;

public class SanPhamService
{
    private readonly AppDbContext _context;

    public SanPhamService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SanPham>> GetAllAsync()
    {
        return await _context.SanPhams.AsNoTracking().ToListAsync();
    }

    public async Task<SanPham?> GetByIdAsync(int id)
    {
        return await _context.SanPhams.AsNoTracking().FirstOrDefaultAsync(sp => sp.Id == id);
    }

    public async Task<SanPham> CreateAsync(SanPham sp)
    {
        sp.CreatedAt = DateTime.UtcNow;
        _context.SanPhams.Add(sp);
        await _context.SaveChangesAsync();
        return sp;
    }

    public async Task<bool> UpdateAsync(int id, SanPham sp)
    {
        var existSp = await _context.SanPhams.FirstOrDefaultAsync(s => s.Id == id);
        if (existSp == null) return false;

        existSp.Ten = sp.Ten;
        existSp.Gia = sp.Gia;
        existSp.SoLuong = sp.SoLuong;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.SanPhams.FirstOrDefaultAsync(sp => sp.Id == id);

        if (product == null) return false;

        _context.SanPhams.Remove(product);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<IEnumerable<SanPham>> GetByPrice(decimal minPrice)
    {
        return await _context.SanPhams
            .AsNoTracking()
            .Where(s => s.Gia >= minPrice)
            // .OrderBy(s => s.Gia)
            .ToListAsync();
    }
}