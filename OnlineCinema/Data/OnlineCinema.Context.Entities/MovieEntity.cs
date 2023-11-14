using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("movies")]
public class MovieEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Link { get; set; } // link to the movie
    public double Rating { get; set; }
    public int Duration { get; set; } // in minutes
    public AgeLimitEnum AgeLimit { get; set; }


    public int GenreId { get; set; }
    public GenreEntity Genre { get; set; }


    public ICollection<SubscriptionEntity> Subscriptions { get; set; }
}
