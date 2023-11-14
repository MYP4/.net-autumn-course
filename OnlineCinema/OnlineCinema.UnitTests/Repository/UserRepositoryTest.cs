using NUnit.Framework;
using OnlineCinema.Context.Entities;
using OnlineCinema.Context;
using Repository;

namespace OnlineCinema.UnitTests.Repository;

public class UserRepositoryTest : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllUsersText()
    {
        // prepere

        using var context = DbContextFactory.CreateDbContext();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                FirstName = "fn_user_1",
                SecondName = "sn_user_1",
                Patronymic = "p_user_1",
                ExternalId = Guid.NewGuid(),
            },
            new UserEntity()
            {
                FirstName = "fn_user_2",
                SecondName = "sn_user_2",
                Patronymic = "p_user_2",
                ExternalId = Guid.NewGuid(),
            },
            new UserEntity()
            {
                FirstName = "fn_user_3",
                SecondName = "sn_user_3",
                Patronymic = "p_user_3",
                ExternalId = Guid.NewGuid(),
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        // execute
        var repository = new Repository<UserEntity>(DbContextFactory);

    }
}
