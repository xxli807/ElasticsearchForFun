using ElasticsearchForFun.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.Services
{
    public interface ISearchService
    {
        IEnumerable<Test> Search(string searchTerm);
    }
}
