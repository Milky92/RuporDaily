using System;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Rupor.Api.Models.Article
{
    public class ArticleFilterModel
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}