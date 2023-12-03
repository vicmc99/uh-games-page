using Bogus;
using Data.Model;

namespace InitialData;

public static class Helpers <T>
{
    public static Faker<T> GetFakerUser<T>()where T:Role
    {

        return new Faker<T>()
            .RuleFor(r => r.Email, f => f.Person.Email)
            .RuleFor(r => r.Password, f => f.Internet.Password())
            .RuleFor(r => r.NickName, f => f.Internet.Avatar())
            .RuleFor(r=>r.SignUpDate,f=>f.Date.Between(new DateTime(2023, 1, 1)
                                                    , new DateTime(2023, 12, 31)));
    }
}