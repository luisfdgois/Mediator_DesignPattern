using AppWeb.Communications;
using AppWeb.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppWeb.Chat
{
    public class ChatHandler : INotificationHandler<Message>,
                               INotificationHandler<Join>
    {
        private readonly IRepository _repository;

        public ChatHandler(IRepository repository)
        {
            _repository = repository;       
        }

        public Task Handle(Message notification, CancellationToken cancellationToken)
        {
            var name = _repository.Get().FirstOrDefault(p => p.Id.Equals(notification.IdFrom)).Name;

            foreach (var participant in _repository.Get())
            {
                if (!participant.Id.Equals(notification.IdFrom))
                {
                    participant.Notify(name, notification.Time, notification._Message);
                }
            }

            return Task.CompletedTask;
        }

        public Task Handle(Join notification, CancellationToken cancellationToken)
        {
            var participant = new Participant(notification.Name);

            _repository.Add(participant);

            return Task.CompletedTask;
        }
    }
}
