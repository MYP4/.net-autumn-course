using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;


[Table("roles")]
public class RoleEntity : BaseEntity
{
    public Role Role { get; set; }

    public virtual ICollection<UserEntity> Users { get; set; }
}
