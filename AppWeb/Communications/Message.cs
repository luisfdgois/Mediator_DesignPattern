using MediatR;
using System;

namespace AppWeb.Communications
{
    public class Message : INotification
    {
        public object IdFrom { get; private set; }
        public string _Message { get; private set; }
        public DateTime Time { get; private set; }

        public Message(object idFrom, string message)
        {
            IdFrom = idFrom;
            _Message = message;
            Time = DateTime.Now;
        }
    }
}
