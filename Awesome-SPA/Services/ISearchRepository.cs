namespace Awesome_SPA.Services
{
    public interface ISearchRepository
    {
        void SaveSearch(Search search);
        Search GetById(string id);
        void SaveSearches(Search[] searches);
        Search[] GetAll();
    }
}