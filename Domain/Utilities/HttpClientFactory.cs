namespace SearchProject.Domain.Utilities
{
  public static class HttpClientFactory
  {
    private static HttpClient httpClient = new HttpClient();
    public static HttpClient GetHttpClient()
    {
      return httpClient;
    }
  }
}
