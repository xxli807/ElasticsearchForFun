﻿using ElasticsearchForFun.Db;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.Services
{
    public interface IElasticSearchClient
    {
        // setupSearch
        ElasticClient InitClient(); 
    }
}
