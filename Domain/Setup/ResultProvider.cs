using SearchProject.Domain.SearchProviders;

namespace SearchProject.Domain.Setup
{
  public class ResultProvider
  {
    ISearchProvider _google;
    ISearchProvider _bing;
    IConfiguration _config;
    List<Searcher> _searchers;
    public ResultProvider(IConfiguration config, GoogleSearchProvider google)
    {
      _config = config;
      _google = google;
      _bing = new BingSearchProvider(_config);
      _searchers = new List<Searcher>();
      _searchers.Add(new Searcher(_google));
      _searchers.Add(new Searcher(_bing));
    }
    public async Task<long> ResultCount(string input)
    {
      //built with total happy path. 

      //use this if result per Searcher is interesting
      //var googleSearcher = new Searcher(_google);
      //var googleSearchCount = await googleSearcher.SearchProviderForCount(input);

      //var bingSearcher = new Searcher(_bing);
      //var bingSearchCount = await bingSearcher.SearchProviderForCount(input);
      //return googleSearchCount + bingSearchCount;

      long resultCount = 0;
      foreach (var searcher in _searchers)
      {
        resultCount += await searcher.SearchProviderForCount(input);
      }

      return resultCount;

    }
  }
}
