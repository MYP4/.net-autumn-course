using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("users")]
public class UserEntity : IdentityUser<int>
{
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }


    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }


    public ICollection<PaymentEntity> Payments { get; set; }
}
