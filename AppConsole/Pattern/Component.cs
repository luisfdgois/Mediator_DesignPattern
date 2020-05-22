using System;

namespace AppConsole.Pattern
{
    public abstract class Component
    {
        public object Id { get; private set; }
        public IMediator Mediator { get; private set; }

        protected Component(object id)
        {
            Id = id;
        }

        public void Notify(object from, object message)
        {
            Console.WriteLine($"{from} te enviou uma mensagem: \n {message}");
        }

        public void Send(object to, object message)
        {
            Mediator.Send(Id, to, message);
        }

        public void Participate(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
