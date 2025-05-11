using AWRD.DataService.Model;

namespace AWRD.DataService;

public interface ISqlServiceT<T> : ISqlService where T : ITableModel
{
    new Task<IEnumerable<T>> ExecuteQuery(string query);
    new IEnumerable<T> GetResultStream(string query);
}