using Newtonsoft.Json;

namespace SearchProject.Models
{


  public class BingSearchModelContainer
  {
    [JsonProperty(PropertyName = "_type")]
    public string? Type { get; set; }
    [JsonProperty(PropertyName = "webPages")]
    public WebPage? WebPages { get; set; }
  }
  public class WebPage
  {
    [JsonProperty(PropertyName = "TotalEstimatedMatches")]
    public int? TotalEstimatedMatches { get; set; }
  }
}
