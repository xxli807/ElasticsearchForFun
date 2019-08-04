using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticsearchForFun.SearchMapping.Document
{
    public class DocumentSearchItemBase
    {
        [Keyword(Name = nameof(Id))]
        public string Id { get; set; }

        [Text(Analyzer = "autocomplete", Name = nameof(Name))]
        public string Name { get; set; }

        [Text(Analyzer = "autocomplete", Name = nameof(Text))]
        public string Text { get; set; }

    }
}
