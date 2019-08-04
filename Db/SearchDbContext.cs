using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.Db
{
    public class SearchDbContext : DbContext
    {
        public SearchDbContext()
        {
        }

        public SearchDbContext(DbContextOptions<SearchDbContext> options)
            : base(options)
        {
        }


        public DbSet<Test> Tests { get; set; }

    }
}
