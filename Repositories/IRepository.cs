using AWRD.QueryService.Model;

namespace AWRD.Repositories
{
    internal interface IRepository<T> where T : ITableModel
    {
        Task Insert(T model);
        Task Update(T model);
        Task Delete(T model);
    }
}
