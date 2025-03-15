using MyAPISimple.Core.Models;

namespace MyAPISimple.Core.Interfaces.IRepository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        // Apply Custom Logic Operation here specific for this Entity
        Task<User> MakeComplexQuery(User user); // TODO: Make DTO and use them here for demostration
    }
}