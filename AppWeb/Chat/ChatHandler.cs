using AppWeb.Informations;
using AppWeb.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace AppWeb.Chat
{
    public class ChatHandler : INotificationHandler<Notification>
    {
        private readonly IRepository _repository;

        public ChatHandler(IRepository repository)
        {
            _repository = repository;       
        }

        public Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            var name = _repository.Get().FirstOrDefault(p => p.Id.Equals(notification.IdFrom)).Name;

            foreach (var participant in _repository.Get())
            {
                if (!participant.Id.Equals(notification.IdFrom))
                {
                    participant.Notify(name, notification.Time, notification.Message);
                }
            }

            return Task.CompletedTask;
        }
    }
}
