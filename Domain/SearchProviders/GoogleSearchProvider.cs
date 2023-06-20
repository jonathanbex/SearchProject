using GoogleApi.Entities.Interfaces;
using GoogleApi.Entities.Search;
using GoogleApi.Entities.Search.Web.Request;
using SearchProject.Models;

namespace SearchProject.Domain.SearchProviders
{
  public class GoogleSearchProvider : ISearchProvider
  {
    GoogleApi.GoogleSearch.WebSearchApi _webSearchApi;
    private readonly string _googleApiKey;
    private readonly string _googleSearchEngineId;
    public GoogleSearchProvider(GoogleApi.GoogleSearch.WebSearchApi webSearchApi, IConfiguration config)
    {
      _webSearchApi = webSearchApi;
      _googleApiKey = config.GetValue<string>("GoogleApiKey");
      _googleSearchEngineId = config.GetValue<string>("GoogleSearchEngineId");
    }
    public async Task<long> Search(string input)
    {
      var request = new WebSearchRequest { Query = input , Key = _googleApiKey, SearchEngineId = _googleSearchEngineId };
      var response = await _webSearchApi.QueryAsync(request);

      return (response?.Search?.TotalResults ?? 0);
    }
  }
}
