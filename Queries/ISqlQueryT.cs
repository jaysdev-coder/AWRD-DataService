using AWRD.DataService.Model;

namespace AWRD.Queries
{
    public abstract class ISqlQueryT<T> : ISqlQuery where T : ITableModel
    {
        public abstract string EntityName { get; }
    }
}
