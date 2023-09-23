
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Collections;

namespace DataAccess.Repository;

public class DataSet<T> : IDataSet<T> where T : class
{

    private readonly DbContext context;

    public DataSet(DbContext context) => this.context = context;

    public IQueryable<T> Data => context.Set<T>();

    public Type ElementType => Data.ElementType;

    public Expression Expression => Data.Expression;

    public IQueryProvider Provider => Data.Provider;

    public async Task Create(T item, CancellationToken ct = default)
    {
        await context.Set<T>().AddAsync(item, ct);
    }

    public void Update(T item)
    {
        context.Set<T>().Update(item);
    }

    public void Remove(T item)
    {
        context.Set<T>().Remove(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return Data.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)Data).GetEnumerator();
    }
}