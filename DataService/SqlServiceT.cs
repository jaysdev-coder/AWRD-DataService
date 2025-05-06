using Microsoft.Data.SqlClient;
using Dapper;
using AWRD.DataService.Model;

namespace AWRD.DataService
{
    public class SqlServiceT<T> : ISqlServiceT<T> where T : ITableModel
    {
        private readonly string _connectionString;

        public SqlServiceT(string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ArgumentException("Connection string cannot be null or empty", nameof(connectionString));
            }

            _connectionString = connectionString;
        }

        public async Task Submit(string query)
        {
            // Implement Submit method
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyCollection<T>> ExecuteQuery(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var results = await connection.QueryAsync<T>(query);

            return results.ToList().AsReadOnly();
        }

        public Task<Stream> GetResultStream(string query)
        {
            throw new NotImplementedException();
        }
    }
}