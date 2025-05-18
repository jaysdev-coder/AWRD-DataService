namespace AWRD.Queries
{
    internal interface ISqlQuery : IQuery
    {
        abstract string TableName { get; init; }
    }
}
