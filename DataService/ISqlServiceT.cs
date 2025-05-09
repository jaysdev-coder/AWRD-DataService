using AWRD.DataService.Model;

namespace AWRD.DataService
{
    public interface ISqlServiceT<T> : IQueryService where T : ITableModel
    {
        abstract Task<IReadOnlyCollection<T>> ExecuteQuery(string query);
        abstract Task Submit(string query);
        abstract IEnumerable<T> GetResultStream(string query);
    }
}
