using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rupor.Api.Models.Article;
using Rupor.Business.Topics.Commands.RequestModels;

namespace Rupor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetArticles([FromQuery] ArticleFilterModel model)
        {
            return Ok(new List<int>() {1, 2, 3});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetArticle(string id)
        {
            return Ok(new {t = 1});
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ArticleCreateModel model)
        {
            

            return Created(nameof(Create), new { t = 1 });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Modify(string id, [FromBody] ArticleCreateModel model)
        {
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(string id)
        {
            return NoContent();
        }
    }
}