using AppWeb.Chat;
using AppWeb.Informations;
using AppWeb.Repositories;
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
        private readonly IRepository _repository;

        public ChatController(IMediator mediator, IRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var result = _repository.Get();

            if (result.Count == 0) return BadRequest(Json("Chat vazio!"));

            return Ok(Json(result));
        }

        [HttpPut("{idFrom:Guid}")]
        public IActionResult Send(Guid idFrom, string message)
        {
            var notification = new Notification(idFrom, message);

            var result = _mediator.Publish(notification);

            if (!result.IsCompletedSuccessfully) return BadRequest();

            return Ok();
        }

        [HttpPost("{name}")]
        public IActionResult Participate(string name)
        {
            var participant = new Participant(name);

            _repository.Add(participant);

            return Ok();
        }
    }
}