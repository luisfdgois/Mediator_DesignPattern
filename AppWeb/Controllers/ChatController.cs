using AppWeb.Communications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AppWeb.Controllers
{
    [ApiController]
    [Route("chat")]
    public class ChatController : Controller
    {
        private readonly IMediator _mediator;

        public ChatController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPut("{idFrom:Guid}")]
        public IActionResult Send(Guid idFrom, string message)
        {
            var msg = new Message(idFrom, message);

            var result = _mediator.Publish(msg);

            if (!result.IsCompletedSuccessfully) return BadRequest();

            return Ok();
        }

        [HttpPost("{name}")]
        public IActionResult Participate(string name)
        {
            var join = new Join(name);

            var result = _mediator.Publish(join);

            if (!result.IsCompletedSuccessfully) return BadRequest();

            return Ok();
        }
    }
}