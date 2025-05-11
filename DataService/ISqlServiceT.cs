using AWRD.DataService.Model;

namespace AWRD.DataService;

/// <summary>
/// Defines a generic SQL service interface for executing queries and submitting data.
/// </summary>
/// <typeparam name="T">The type of data being queried or submitted, which must implement <see cref="ITableModel"/>.</typeparam>
public interface ISqlServiceT<T> : IQueryService where T : ITableModel
{
    /// <summary>
    /// Executes a SQL query and returns the results as a read-only collection of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="query">The SQL query to execute.</param>
    /// <returns>A task that represents the asynchronous operation, containing a read-only collection of <typeparamref name="T"/>.</returns>
    abstract Task<IReadOnlyCollection<T>> ExecuteQuery(string query);

    /// <summary>
    /// Submits a SQL query for execution, without returning any results.
    /// </summary>
    /// <param name="query">The SQL query to submit.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    abstract Task Submit(string query);

    /// <summary>
    /// Executes a SQL query and returns the results as an enumerable sequence of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="query">The SQL query to execute.</param>
    /// <returns>An enumerable sequence of <typeparamref name="T"/>.</returns>
    abstract IEnumerable<T> GetResultStream(string query);
}