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

        public ElasticSearchClient(IOptions<AppSettings> appsettings )
        {
            _appSettings = appsettings.Value;
        }

        public void SetUpSearch()
        {
            var url = _appSettings.ElasticsearchUrl;
            var node = new Uri(url);
            var settings = new ConnectionSettings(node);
            settings.ThrowExceptions(alwaysThrow: true); // I like exceptions
            settings.PrettyJson(); // Good for DEBUG
            var client = new ElasticClient(settings);




        }






    }
}
