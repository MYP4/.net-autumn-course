using FluentAssertions;
using NUnit.Framework;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.UnitTests.Repository;


[TestFixture]
[Category("Integration")]
public class UserRepositoryTest : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllUsersTest()
    {
        // prepere

        using var context = DbContextFactory.CreateDbContext();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "fn_user_1",
                SecondName = "sn_user_1",
                Patronymic = "p_user_1",
                Login = "fn_user_1_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "fn_user_2",
                SecondName = "sn_user_2",
                Patronymic = "p_user_2",
                Login = "fn_user_2_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "fn_user_3",
                SecondName = "sn_user_3",
                Patronymic = "p_user_3",
                Login = "fn_user_3_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        // execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll();

        // assert

        actualUsers.Should().BeEquivalentTo(users);

    }


    [Test]
    public void GetAllUsersWithFilterTest()
    {
        // prepere

        using var context = DbContextFactory.CreateDbContext();

        var users = new UserEntity[]
        {
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "Jonh",
                SecondName = "sn_user_1",
                Patronymic = "p_user_1",
                Login = "fn_user_1_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "fn_user_2",
                SecondName = "sn_user_2",
                Patronymic = "p_user_2",
                Login = "fn_user_2_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
            new UserEntity()
            {
                ExternalId = Guid.NewGuid(),
                FirstName = "fn_user_3",
                SecondName = "sn_user_3",
                Patronymic = "p_user_3",
                Login = "fn_user_3_login",
                Password = "password",
                Birthday = DateTime.Now,
            },
        };

        context.Users.AddRange(users);
        context.SaveChanges();

        // execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUsers = repository.GetAll(x => x.FirstName == "Jonh");

        // assert

        actualUsers.Should().BeEquivalentTo(users.Where(x => x.FirstName == "Jonh"));
    }


    [Test]
    public void SaveNewUserTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();
        var user = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_1",
            Patronymic = "p_user_1",
            Login = "fn_user_1_login",
            Password = "password",
            Birthday = DateTime.Now,
        };

        // execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        // assert

        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user);

        actualUser.Id.Should().NotBe(default);
        actualUser.ModificationTime.Should().NotBe(default);
        actualUser.CreationTime.Should().NotBe(default);
        actualUser.ExternalId.Should().NotBe(Guid.Empty);
    }


    [Test]
    public void UpdateUserTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();
        var user = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_1",
            Patronymic = "p_user_1",
            Login = "fn_user_1_login",
            Password = "password",
            Birthday = DateTime.Now,
        };

        context.Users.Add(user);
        context.SaveChanges();

        // execute

        user.FirstName = "new name1";
        user.SecondName = "new name2";
        user.Patronymic = "new name3";

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Save(user);

        // assert

        var actualUser = context.Users.SingleOrDefault();
        actualUser.Should().BeEquivalentTo(user);
    }


    [Test]
    public void DeleteUserTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();
        var user = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_1",
            Patronymic = "p_user_1",
            Login = "fn_user_1_login",
            Password = "password",
            Birthday = DateTime.Now,
        };

        context.Users.Add(user);
        context.SaveChanges();

        // execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        repository.Delete(user);

        // assert

        context.Users.Count().Should().Be(0);
    }


    [Test]
    public void GetByGuidTest()
    {
        // prepare 

        var guid = Guid.NewGuid();

        using var context = DbContextFactory.CreateDbContext();

        var user1 = new UserEntity()
        {
            ExternalId = guid,
            FirstName = "Jonh",
            SecondName = "sn_user_1",
            Patronymic = "p_user_1",
            Login = "fn_user_1_login",
            Password = "password",
            Birthday = DateTime.Now,
        };
        var user2 = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_2",
            Patronymic = "p_user_2",
            Login = "fn_user_2_login",
            Password = "password",
            Birthday = DateTime.Now,
        };
        var user3 = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "fn_user_3",
            SecondName = "sn_user_3",
            Patronymic = "p_user_3",
            Login = "fn_user_3_login",
            Password = "password",
            Birthday = DateTime.Now,
        };

        context.AddRange(new UserEntity[] { user1, user2, user3 });
        context.SaveChanges();

        // execute

        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUser = repository.GetByGuid(guid);

        // assert

        actualUser.Should().BeEquivalentTo(user1);
    }


    [Test]
    public void GetByidTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();

        var user1 = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_1",
            Patronymic = "p_user_1",
            Login = "fn_user_1_login",
            Password = "password",
            Birthday = DateTime.Now,
        };
        var user2 = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "Jonh",
            SecondName = "sn_user_2",
            Patronymic = "p_user_2",
            Login = "fn_user_2_login",
            Password = "password",
            Birthday = DateTime.Now,
        };
        var user3 = new UserEntity()
        {
            ExternalId = Guid.NewGuid(),
            FirstName = "fn_user_3",
            SecondName = "sn_user_3",
            Patronymic = "p_user_3",
            Login = "fn_user_3_login",
            Password = "password",
            Birthday = DateTime.Now,
        };

        context.AddRange(new UserEntity[] { user1, user2, user3 });
        context.SaveChanges();

        // execute

        var id = user1.Id;
        var repository = new Repository<UserEntity>(DbContextFactory);
        var actualUser = repository.GetById(id);

        // assert

        actualUser.Should().BeEquivalentTo(user1);
    }


    [SetUp]
    public void SetUp()
    {
        CleanUp();
    }


    [TearDown]
    public void TearDown()
    {
        CleanUp();
    }


    public void CleanUp()
    {
        using (var context = DbContextFactory.CreateDbContext())
        {
            context.Users.RemoveRange(context.Users);
            context.SaveChanges();
        }
    }
}
