namespace OnlineCinema.BL.Users.Entities;

public class CreateUserModel
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string Patronymic { get; set; }
    public DateTime Birthday { get; set; }
}
