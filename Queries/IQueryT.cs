namespace AWRD.Queries
{
    public interface IQueryT<T>
    {
        public abstract T BuildBaseQuery();
        public abstract T BuildCustomQuery(T query);
        public abstract T GetComposedQuery();
        public abstract string CompileQuery();
    }
}
