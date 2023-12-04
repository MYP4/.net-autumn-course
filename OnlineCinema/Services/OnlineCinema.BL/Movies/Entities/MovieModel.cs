using OnlineCinema.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Movies.Entities;

public class MovieModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public string Link { get; set; }         // link to the movie
    public double Rating { get; set; }
    public int Duration { get; set; }       // in minutes
    public AgeLimitEnum AgeLimit { get; set; }
    public GenreEntity Genre { get; set; }
}
