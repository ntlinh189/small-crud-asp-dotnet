using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using small_crud_asp_dotnet.Models;
using small_crud_asp_dotnet.Services;

namespace small_crud_asp_dotnet.Controllers;

[ApiController]
[Route("api/sanpham")]
public class SanPhamController : ControllerBase
{
    private readonly SanPhamService _sanPhamService;
    public SanPhamController(SanPhamService sanPhamService)
    {
        _sanPhamService = sanPhamService;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _sanPhamService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _sanPhamService.GetByIdAsync(id));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(SanPham sp)
    {
        var created = await _sanPhamService.CreateAsync(sp);
        return CreatedAtAction(
            nameof(GetById),
            new { id = created.Id },
            created
        );
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, SanPham sp)
    {
        if (id != sp.Id)
        {
            return BadRequest();
        }
        var updated = await _sanPhamService.UpdateAsync(id, sp);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _sanPhamService.DeleteAsync(id);
        if (!deleted) return NotFound();
        return NoContent();
    }

    [HttpGet("price")]
    public async Task<IActionResult> GetByPrice(
        [FromQuery, Required] decimal minPrice
    )
    {
        return Ok(await _sanPhamService.GetByPrice(minPrice));
    }
}