namespace DataAccess.Repository;

public interface IDataSet<T> : IQueryable<T>
{
    IQueryable<T> Data {get;}
    Task Create(T item, CancellationToken ct = default);
    void Update(T item);
    void Remove(T item);
}