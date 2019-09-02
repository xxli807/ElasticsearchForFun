using ElasticsearchForFun.Db;
using ElasticsearchForFun.Settings;
using Microsoft.Extensions.Options;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.Services
{
    public class ElasticSearchClient : IElasticSearchClient
    {
        private readonly AppSettings _appSettings;
        private static ElasticClient client;
        private readonly SearchDbContext _searchDbContext;

        public ElasticSearchClient(IOptions<AppSettings> appsettings, SearchDbContext searchDbContext)
        {
            _appSettings = appsettings.Value;
            _searchDbContext = searchDbContext;
        }

        public ElasticClient InitClient()
        {
            if (client != null)
            {
                return client;
            }

            var url = _appSettings.ElasticsearchUrl;
            var node = new Uri(url);
            var settings = new ConnectionSettings(node);
            settings.ThrowExceptions(alwaysThrow: true); // I like exceptions
            settings.PrettyJson(); // Good for DEBUG

            settings.DefaultIndex("mytestdbindex");

            client = new ElasticClient(settings);

            ///already created
            client.Indices.Create("mytestdbindex", c =>
            c.Map<Test>(m =>
            m.Properties(ps =>
                ps.Text(s => s.Name(n => n.Name))
               .Text(s => s.Name(n => n.Text)))));

            //index document (row in a rds table)
            var testsInDb = _searchDbContext.Tests.ToList(); 
            var indexResponse = client.IndexMany(testsInDb);

            if (indexResponse.Errors)
            {
                foreach (var error in indexResponse.ItemsWithErrors)
                {
                    Console.WriteLine(error.Error);
                }
            }

            return client;
        } 

    }
}
