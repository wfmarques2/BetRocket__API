using System.Text.Json.Serialization;

namespace Domain.Models;

public class ModelAskForAdminAccess : ModelBase
{
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }

    public DateTime BirthDate { get; set; }

    public ModelAskForAdminAccess()
    {

    }

    public ModelAskForAdminAccess(string username, DateTime birthDate, string password) : base()
    {
        Username = username;
        Password = password;
        PasswordValidations(password);
        BirthDate = birthDate;
    }

    public static implicit operator ModelUser(ModelAskForAdminAccess request)
    {
        return new ModelUser
        (
            username: request.Username,
            birthDate: request.BirthDate,
            password: request.Password
        )
        { Id = request.Id };
    }

    private void PasswordValidations(string password)
    {
        if (Password.Length < 8)
            throw new ArgumentException("Password fraca");

        if (!Password.Any(char.IsUpper))
            throw new ArgumentException("Password fraca");

        if (!Password.Any(char.IsLower))
            throw new ArgumentException("Password fraca"); ;

        if (!Password.Any(char.IsDigit))
            throw new ArgumentException("Password fraca"); ;

        if (!Password.Any(c => "!@#$%^&*()_+-=[]{}|;:'\",.<>?".Contains(c)))
            throw new ArgumentException("Password fraca");
    }
}
