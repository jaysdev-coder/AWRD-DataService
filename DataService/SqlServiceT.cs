using Microsoft.Data.SqlClient;
using Dapper;
using AWRD.DataService.Model;

namespace AWRD.DataService;

public class SqlServiceT<T>(string connectionString) : SqlService(connectionString), ISqlServiceT<T> where T : ITableModel
{
    public new async Task<IEnumerable<T>> ExecuteQuery(string query)
    {
        using var connection = new SqlConnection(_connectionString);

        var result = await connection.QueryAsync<T>(query);

        return result;
    }

    public new IEnumerable<T> GetResultStream(string query)
    {
        using var connection = new SqlConnection(_connectionString);

        return connection.Query<T>(query, buffered: false);
    }
}
