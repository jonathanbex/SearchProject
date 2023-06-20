namespace SearchProject.Domain
{
  public class Searcher
  {
    ISearchProvider _provider;
    public Searcher(ISearchProvider provider)
    {
      _provider = provider;
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
  }
}
