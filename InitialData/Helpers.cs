using Bogus;
using Data.Model;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace InitialData;

public static class Helpers <T>
{
    public static Faker<T> GetFakerUser<T>()where T:Role
    {

        return new Faker<T>()
            .RuleFor(r => r.Password, f => f.Internet.Password())
            .RuleFor(r => r.NickName, f => f.Internet.Avatar())
            .RuleFor(r=>r.SignUpDate,f=>f.Date.Between(new DateTime(2023, 1, 1)
                                                    , new DateTime(2023, 12, 31)));
    }

    public static bool SetSeed<TEntity>(ApplicationDbContext context,IEnumerable<TEntity> toSave)where TEntity : class
    {
        if (context.Set <TEntity>().Count() != 0)
        {
            return false;}
        
            context.Set<TEntity>().AddRange(toSave);
            context.SaveChanges();
            return true;


    }
    
    
    public static IEnumerable<IEnumerable<T>> DivideEvenly<T>(IEnumerable<T> source, int n)
    {
        if (source.Count() < n)
        {
            throw new ArgumentException("Not enough elements to divide into classes", nameof(source));
        }

        return source.Select((item, index) => (item: item, group: index % n))
            .GroupBy(x => x.group, x => x.item)
            .Select(g => g.AsEnumerable());
    }
}