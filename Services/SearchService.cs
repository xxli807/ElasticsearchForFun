using ElasticsearchForFun.Db;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.Services
{
    public class SearchService : ISearchService
    {
        private readonly IElasticSearchClient _elasticSearchClient;

        public SearchService(IElasticSearchClient elasticSearchClient)
        {
            _elasticSearchClient = elasticSearchClient;
        }

        // test purpose assume already has the client connect
        public IEnumerable<Test> Search(string searchTerm)
        {
            var client = _elasticSearchClient.InitClient();

            var searchRequest = new SearchRequest<Test>
            {
                Query = new MatchAllQuery()
            };

            var response = client.Search<Test>(x => x.AllIndices().Query(q => q.Match(m => m
            .Field(f => f.Text)
            .Query(searchTerm))));

            return response.Documents;
        }

    }
}
