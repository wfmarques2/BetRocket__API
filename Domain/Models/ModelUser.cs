using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models;

public class ModelUser
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public DateTime BirthDate { get; set; }

    public decimal Balance { get; set; }

    public bool IsAdmin { get; set; }

    public ICollection<ModelBet> Bets { get; set; }

    public ModelUser(string username, DateTime birthDate, string password)
    {
        Id = Guid.NewGuid();
        Username = username;
        Password = password;
        BirthDate = birthDate;
        Bets = new List<ModelBet>();
    }

    public void SetAdminUser()
    {
        this.IsAdmin = true;
    }

    public void SetBalanceUser(ModelUser user, decimal balance)
    {
        this.Balance = balance;
    }
}
