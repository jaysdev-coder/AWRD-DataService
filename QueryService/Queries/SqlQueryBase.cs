using SqlKata;
using SqlKata.Compilers;

namespace AWRD.QueryService.Queries
{
    public abstract class SqlQueryBase : IQueryT<Query>
    {
        public abstract Query BuildBaseQuery();

        public abstract Query BuildCustomQuery(Query query);

        public virtual Query GetComposedQuery()
        {
            return BuildCustomQuery(BuildBaseQuery());
        }

        public string CompileQuery()
        {
            var compiler = new SqlServerCompiler();

            var query = compiler.Compile(GetComposedQuery());

            return query.ToString();
        }
    }
}
