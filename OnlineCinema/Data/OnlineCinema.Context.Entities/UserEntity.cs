using Microsoft.AspNetCore.Identity;
using OnlineCinema.Contex.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("users")]
public class UserEntity : IdentityUser<int>, IBaseEntity
{
    public Guid ExternalId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime ModificationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public DateTime CreationTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }


    public ICollection<PaymentEntity> Payments { get; set; }
}
