using Microsoft.AspNetCore.Mvc;
using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Models.Dtos;
using TeachersBillingSystem.Server.Repositories.IRepository;

namespace TeachersBillingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ILogger<TeacherController> _logger;
    private readonly ITeacherRepository _repository;

    public TeacherController(ILogger<TeacherController> logger, ITeacherRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Request for all teachers details");

        var teachers = await _repository.GetAll();
        return Ok(teachers);
    }

    [HttpGet("{id:int}", Name = "GetById")]
    public async Task<IActionResult> Get(int id)
    {
        _logger.LogInformation($"Request for a teacher's info with id: {id}");

        var teacher = await _repository.GetById(id);
        if (teacher == null)
        {
            return BadRequest("Teacher not found");
        }
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TeacherDto request)
    {
        _logger.LogInformation("Request for adding a teacher");
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var teacher = new Teacher 
        { 
            NameEnglish = request.NameEnglish,
            NameBengali = request.NameBengali,
            Department = request.Department,
            Rank = request.Rank,
        };
        await _repository.Add(teacher);
        return CreatedAtRoute("GetById", new { teacher.Id}, teacher);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] TeacherDto request)
    {
        _logger.LogInformation($"Request for update of id: {id}");

        var teacher = await _repository.GetById(id);
        if (teacher is null)
        {
            return BadRequest("Teacher not found");
        }
        await _repository.Update(id, request);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        _logger.LogInformation($"Request for a delete operation of id: {id}");

        var teacher = await _repository.GetById(id);
        if (teacher is null) 
        {
            return BadRequest("Teacher not found");
        }
        await _repository.Delete(teacher);
        return NoContent();
    }
}
