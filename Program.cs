using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ElasticsearchForFun.Db;
using ElasticsearchForFun.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ElasticsearchForFun
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var webHost = CreateWebHostBuilder(args).Build();
            using(var scope = webHost.Services.CreateScope())
            {
                var searchClient = scope.ServiceProvider.GetRequiredService<IElasticSearchClient>();
                searchClient.InitClient(); 
            }

            await webHost.RunAsync();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
