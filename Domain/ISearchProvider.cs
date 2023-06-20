namespace SearchProject.Domain
{
    public interface ISearchProvider
    {

        public Task<long> Search(string input);
    }
}
