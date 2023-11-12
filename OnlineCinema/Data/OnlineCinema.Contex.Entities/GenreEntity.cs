using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Contex.Entities;

[Table("genres")]
public class GenreEntity : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }

    public virtual ICollection<MovieEntity> Movies { get; set; }
}
