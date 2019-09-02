using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElasticsearchForFun.Models;
using ElasticsearchForFun.Services;

namespace ElasticsearchForFun.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }


        [HttpGet]
        public IActionResult Index([FromQuery] string term)
        { 
            var response = _searchService.Search(term);
            return Json(response);
        }

        
    }
}
