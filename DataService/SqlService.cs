using Dapper;
using Microsoft.Data.SqlClient;

namespace AWRD.DataService;

public class SqlService : ISqlService
{
    protected string _connectionString { get; }

    public SqlService(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Connection string cannot be null or empty.", nameof(connectionString));
        }

        _connectionString = connectionString;
    }

    public async Task<IEnumerable<dynamic>> ExecuteQuery(string query)
    {
        using var connection = new SqlConnection(_connectionString);

        return await connection.QueryAsync(query);
    }

    public async Task<bool> Submit(string query)
    {
        try
        {
            using var connection = new SqlConnection(_connectionString);

            await connection.ExecuteAsync(query);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public IEnumerable<dynamic> GetResultStream(string query)
    {
        using var connection = new SqlConnection(_connectionString);

        return connection.Query(query, buffered: false);
    }
}
