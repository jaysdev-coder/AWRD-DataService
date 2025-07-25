using AWRD.QueryService.Model;
using SqlKata;

namespace AWRD.QueryService.Queries
{
    /// <summary>
    /// Represents a generic SQL query class for a specific entity type.
    /// </summary>
    /// <typeparam name="T">The type of entity being queried against the table, which must implement ITableModel.</typeparam>
    public abstract class SqlQueryTBase<T> : SqlQueryBase where T : ITableModel
    {
        /// <summary>
        /// Gets the name of the entity being queried against the table.
        /// </summary>
        public abstract string EntityName { get; }

        /// <summary>
        /// Builds the base query for the entity.
        /// </summary>
        /// <returns>A Query object representing the base query.</returns>
        public override Query BuildBaseQuery()
        {
            // Create a new Query object and specify the entity (table) to query
            return new Query().From(EntityName);
        }
    }
}
