using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineCinema.Context.Entities;

[Table("users")]
public class UserEntity : BaseEntity
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }    // HashPassword
    public DateTime? Birthday { get; set; }


    public int? RoleId { get; set; }
    public RoleEntity Role { get; set; }


    public ICollection<PaymentEntity> Payments { get; set; }
}
