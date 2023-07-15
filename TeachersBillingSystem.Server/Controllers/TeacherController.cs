using Microsoft.AspNetCore.Mvc;
using TeachersBillingSystem.Server.Models;

namespace TeachersBillingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ILogger<TeacherController> _logger;

    public TeacherController(ILogger<TeacherController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Teacher request)
    {
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] Teacher request)
    {
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok();
    }
}
