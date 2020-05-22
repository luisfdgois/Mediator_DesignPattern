using MediatR;
using System;

namespace AppWeb.Informations
{
    public class Notification : INotification
    {
        public object IdFrom { get; private set; }
        public string Message { get; private set; }
        public DateTime Time { get; private set; }

        public Notification(object idFrom, string message)
        {
            IdFrom = idFrom;
            Message = message;
            Time = DateTime.Now;
        }
    }
}
