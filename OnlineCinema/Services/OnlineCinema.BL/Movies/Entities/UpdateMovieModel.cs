using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineCinema.BL.Movies.Entities;

public class UpdateMovieModel
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Director { get; set; }
    public double Rating { get; set; }
}
