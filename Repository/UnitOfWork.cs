using ReactMVC.Data;
using ReactMVC.Models;
using ReactMVC.Repository.Contracts;

namespace ReactMVC.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;
        private IGenericRepository<APIUser> _APIUsers;

        public UnitOfWork(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public IGenericRepository<APIUser> Users => _APIUsers ??= new GenericRepository<APIUser>(_applicationContext);

        public void Dispose()
        {
            _applicationContext.Dispose();
            GC.SuppressFinalize(this);  
        }

        public async Task Save()
        {
            await _applicationContext.SaveChangesAsync();
        }
    }
}
