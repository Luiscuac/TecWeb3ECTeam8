﻿using Microsoft.AspNetCore.Mvc;
using TecWebGrupo8.Models.dtos;
using TecWebGrupo8.Services;

namespace TecWebGrupo8.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuestController : ControllerBase
{
    private readonly IGuestService _service;
    public GuestController(IGuestService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var items = await _service.GetAll();
        return Ok(items);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetOne(Guid id)
    {
        var guest = await _service.GetById(id);
        return guest is null
            ? NotFound(new { error = "Guest not found", status = 404 })
            : Ok(guest);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGuestDto dto)
    {
        if (!ModelState.IsValid) return ValidationProblem(ModelState);
        var guest = await _service.Create(dto);
        return CreatedAtAction(nameof(GetOne), new { id = guest.Id }, guest);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var success = await _service.Delete(id);
        return success
            ? NoContent()
            : NotFound(new { error = "Guest not found", status = 404 });
    }
}
