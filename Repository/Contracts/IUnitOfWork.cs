using ReactMVC.Models;

namespace ReactMVC.Repository.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<APIUser> Users { get; }
        Task Save();
    }
}
