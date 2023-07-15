using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Repositories.IRepository;

namespace TeachersBillingSystem.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AmountController : ControllerBase
{
    private readonly IAmountRepository _repository;
    public AmountController(IAmountRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var amounts = await _repository.GetAll();
        return Ok(amounts);
    }

    [HttpGet("{name}", Name = "GetByName")]
    public async Task<IActionResult> Get(string name)
    {
        var amount = await _repository.GetByName(name);
        if (amount is null)
        {
            return NotFound();
        }
        return Ok(amount);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] Amount amount)
    {
        var _amount = await _repository.GetByName(amount.Name);
        if (_amount is not null) 
        {
            return BadRequest("This field is already exist");
        }
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _repository.Add(amount);
        return Ok(amount);
    }

    [HttpPut("{name}")]
    public async Task<IActionResult> Update(string name, [FromBody] Amount amount)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        if (name != amount.Name) return BadRequest("Name does not match");
        await _repository.Update(amount);
        return NoContent();
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> Delete(string name)
    {
        var amount = await _repository.GetByName(name);
        if (amount is null)
        {
            return NotFound();
        }
        await _repository.Delete(amount);
        return NoContent();
    }
} 
