namespace SearchProject.Domain
{
  public class Searcher
  {
    private ISearchProvider _provider;
    private string _serviceName;
    public Searcher(ISearchProvider provider, string serviceName)
    {
      _provider = provider;
      _serviceName = serviceName;
    }
    public async Task<long> SearchProviderForCount(string input)
    {
      if (string.IsNullOrEmpty(input)) return 0;
      var inputCollection = input.Split(" ");
      long count = 0;
      //just safe-case incase they try to ruin me :D
      if (inputCollection.Length > 50) inputCollection = inputCollection.Take(100).ToArray();
      foreach (var word in inputCollection)
      {
        try
        {
          count += await _provider.Search(word);
        }
        catch (Exception e)
        {
          //Either log exception or remove try/catch and serve error to ui
        }
      }

      return count;

    }
    public string GetServiceName() { 
    return _serviceName;
    }
  }
}
