using MyAPISimple.Core.Interfaces.IRepository;

namespace MyAPISimple.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        Task<int> SaveAsync();
    }
}