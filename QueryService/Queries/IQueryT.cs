namespace AWRD.QueryService.Queries
{ 
/// <summary>
/// Defines a generic interface for building and compiling queries.
/// </summary>
/// <typeparam name="T">The type of query being built.</typeparam>
public interface IQueryT<T>
{
    /// <summary>
    /// Builds the base query.
    /// </summary>
    /// <returns>The base query.</returns>
    public abstract T BuildBaseQuery();

    /// <summary>
    /// Builds a custom query based on the provided query.
    /// </summary>
    /// <param name="query">The query to customize.</param>
    /// <returns>The custom query.</returns>
    public abstract T BuildCustomQuery(T query);

    /// <summary>
    /// Gets the composed query.
    /// </summary>
    /// <returns>The composed query.</returns>
    public abstract T GetComposedQuery();

    /// <summary>
    /// Compiles the query into a string representation.
    /// </summary>
    /// <returns>The compiled query string.</returns>
    public abstract string CompileQuery();
}
}
