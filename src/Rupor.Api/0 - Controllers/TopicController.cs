using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rupor.Business.Topics.Commands.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rupor.Api._0___Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicController : Controller
    {
        private readonly IMediator _mediator;
        public TopicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult GetTopics()
        {
            return Ok(new List<int>() { 1, 2, 3 });
        }

        [HttpGet("{id}")]
        public IActionResult GetTopic()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateTopicRequest model)
        {
             var r =await _mediator.Send(model);

            return Created(nameof(Create), new { t = 1 });
        }
    }
}
