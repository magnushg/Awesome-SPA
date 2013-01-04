using System;
using System.Linq;
using Raven.Client;
using Raven.Client.Document;

namespace Awesome_SPA.Services
{
    public class SearchRepository : ISearchRepository
    {
        private IDocumentStore _documentStore;
        public SearchRepository()
        {
            _documentStore = new DocumentStore {ConnectionStringName = "RavenDb"};
            _documentStore.Initialize();
        }

        public void SaveSearch(Search search)
        {
            using(var session = _documentStore.OpenSession())
            {
                session.Store(search);
                session.SaveChanges();
            }
        }

        public Search GetById(string id)
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Load<Search>(id);
            }
        }

        public void SaveSearches(Search[] searches)
        {
            using (var session = _documentStore.OpenSession())
            {
                searches.ToList().ForEach(session.Store);
                session.SaveChanges();
            }
        }

        public Search[] GetAll()
        {
            using (var session = _documentStore.OpenSession())
            {
                return session.Query<Search>().ToArray();
            }
        }
    }
    public class Search
    {
        public string Term { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
