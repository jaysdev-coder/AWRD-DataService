# AWRD

## Project Structure and Components

### DataService Folder

- **IQueryService**: Defines the core interface for executing and submitting queries, as well as streaming results. Methods include:
  - `Task<IEnumerable<dynamic>> ExecuteQuery(string query)`
  - `Task<bool> Submit(string query)`
  - `IEnumerable<dynamic> GetResultStream(string query)`

- **ISqlService**: Extends `IQueryService` for SQL-specific services. No additional members; serves as a marker interface.

- **ISqlServiceT<T>**: A generic interface extending `ISqlService` for strongly-typed table models (`ITableModel`). Provides type-safe query execution and streaming:
  - `Task<IEnumerable<T>> ExecuteQuery(string query)`
  - `IEnumerable<T> GetResultStream(string query)`

- **SqlService**: Implements `ISqlService` using Dapper and `SqlConnection` for dynamic SQL query execution, submission, and result streaming.

- **SqlServiceT<T>**: Generic implementation of `ISqlServiceT<T>`, providing type-safe query execution and streaming for models implementing `ITableModel`.

- **Model/ITableModel**: Interface for table models, requiring a static `Label` property.

### Queries Folder

- **IQueryT<T>**: Generic interface for building, customizing, composing, and compiling queries of type `T`.

- **SqlQueryBase**: Abstract base class implementing `IQueryT<Query>`, using SqlKata for query building and compilation to SQL strings.

- **SqlQueryTBase<T>**: Generic abstract class extending `SqlQueryBase` for entity-specific queries. Requires an `EntityName` property and builds base queries for the specified entity/table.

## How Components Interact

- `SqlService` and `SqlServiceT<T>` provide the main data access logic, using interfaces for flexibility and testability.
- Query classes in the `Queries` folder help build and compile SQL queries in a type-safe and composable way, leveraging SqlKata.

---

## Usage Example

Here is a basic example demonstrating how to use the `SqlService` and a custom query class:

```csharp
using AWRD.DataService;
using AWRD.Queries;
using SqlKata;

// Example table model
public class User : ITableModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public static string Label => "Users";
}

// Example query class
public class UserQuery : SqlQueryTBase<User>
{
    public override string EntityName => User.Label;
}

// Usage
var connectionString = "your-connection-string";
var sqlService = new SqlServiceT<User>(connectionString);
var userQuery = new UserQuery();
string sql = userQuery.CompileQuery();
var users = await sqlService.ExecuteQuery(sql);
```

This example shows how to define a table model, create a query for that model, compile the query to SQL, and execute it using the service.

Here is another example showing how to define a query class and use the `CompileQuery` method to generate a SQL string:

```csharp
using AWRD.DataService;
using AWRD.Queries;
using SqlKata;

// Example table model
public class User : ITableModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public static string Label => "Users";
}

// Example query class for CompileQuery
public class UserQuery : SqlQueryTBase<User>
{
    public override string EntityName => User.Label;

    // Optionally override BuildCustomQuery to add filters or projections
    public override Query BuildCustomQuery(Query query)
    {
        // Example: select only users with Id > 10
        return query.Where("Id", ">", 10);
    }
}

// Usage
var userQuery = new UserQuery();
string sql = userQuery.CompileQuery();
// sql now contains the compiled SQL string for: SELECT * FROM Users WHERE Id > 10
```

This example shows how to define a query class for a table model and use the `CompileQuery` method to generate a SQL string with custom logic.