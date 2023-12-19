using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;


[Table("roles")]
public class RoleEntity : IdentityRole<int>
{
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }


    public Role Role { get; set; }
}
