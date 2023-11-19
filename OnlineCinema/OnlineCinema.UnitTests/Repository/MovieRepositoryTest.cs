using FluentAssertions;
using NUnit.Framework;
using OnlineCinema.Context.Entities;
using Repository;

namespace OnlineCinema.UnitTests.Repository;

[TestFixture]
[Category("Integration")]
public class MovieRepositoryTest : RepositoryTestsBaseClass
{
    [Test]
    public void GetAllMoviesTest()
    {
        // prepere

        using var context = DbContextFactory.CreateDbContext();

        var movies = new MovieEntity[]
        {
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_1",
               Description = "Movie_test_description_1",
               Director = "Movie_test_director_1",
               Link = "Movie_test_link_1",
               Rating = 5.0,
               Duration = 120
           },
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_2",
               Description = "Movie_test_description_2",
               Director = "Movie_test_director_2",
               Link = "Movie_test_link_2",
               Rating = 4.0,
               Duration = 90
           },
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_3",
               Description = "Movie_test_description_3",
               Director = "Movie_test_director_3",
               Link = "Movie_test_link_3",
               Rating = 3.0,
               Duration = 70
           },
        };

        context.Movies.AddRange(movies);
        context.SaveChanges();

        // execute

        var repository = new Repository<MovieEntity>(DbContextFactory);
        var actualMovies = repository.GetAll();

        // assert

        actualMovies.Should().BeEquivalentTo(movies);
    }


    [Test]
    public void GetAllMoviesWithFilterTest()
    {
        // prepere

        using var context = DbContextFactory.CreateDbContext();

        var movies = new MovieEntity[]
        {
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_1",
               Description = "Movie_test_description_1",
               Director = "Movie_test_director_1",
               Link = "Movie_test_link_1",
               Rating = 5.0,
               Duration = 120
           },
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_2",
               Description = "Movie_test_description_2",
               Director = "Movie_test_director_2",
               Link = "Movie_test_link_2",
               Rating = 5.0,
               Duration = 90
           },
           new MovieEntity()
           {
               ExternalId = Guid.NewGuid(),
               Name = "Movie_test_name_3",
               Description = "Movie_test_description_3",
               Director = "Movie_test_director_3",
               Link = "Movie_test_link_3",
               Rating = 3.0,
               Duration = 70
           },
        };

        context.Movies.AddRange(movies);
        context.SaveChanges();

        // execute

        var repository = new Repository<MovieEntity>(DbContextFactory);
        var actualMovies = repository.GetAll(x => x.Rating == 5.0);

        // assert

        actualMovies.Should().BeEquivalentTo(movies.Where(x => x.Rating == 5.0));
    }


    [Test]
    public void SaveNewMovieTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();
        var movie = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_1",
            Description = "Movie_test_description_1",
            Director = "Movie_test_director_1",
            Link = "Movie_test_link_1",
            Rating = 5.0,
            Duration = 120
        };

        // execute

        var repository = new Repository<MovieEntity>(DbContextFactory);
        repository.Save(movie);

        // assert

        var actualMovie = context.Movies.SingleOrDefault();
        actualMovie.Should().BeEquivalentTo(movie);

        actualMovie.Id.Should().NotBe(default);
        actualMovie.ModificationTime.Should().NotBe(default);
        actualMovie.CreationTime.Should().NotBe(default);
        actualMovie.ExternalId.Should().NotBe(Guid.Empty);
    }


    [Test]
    public void UpdateMovieTest()
    {
        using var context = DbContextFactory.CreateDbContext();
        var movie = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_1",
            Description = "Movie_test_description_1",
            Director = "Movie_test_director_1",
            Link = "Movie_test_link_1",
            Rating = 5.0,
            Duration = 120
        };
        context.Movies.Add(movie);
        context.SaveChanges();

        // execute

        movie.Name = "new name1";
        movie.Description = "new name2";
        movie.Director = "new name3";

        var repository = new Repository<MovieEntity>(DbContextFactory);
        repository.Save(movie);

        // assert

        var actualMovie = context.Movies.SingleOrDefault();
        actualMovie.Should().BeEquivalentTo(movie);
    }


    [Test]
    public void DeleteMovieTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();
        var movie = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_1",
            Description = "Movie_test_description_1",
            Director = "Movie_test_director_1",
            Link = "Movie_test_link_1",
            Rating = 5.0,
            Duration = 120
        };

        context.Movies.Add(movie);
        context.SaveChanges();

        // execute

        var repository = new Repository<MovieEntity>(DbContextFactory);
        repository.Delete(movie);

        // assert

        context.Movies.Count().Should().Be(0);
    }


    [Test]
    public void GetByGuidTest()
    {
        // prepare 

        var guid = Guid.NewGuid();

        using var context = DbContextFactory.CreateDbContext();

        var movie1 = new MovieEntity()
        {
            ExternalId = guid,
            Name = "Movie_test_name_1",
            Description = "Movie_test_description_1",
            Director = "Movie_test_director_1",
            Link = "Movie_test_link_1",
            Rating = 5.0,
            Duration = 120
        };
        var movie2 = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_2",
            Description = "Movie_test_description_2",
            Director = "Movie_test_director_2",
            Link = "Movie_test_link_2",
            Rating = 5.0,
            Duration = 90
        };
        var movie3 = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_3",
            Description = "Movie_test_description_3",
            Director = "Movie_test_director_3",
            Link = "Movie_test_link_3",
            Rating = 3.0,
            Duration = 70
        };

        context.AddRange(new MovieEntity[] { movie1, movie2, movie3});
        context.SaveChanges();

        // execute

        var repository = new Repository<MovieEntity>(DbContextFactory);
        var actualMovie = repository.GetByGuid(guid);

        // assert

        actualMovie.Should().BeEquivalentTo(movie1);
    }


    [Test]
    public void GetByIdTest()
    {
        // prepare 

        using var context = DbContextFactory.CreateDbContext();

        var movie1 = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_1",
            Description = "Movie_test_description_1",
            Director = "Movie_test_director_1",
            Link = "Movie_test_link_1",
            Rating = 5.0,
            Duration = 120
        };
        var movie2 = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_2",
            Description = "Movie_test_description_2",
            Director = "Movie_test_director_2",
            Link = "Movie_test_link_2",
            Rating = 5.0,
            Duration = 90
        };
        var movie3 = new MovieEntity()
        {
            ExternalId = Guid.NewGuid(),
            Name = "Movie_test_name_3",
            Description = "Movie_test_description_3",
            Director = "Movie_test_director_3",
            Link = "Movie_test_link_3",
            Rating = 3.0,
            Duration = 70
        };

        context.AddRange(new MovieEntity[] { movie1, movie2, movie3 });
        context.SaveChanges();

        // execute

        var id = movie1.Id;
        var repository = new Repository<MovieEntity>(DbContextFactory);
        var actualMovie = repository.GetById(id);

        // assert

        actualMovie.Should().BeEquivalentTo(movie1);
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
            context.Movies.RemoveRange(context.Movies);
            context.SaveChanges();
        }
    }
}
