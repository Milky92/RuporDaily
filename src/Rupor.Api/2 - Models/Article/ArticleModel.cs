using System.Collections;
using System.Collections.Generic;

namespace Rupor.Api.Models.Article
{
    public class ArticlesModel
    {
        public IEnumerable<ArticleItemModel> Articles { get; set; }
    }

    public class ArticleItemModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
    }
}