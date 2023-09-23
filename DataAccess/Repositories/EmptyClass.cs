﻿using Data.Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository;

public class DataRepository : IDataRepository
{
    private readonly ApplicationDbContext context;

    public DataRepository(ApplicationDbContext context) => this.context = context;

    public IDataSet<T> Set<T>() where T : class
    {
        return new DataSet<T>(context);
    }

    public async Task Save(CancellationToken ct)
    {
        await context.SaveChangesAsync(ct);
    }


}
