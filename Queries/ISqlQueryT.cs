using AWRD.DataService.Model;
using SqlKata;

namespace AWRD.Queries
{
    public abstract class ISqlQueryT<T> : ISqlQuery where T : ITableModel
    {
        public abstract string EntityName { get; }

        public override Query BuildBaseQuery()
        {
            return new Query().From(EntityName);
        }
    }
}
