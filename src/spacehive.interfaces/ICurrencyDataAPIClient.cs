namespace spacehive.interfaces
{
    public interface ICurrencyDataAPIClient
    {
        double Convert(string to, string from, double amount);
    }
}
