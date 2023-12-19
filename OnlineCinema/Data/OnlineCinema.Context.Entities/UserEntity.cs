using Microsoft.AspNetCore.Identity;
using OnlineCinema.Contex.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("users")]
public class UserEntity : IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get ; set; } = Guid.NewGuid();
    public DateTime ModificationTime { get; set; } = DateTime.Now;
    public DateTime CreationTime { get; set; } = DateTime.Now;


    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }


    public ICollection<PaymentEntity> Payments { get; set; }
}
