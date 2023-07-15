using Microsoft.EntityFrameworkCore;
using TeachersBillingSystem.Server.Data;
using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Models.Dtos;
using TeachersBillingSystem.Server.Repositories.IRepository;

namespace TeachersBillingSystem.Server.Repositories;

public class TeacherRepository : ITeacherRepository
{
    private readonly ApplicationDbContext _context;
    public TeacherRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Teacher>?> GetAll()
    {
        var teachers = await _context.Teachers.ToListAsync();
        return teachers;
    }

    public async Task<Teacher?> GetById(int id)
    {
        var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id);
        return teacher;
    }
    public async Task Add(Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
        await SaveAsync();
    }

    public async Task Delete(Teacher teacher)
    {
        _context.Teachers.Remove(teacher);
        await SaveAsync();
    }

   

    public async Task Update(int id, TeacherDto teacher)
    {
        var _teacher = await GetById(id);
        if (_teacher is not null)
        {
            _teacher.NameEnglish = teacher.NameEnglish;
            _teacher.NameBengali = teacher.NameBengali;
            _teacher.Department = teacher.Department;
            _teacher.Rank = teacher.Rank;

            await SaveAsync();
        }
    }
    private async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
