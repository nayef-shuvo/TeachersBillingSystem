using TeachersBillingSystem.Server.Models;

namespace TeachersBillingSystem.Server.Repositories.IRepository;

public interface IAmountRepository
{
    Task<Dictionary<string, uint>> GetAll();
    Task<Amount> GetByName(string name);
    Task Add(Amount amount);
    Task Update(Amount request);
    Task Delete(Amount request);
}
