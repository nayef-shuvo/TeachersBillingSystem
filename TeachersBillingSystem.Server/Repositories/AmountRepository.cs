using Microsoft.EntityFrameworkCore;
using TeachersBillingSystem.Server.Data;
using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Repositories.IRepository;

namespace TeachersBillingSystem.Server.Repositories;

public class AmountRepository : IAmountRepository
{
    private readonly ApplicationDbContext _context;
    public AmountRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Amount>?> GetAll()
    {
        var all = await _context.Amounts.ToListAsync();
        return all;
    }

    public async Task<Amount?> GetByName(string name)
    {
        var amount = await _context.Amounts.FirstOrDefaultAsync(x => x.Name == name);
        return amount;
    }

    public async Task Add(Amount amount)
    {
        await _context.Amounts.AddAsync(amount);
        await SaveAsync();
    }


    public async Task Update(Amount amount)
    {
        var _amount = await GetByName(amount.Name);
        if (_amount != null)
        {
            _amount.Value = amount.Value;
            await SaveAsync();
        }
    }

    public async Task Delete(Amount amount)
    {
        _context.Amounts.Remove(amount);
        await SaveAsync();
    }

    private async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
