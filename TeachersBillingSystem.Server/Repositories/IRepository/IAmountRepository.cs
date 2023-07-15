using TeachersBillingSystem.Server.Models;

namespace TeachersBillingSystem.Server.Repositories.IRepository;

public interface IAmountRepository
{
    Task<List<Amount>?> GetAll();
    Task<Amount> GetByName(string name);
    Task Add(Amount amount);
    Task Update(Amount request);
    Task Delete(Amount request);
}
