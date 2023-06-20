using Newtonsoft.Json;
using SearchProject.Domain.Utilities;
using SearchProject.Models;

namespace SearchProject.Domain.SearchProviders
{
  public class BingSearchProvider : ISearchProvider
  {
    private readonly string _subscriptionKey;
    private static string _baseUri = "https://api.bing.microsoft.com/v7.0/search";
    private static HttpClient _httpClient;
    public BingSearchProvider(IConfiguration configuration)
    {
      _subscriptionKey = configuration.GetValue<string>("BingSubscriptionKey");
      _httpClient = HttpClientFactory.GetHttpClient();
    }
    public async Task<long> Search(string input)
    {
      SetupClient();
      var requestUri = $"{_baseUri}?q={input}";
      var response = await _httpClient.GetAsync(requestUri);
      response.EnsureSuccessStatusCode();
      var contentString = await response.Content.ReadAsStringAsync();
      var responseModel = JsonConvert.DeserializeObject<BingSearchModelContainer>(contentString);
      return responseModel?.WebPages?.TotalEstimatedMatches ?? 0;
    }

    public void SetupClient()
    {
      _httpClient.DefaultRequestHeaders.Clear();
      _httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _subscriptionKey);
    }
  }
}
