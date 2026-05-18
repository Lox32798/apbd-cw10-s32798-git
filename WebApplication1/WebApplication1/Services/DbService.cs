namespace WebApplication1.Services;

using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Entities;

public class DbService : IDbService
{
    private readonly AppDbContext _db;

    public DbService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<IEnumerable<PcListItemDto>> GetAllAsync()
    {
        return await _db.PCs
            .Select(p => new PcListItemDto
            {
                Id = p.Id,
                Name = p.Name,
                Weight = p.Weight,
                Warranty = p.Warranty,
                CreatedAt = p.CreatedAt,
                Stock = p.Stock
            })
            .ToListAsync();
    }
    
    public async Task<PcComponentsDto?> GetWithComponentsAsync(int id)
    {
        return await _db.PCs
            .Where(p => p.Id == id)
            .Select(p => new PcComponentsDto
            {
                Id   = p.Id,
                Name = p.Name,
                Components = p.PCComponents.Select(pc => new ComponentInPcDto
                {
                    Code = pc.Component.Code,
                    Name = pc.Component.Name,
                    Description  = pc.Component.Description,
                    Amount = pc.Amount,
                    Manufacturer = pc.Component.ComponentManufacturer.Abbreviation,
                    Type = pc.Component.ComponentType.Abbreviation
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<PcListItemDto> CreateAsync(CreatePcDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        await _db.PCs.AddAsync(pc);
        await _db.SaveChangesAsync();

        return new PcListItemDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty  = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<PcListItemDto?> UpdateAsync(int id, UpdatePcDto dto)
    {
        var pc = await _db.PCs.FirstOrDefaultAsync(p => p.Id == id);
        if (pc is null)
            return null;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _db.SaveChangesAsync();

        return new PcListItemDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty  = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }


    public async Task<bool> DeleteAsync(int id)
    {
        var affectedRows = await _db.PCs
            .Where(p => p.Id == id)
            .ExecuteDeleteAsync();

        return affectedRows > 0;
    }
}