namespace AWRD.DataService;

public interface IQueryService
{
    Task<IEnumerable<dynamic>> ExecuteQuery(string query);
    Task<bool> Submit(string query);
    IEnumerable<dynamic> GetResultStream(string query);
}
