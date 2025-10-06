using Microsoft.AspNetCore.Mvc;
using TecWebGrupo8.Models.dtos;
using TecWebGrupo8.Services;

namespace TecWeb3ECTeam8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _service;
        public EventsController(IEventService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var events = await _service.GetAll();
            return Ok(events);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var evt = await _service.GetById(id);
            return evt == null ? NotFound(new { error = "Event not found", status = 404 }) : Ok(evt);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEventDto dto)
        {
            if (!ModelState.IsValid) return ValidationProblem(ModelState);
            var evt = await _service.Create(dto);
            return CreatedAtAction(nameof(GetOne), new { id = evt.Id }, evt);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.Delete(id);
            return success
                ? NoContent()
                : NotFound(new { error = "Event not found", status = 404 });
        }
    }
}
