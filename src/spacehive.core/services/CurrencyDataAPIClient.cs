namespace spacehive.core;

using Newtonsoft.Json;
using spacehive.domain;
using spacehive.interfaces;


public class CurrencyDataAPIClient: ICurrencyDataAPIClient
{
    private readonly string BaseUrl = "https://api.apilayer.com/currency_data/";
    private HttpClient client;
    private readonly string apiKey;
    public CurrencyDataAPIClient()
    {
        client = new HttpClient();
        apiKey = Environment.GetEnvironmentVariable("API_KEY");
    }

    public double Convert(string to, string from, double amount)
    {
        var uri = $"convert?to={to}&from={from}&amount={amount}";
        var request = new HttpRequestMessage() {
            RequestUri = new Uri($"{BaseUrl}{uri}"),
            Method = HttpMethod.Get,
        };

        request.Headers.Add("apikey", apiKey);

        HttpResponseMessage response = client.SendAsync(request).Result;

        var result = response.Content.ReadAsStringAsync().Result;
        var convertedAmount = JsonConvert.DeserializeObject<CurrencyDataAPIResponse>(result);
        return convertedAmount.Result;
    }
}
