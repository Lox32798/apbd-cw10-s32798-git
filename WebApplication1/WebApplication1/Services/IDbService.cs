namespace WebApplication1.Services;

using WebApplication1.DTOs;
public interface IDbService
{
    Task<IEnumerable<PcListItemDto>> GetAllAsync();
    Task<PcComponentsDto?>          GetWithComponentsAsync(int id);
    Task<PcListItemDto>             CreateAsync(CreatePcDto dto);
    Task<PcListItemDto?>            UpdateAsync(int id, UpdatePcDto dto);
    Task<bool>                      DeleteAsync(int id);
}