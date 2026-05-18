using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/pcs")]
    public class PcsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PcsController(IDbService dbService)
        {
            _dbService = dbService;
        }
        
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PcListItemDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var result = await _dbService.GetAllAsync();
            return Ok(result);
        }
        
        [HttpGet("{id:int}/components")]
        public async Task<IActionResult> GetComponents(int id)
        {
            var result = await _dbService.GetWithComponentsAsync(id);

            if (result is null)
                return NotFound($"PC with id {id} was not found.");

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePcDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _dbService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetComponents), new { id = created.Id }, created);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePcDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await _dbService.UpdateAsync(id, dto);

            if (updated is null)
                return NotFound($"PC with id {id} was not found.");

            return Ok(updated);
        }
        
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _dbService.DeleteAsync(id);

            if (!deleted)
                return NotFound($"PC with id {id} was not found.");

            return NoContent();
        }
    }
}
