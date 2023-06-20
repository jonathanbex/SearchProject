using SearchProject.Domain.SearchProviders;
using SearchProject.Models.ViewModel;

namespace SearchProject.Domain.Setup
{
  public class ResultProvider
  {
    ISearchProvider _google;
    ISearchProvider _bing;
    IConfiguration _config;
    List<Searcher> _searchers;
    public ResultProvider(IConfiguration config, GoogleSearchProvider google, BingSearchProvider bing)
    {
      _config = config;
      _google = google;
      _bing = bing;
      _searchers = new List<Searcher>();
      _searchers.Add(new Searcher(_google,"Google"));
      _searchers.Add(new Searcher(_bing,"Bing"));
    }
    public async Task<SearchResultModel> ResultCount(string input)
    {
      var returnModel = new SearchResultModel { Results  = new List<SearchProviderResult>()};
      //built with total happy path. 

      //use this if result per Searcher is interesting
      //var googleSearcher = new Searcher(_google);
      //var googleSearchCount = await googleSearcher.SearchProviderForCount(input);

      //var bingSearcher = new Searcher(_bing);
      //var bingSearchCount = await bingSearcher.SearchProviderForCount(input);
      //return googleSearchCount + bingSearchCount;

      foreach (var searcher in _searchers)
      {
        returnModel.Results.Add(new SearchProviderResult { Name = searcher.GetServiceName(), TotalResults = await searcher.SearchProviderForCount(input) });
      }

      return returnModel;

    }
  }
}
