using Microsoft.AspNetCore.Mvc;
using SearchProject.Domain.Setup;
using SearchProject.Models.ViewModel;

namespace SearchProject.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class SearchController : ControllerBase
  {
    ResultProvider _resultProvider;
    public SearchController(ResultProvider resultProvider)
    {
      _resultProvider = resultProvider;
    }

    [HttpGet]
    [Route("search")]
    public async Task<SearchResultModel> Search([FromQuery] string input)
    {
      //sanitize input can be done in a filter too
      input = input.Trim();
      var result = await _resultProvider.ResultCount(input);
      return result;
    }
  }
}
