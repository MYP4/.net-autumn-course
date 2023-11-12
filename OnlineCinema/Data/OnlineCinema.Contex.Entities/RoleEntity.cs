using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Contex.Entities;


[Table("roles")]
public class RoleEntity : BaseEntity
{
    Role Role { get; set; }

    public virtual ICollection<UserEntity> Users { get; set; }
}
