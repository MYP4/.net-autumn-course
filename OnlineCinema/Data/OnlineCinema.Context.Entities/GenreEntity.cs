using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("genres")]
public class GenreEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<MovieEntity> Movies { get; set; }
}
