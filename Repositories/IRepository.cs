using AWRD.QueryService.Model;

namespace AWRD.Repositories
{
    internal interface IRepository<T> where T : ITableModel
    {
        Task GetById(int id);
        Task<IEnumerable<T>> GetAll();
        Task Insert(T model);
        Task Update(T model);
        Task Delete(T model);
    }
}
