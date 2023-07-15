using TeachersBillingSystem.Server.Models;
using TeachersBillingSystem.Server.Models.Dtos;

namespace TeachersBillingSystem.Server.Repositories.IRepository;

public interface ITeacherRepository
{
    Task<Teacher?> GetById(int id);
    Task<List<Teacher>?> GetAll();
    Task Add(Teacher teacher);
    Task Update(int id, TeacherDto teacher);
    Task Delete(Teacher teacher);
}
