namespace Application.Validations;

public static class HasEnoughMoney
{
    public static bool HasEnoughMoneyToBet(decimal userBalance,  decimal amountRequest)
    {
        if (userBalance < amountRequest) return false;

        return true;
    }
}
