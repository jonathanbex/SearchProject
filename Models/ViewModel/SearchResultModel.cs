namespace SearchProject.Models.ViewModel
{
  public class SearchResultModel
  {
    public List<SearchProviderResult> Results { get; set; }
  }
  public class SearchProviderResult
  {
    public string Name { get; set; }
    public long? TotalResults { get; set; }
  }
}
