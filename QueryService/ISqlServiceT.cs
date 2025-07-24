using AWRD.QueryService.Model;

namespace AWRD.QueryService;

public interface ISqlServiceT<T> : ISqlService where T : ITableModel
{
    new Task<IEnumerable<T>> ExecuteQuery(string query);
    new IEnumerable<T> GetResultStream(string query);
}